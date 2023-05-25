using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Global.Evemt;
using Jamesnet.Wpf.Mvvm;
using Reflector.Core.Utilities;
using Reflector.Data.Models;
using Reflector.Data.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reflector.Assemblies.Local.ViewModels
{
		public partial class AssemblyUnitViewModel : ObservableBase
		{
				private readonly IEventHub _eventHub;

				public List<AssemblyModel> Assemblies { get; init; }

				public AssemblyUnitViewModel(IEventHub eventHub, AssemblyInspector assemblyInspector)
				{
						_eventHub = eventHub;
						Assemblies = assemblyInspector.LoadAssemblies();
				}

				[RelayCommand]
				private void AssemblyClick(AssemblyModel data)
				{
						if (data.Assem == null)
								return;

						CurrentTypeEventArgs args = new(data.Assem);
						_eventHub.Publish<CurrentTypeEventHandler, CurrentTypeEventArgs>(args);
				}
		}
}
