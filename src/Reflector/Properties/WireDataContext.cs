using Jamesnet.Wpf.Global.Location;
using Reflector.Assemblies.Local.ViewModels;
using Reflector.Assemblies.UI.Views;
using Reflector.Forms.Local.ViewModels;
using Reflector.Forms.UI.Views;
using Reflector.Types.Local.ViewModels;
using Reflector.Types.UI.Views;

namespace Reflector.Properties
{
    internal class WireDataContext : ViewModelLocationScenario
    {
        protected override void Match(ViewModelLocatorCollection items)
        {
            items.Register<MainContent, MainContentViewModel>();
            items.Register<TypesUnit, TypesUnitViewModel>();
            items.Register<AssemblyUnit, AssemblyUnitViewModel>();
        }
    }
}
