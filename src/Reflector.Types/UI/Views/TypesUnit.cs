using Jamesnet.Wpf.Controls;
using System.Windows;

namespace Reflector.Types.UI.Views
{
    public class TypesUnit : JamesContent
    {
        static TypesUnit()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TypesUnit), new FrameworkPropertyMetadata(typeof(TypesUnit)));
        }
    }
}
