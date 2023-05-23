using System.Windows;
using System.Windows.Controls;

namespace Reflector.Types.UI.Units
{
    public class PropertyList : TreeView
    {
        static PropertyList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyList), new FrameworkPropertyMetadata(typeof(PropertyList)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PropertyListItem();
        }
    }
}
