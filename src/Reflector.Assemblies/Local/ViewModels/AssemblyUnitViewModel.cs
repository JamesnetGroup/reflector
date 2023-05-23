using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Reflector.Core.Reflection;
using Reflector.Data.Arguments;
using Reflector.Data.Events;
using Reflector.Data.Models;
using System.Collections.Generic;

namespace Reflector.Assemblies.Local.ViewModels
{
    public partial class AssemblyUnitViewModel : ObservableBase
    {
        private readonly IEventHub _eventHub;

        public List<TreeModel> Assemblies { get; init; }

        public AssemblyUnitViewModel(IEventHub eventHub, ReferenceManager referenceInspector)
        {
            _eventHub = eventHub;
            Assemblies = referenceInspector.LoadInfo();
        }

        [RelayCommand]
        private void AssemblyClick(TreeModel data)
        {
            if (data.Assem != null)
            {
                CurrentTypePubArgs args = new(data.Assem);
                _eventHub.Publish<CurrentTypePubHandler, CurrentTypePubArgs>(args);                
            }
        }
    }
}
