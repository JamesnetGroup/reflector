using Reflector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflector.Core.Reflection
{
    public class ReferenceManager
    {
        public List<TreeModel> LoadInfo()
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
