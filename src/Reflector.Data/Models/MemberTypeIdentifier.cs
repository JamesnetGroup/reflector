using System.Collections.Generic;

namespace Reflector.Data.Models
{
    public class MemberTypeIdentifier
    {
        public string Name { get; set; }
        public List<MemberNode> Members { get; set; }
    }
}
