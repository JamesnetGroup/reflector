using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;

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
            IRegion region = _regionManager.Regions["AssemblyUnitRegion"];
            IViewable typeUnit = _containerExtension.Resolve<IViewable>("AssemblyUnit");

            if (!region.Views.Contains(typeUnit))
            {
                region.Add(typeUnit);
            }
            region.Activate(typeUnit);
        }
    }
}
