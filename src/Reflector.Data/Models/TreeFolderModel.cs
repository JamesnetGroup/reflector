namespace Reflector.Data.Models
{
    public class TreeFolderModel : TreeModel
    {
        public bool IsExpanded { get; set; }

        public TreeFolderModel(string name, bool isExpanded = false) : base(null)
        {
            Name = name;
            IsExpanded = isExpanded;
        }
    }
}
