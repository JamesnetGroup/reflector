using System.Windows;
using System.Windows.Controls;

namespace Reflector.Types.UI.Units
{
    public class TypeList : TreeView
    {
        static TypeList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TypeList), new FrameworkPropertyMetadata(typeof(TypeList)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TypeListItem();
        }
    }
}
