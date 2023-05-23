using Reflector.LayoutSupport.UI.Units;
using System.Windows;

namespace Reflector.Assemblies.UI.Units
{
    public class AssemblyListItem : JamesTreeViewItem
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
