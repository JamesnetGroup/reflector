using System.Collections.Generic;

namespace Reflector.Data.Models
{
    public class NamespaceNode
    {
        public string Name { get; set; }
        public bool IsNamespace { get; set; } = true;
        public List<TypeNode> Items { get; set; } = new();
    }
}
