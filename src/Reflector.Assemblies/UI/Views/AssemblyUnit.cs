using Jamesnet.Wpf.Controls;
using System.Windows;
using System.Windows.Input;

namespace Reflector.Assemblies.UI.Views
{
    public class AssemblyUnit : JamesContent
    {
        static AssemblyUnit()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AssemblyUnit), new FrameworkPropertyMetadata(typeof(AssemblyUnit)));
        }
    }
}
