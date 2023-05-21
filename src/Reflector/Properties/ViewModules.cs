using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Reflector.Assemblies.UI.Views;
using Reflector.Types.UI.Views;

namespace Reflector.Properties
{
    internal class ViewModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewable, AssemblyUnit>("AssemblyUnit");
            containerRegistry.RegisterSingleton<IViewable, TypesUnit>("TypesUnit");
        }
    }
}
