using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflector.Data.Models
{
    public class TypeDetails
    {
        public string Namespace { get; set; }
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
