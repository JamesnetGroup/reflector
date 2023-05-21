using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflector.Assemblies.UI.Units
{
    public class AssemblyList : TreeView
    {
        static AssemblyList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AssemblyList), new FrameworkPropertyMetadata(typeof(AssemblyList)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AssemblyListItem();
        }
    }
}
