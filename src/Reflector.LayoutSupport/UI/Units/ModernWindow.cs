using System.Windows;

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
