using Jamesnet.Wpf.Controls;
using Reflector.Forms.UI.Views;
using System.Windows;

namespace Reflector
{
    internal class App : JamesApplication
    {
        protected override Window CreateShell()
        {
            return new ReflectorWindow();
        }
    }
}
