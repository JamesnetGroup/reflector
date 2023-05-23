using System.Collections.Generic;

namespace Reflector.Data.Models
{
    public class NamespaceNode
    {
        public string Name { get; set; }
        public List<TypeNode> Items { get; set; } = new List<TypeNode>();
    }
}
