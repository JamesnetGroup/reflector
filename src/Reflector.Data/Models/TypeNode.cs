using System.Collections.Generic;

namespace Reflector.Data.Models
{
    public class TypeNode
    {
        public string Name { get; set; }
        public bool IsNamespace { get; set; } = false;
        public bool IsInterface { get; set; }
        public bool IsEnum { get; set; }
        public bool IsObject { get; set; }
        public bool HasBaseType { get; set; }
        public List<MemberTypeIdentifier> MemberTypes { get; set; }
    }
}
