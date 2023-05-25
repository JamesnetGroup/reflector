using System.Collections.Generic;
using System.Reflection;

namespace Reflector.Data.Models
{
    public class MemberTypeNode
    {
        public string Name { get; set; }
        public List<MemberNode> Items { get; set; }
        public bool IsMemberType { get; set; } = true;

        public MemberTypeNode(string key, List<MemberNode> memberNodes)
        {
            Name = key;
            Items = memberNodes;
        }
    }
}
