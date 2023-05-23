using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Reflector.Core.Utilities;
using Reflector.Data.Models;
using Reflector.Data.Services;
using System.Collections.Generic;
using System.Linq;

namespace Reflector.Types.Local.ViewModels
{
    public partial class TypesUnitViewModel : ObservableBase, IViewLoadable
    {
        private readonly IEventHub _eventHub;
        private readonly AssemblyInspector _assemblyInspector;

        [ObservableProperty]
        private List<MemberTypeNode> _properites;
        [ObservableProperty]
        private List<NamespaceNode> _typeDetails;

        public TypesUnitViewModel(IEventHub eventHub, AssemblyInspector assemblyInspector)
        {
            _eventHub = eventHub;
            _assemblyInspector = assemblyInspector;
        }

        public void OnLoaded(IViewable view)
        {
            _eventHub.Subscribe<CurrentTypeEventHandler, CurrentTypeEventArgs>(CurrentTypeChanged);
        }

        private void CurrentTypeChanged(CurrentTypeEventArgs args)
        {
            TypeDetails = _assemblyInspector.BuildTypeHierarchy(args.Assembly);
        }

        [RelayCommand]
        private void TypeClick(object value)
        {
            if (value is not TypeNode node)
            {
                return;
            }

            List<MemberNode> allMembers = node.MemberTypes.SelectMany(pair => pair.Members).ToList();
            Properites = _assemblyInspector.BuildMemberTypeHierarchy(allMembers);
        }
    }
}
