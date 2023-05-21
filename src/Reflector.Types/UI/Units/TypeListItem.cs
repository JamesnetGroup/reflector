using System.Windows;
using System.Windows.Controls;

namespace Reflector.Types.UI.Units
{
    public class TypeListItem : TreeViewItem
    {
        static TypeListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TypeListItem), new FrameworkPropertyMetadata(typeof(TypeListItem)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TypeListItem();
        }
    }
}
