using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Reflector.Core.Reflection;
using Reflector.Data.Arguments;
using Reflector.Data.Events;
using Reflector.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reflector.Types.Local.ViewModels
{
    public partial class TypesUnitViewModel : ObservableBase, IViewLoadable
    {
        private readonly IEventHub _eventHub;
        private readonly AssemblyManager _assemblyManager;

        [ObservableProperty]
        private List<MemberTypeNode> _properites;
        [ObservableProperty]
        private List<NamespaceNode> _typeDetails;

        public TypesUnitViewModel(IEventHub eventHub, AssemblyManager assemblyManager)
        {
            _eventHub = eventHub;
            _assemblyManager = assemblyManager;
        }

        public void OnLoaded(IViewable view)
        {
            _eventHub.Subscribe<CurrentTypePubHandler, CurrentTypePubArgs>(CurrentTypeChanged);
        }

        private void CurrentTypeChanged(CurrentTypePubArgs args)
        {
            TypeDetails = _assemblyManager.CreateHierarchy(args.Assembly);
        }

        [RelayCommand]
        private void TypeClick(object value)
        {
            if (value is not TypeNode node)
            {
                return;
            }

            List<MemberNode> allMembers = node.MemberTypes.SelectMany(pair => pair.Members).ToList();
            Properites = _assemblyManager.CreateHierarchyMemberTypes(allMembers);
        }
    }
}
