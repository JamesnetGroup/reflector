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
        }
    }
}
