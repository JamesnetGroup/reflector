using System.Windows;
using System.Windows.Controls;

namespace Reflector.Types.UI.Units
{
    public class PropertyListItem : TreeViewItem
    {
        static PropertyListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyListItem), new FrameworkPropertyMetadata(typeof(PropertyListItem)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PropertyListItem();
        }
    }
}
