using System.Windows;
using System.Windows.Controls;

namespace Reflector.Forms.UI.Units
{
    public class AssemblyListItem : TreeViewItem
    {
        static AssemblyListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AssemblyListItem), new FrameworkPropertyMetadata(typeof(AssemblyListItem)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AssemblyListItem();
        }
    }
}
