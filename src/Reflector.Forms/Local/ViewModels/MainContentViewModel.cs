using Jamesnet.Wpf.Mvvm;
using Reflector.Forms.Local.Extensions;
using Reflector.Forms.Local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflector.Forms.Local.ViewModels
{
    public class MainContentViewModel : ObservableBase
    {
        public List<TreeModel> Types { get; init; }

        public MainContentViewModel()
        {
            Types = GetTypes();
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
