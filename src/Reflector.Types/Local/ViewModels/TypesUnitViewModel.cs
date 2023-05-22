using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Reflector.Core.Reflection;
using Reflector.Data.Arguments;
using Reflector.Data.Events;
using Reflector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflector.Types.Local.ViewModels
{
    public partial class TypesUnitViewModel : ObservableBase, IViewLoadable
    {
        private readonly IEventHub _eventHub;

        [ObservableProperty]
        public List<NamespaceNode> _typeDetails;

        public List<TreeModel> Types { get; init; }

        public TypesUnitViewModel(IEventHub eventHub)
        {
            _eventHub = eventHub;
        }

        public void OnLoaded(IViewable view)
        {
            _eventHub.Subscribe<CurrentTypePubHandler, CurrentTypePubArgs>(CurrentTypeChanged);
        }

        private void CurrentTypeChanged(CurrentTypePubArgs args)
        {
            TypeDetails = AssemblyInspector.CreateHierarchy(args.Assembly);
        }
    }
}
