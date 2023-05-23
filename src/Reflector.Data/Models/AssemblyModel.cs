using System.Collections.Generic;
using System.Reflection;

namespace Reflector.Data.Models
{
    public class AssemblyModel
    {
        public string Name { get; set; }
        public Assembly Assem { get; set; }
        public List<AssemblyModel> Items { get; set; } = new();

        public AssemblyModel(Assembly assem)
        {
            if (assem == null)
                return;
            Name = assem.FullName.Split(',')[0];
            Assem = assem;
        }

    }
}
