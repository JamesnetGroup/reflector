using System.Windows;
using System.Windows.Controls;

namespace Reflector.LayoutSupport.UI.Units
{
    public class ModernWindow : Window
    {
        static ModernWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernWindow), new FrameworkPropertyMetadata(typeof(ModernWindow)));
        }
    }
}
