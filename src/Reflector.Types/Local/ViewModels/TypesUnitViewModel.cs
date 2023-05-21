using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Reflector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflector.Types.Local.ViewModels
{
    public class TypesUnitViewModel : ObservableBase, IViewLoadable
    {
        private readonly IEventHub _hub;

        public List<TreeModel> Types { get; init; }

        public TypesUnitViewModel(IEventHub hub)
        {
            _hub = hub;
        }

        public void OnLoaded(IViewable view)
        {
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
    }
}
