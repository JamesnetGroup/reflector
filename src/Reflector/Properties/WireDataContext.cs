using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Location;
using Reflector.Forms.Local.ViewModels;
using Reflector.Forms.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflector.Properties
{
    internal class WireDataContext : ViewModelLocationScenario
    {
        protected override void Match(ViewModelLocatorCollection items)
        {
            items.Register<MainContent, MainContentViewModel>();
        }
    }
}
