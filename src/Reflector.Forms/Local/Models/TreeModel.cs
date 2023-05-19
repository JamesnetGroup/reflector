using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;

namespace Reflector.Forms.Local.Models
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
