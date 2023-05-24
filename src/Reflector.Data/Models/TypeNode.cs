using System.Collections.Generic;

namespace Reflector.Data.Models
{
    public class TypeNode
    {
        public string Name { get; set; }
        public bool IsNamespace { get; set; } = false;
        public List<MemberTypeIdentifier> MemberTypes { get; set; }
    }
}
