using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using Reflector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflector.Assemblies.Local.ViewModels
{
    public partial class AssemblyUnitViewModel : ObservableBase
    {
        [ObservableProperty]
        private TreeModel _currentAssembly;
        [ObservableProperty]
        public List<AssemInfo> _assemblyInfo;

        public List<TreeModel> Assemblies { get; init; }

        public AssemblyUnitViewModel()
        {
            Assemblies = GetTypes();
        }

        private static List<TreeModel> GetTypes()
        {
            List<TreeModel> tree = new();
            TreeFolderModel all = new("All");
            TreeFolderModel dotnet = new("Systems");

            List<Assembly> assems = AppDomain.CurrentDomain.GetAssemblies().ToList();

            while (assems.Any())
            {
                Assembly assem = assems.First();
                assems.Remove(assem);

                all.Items.Add(new(assem));

                if (assem.FullName.Contains("System."))
                {
                    dotnet.Items.Add(new(assem));
                }
            }

            tree.Add(all);
            tree.Add(dotnet);

            return tree;
        }

        [RelayCommand]
        private void AssemblyClick(TreeModel data)
        {
            CurrentAssembly = data;
            if (data.Assem != null)
            {
                AssemblyInfo = GetAssemblyInfo(data.Assem);
            }
        }

        private List<AssemInfo> GetAssemblyInfo(Assembly assembly)
        {
            List<AssemInfo> assemblyInfoList = new List<AssemInfo>();

            // List all the types (classes, interfaces, enums, etc.)
            foreach (var type in assembly.GetTypes())
            {
                AssemInfo assemInfo = new AssemInfo
                {
                    TypeName = type.FullName,
                    IsClass = type.IsClass,
                    IsPublic = type.IsPublic,
                    IsPrivate = !type.IsPublic && !type.IsNotPublic, // Non-public (internal types might also be included here)
                    IsAbstract = type.IsAbstract,
                    IsSealed = type.IsSealed,
                    IsInterface = type.IsInterface
                };

                // List all the methods for each type
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    assemInfo.Methods.Add(method.Name);
                }

                // List all the properties for each type
                foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    assemInfo.Properties.Add(prop.Name);
                }

                // List all the fields for each type
                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    assemInfo.Fields.Add(field.Name);
                }

                assemblyInfoList.Add(assemInfo);
            }

            return assemblyInfoList;
        }
    }

    public class AssemInfo
    {
        public string TypeName { get; set; }
        public bool IsClass { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public bool IsInterface { get; set; }
        public List<string> Methods { get; set; } = new List<string>();
        public List<string> Properties { get; set; } = new List<string>();
        public List<string> Fields { get; set; } = new List<string>();
    }
}
