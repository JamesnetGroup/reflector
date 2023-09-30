using System.Reflection;

namespace Reflector.Data.Models
{

    public class FieldDetails
    {
        public FieldInfo Field { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsStatic { get; set; }
        public bool IsBackingField { get; set; }
    }
}