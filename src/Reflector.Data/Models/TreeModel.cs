using System.Collections.Generic;
using System.Reflection;

namespace Reflector.Data.Models
{
    public class TreeModel
    {
        public string Name { get; set; }
        public Assembly Assem { get; set; }
        public List<TreeModel> Items { get; set; } = new();

        public TreeModel(Assembly assem)
        {
            if (assem == null)
                return;
            Name = assem.FullName.Split(',')[0];
            Assem = assem;
        }

    }
}
