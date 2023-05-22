using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;
using System;

namespace Reflector.Forms.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableBase, IViewLoadable
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _containerExtension;

        public MainContentViewModel(IRegionManager regionManager, IContainerExtension containerExtension)
        {
            _regionManager = regionManager;
            _containerExtension = containerExtension;
        }

        public void OnLoaded(IViewable view)
        {
            SwitchRegion("AssemblyUnitRegion", "AssemblyUnit");
            SwitchRegion("TypesUnitRegion", "TypesUnit");
        }

        private void SwitchRegion(string regionName, string viewName)
        {
            IRegion region = _regionManager.Regions[regionName];
            IViewable view = _containerExtension.Resolve<IViewable>(viewName);

            if (!region.Views.Contains(view))
            {
                region.Add(view);
            }
            region.Activate(view);
        }
    }
}
