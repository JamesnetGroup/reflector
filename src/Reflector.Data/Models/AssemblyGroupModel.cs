namespace Reflector.Data.Models
{
    public class AssemblyGroupModel : AssemblyModel
    {
        public bool IsExpanded { get; set; }

        public AssemblyGroupModel(string name, bool isExpanded = false) : base(null)
        {
            Name = name;
            IsExpanded = isExpanded;
        }
    }
}
