using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Reflector.Core.Reflection;
using Reflector.Data.Arguments;
using Reflector.Data.Events;
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
        private readonly IEventHub _eventHub;

        public List<TreeModel> Assemblies { get; init; }

        public AssemblyUnitViewModel(IEventHub eventHub)
        {
            _eventHub = eventHub;
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
                CurrentTypePubArgs args = new();
                args.Assembly = data.Assem;

                _eventHub.Publish<CurrentTypePubHandler, CurrentTypePubArgs>(args);                
            }
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
