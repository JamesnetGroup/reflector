using System.Collections.Generic;

namespace Reflector.Data.Models
{
    public class MemberNode
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsStatic { get; set; }
        public string MemberType { get; set; } // Method, Property, Field
        public string DataType { get; set; } // Return type for methods, data type for fields and properties
        public List<string> Parameters { get; set; } = new List<string>();
    }
}
