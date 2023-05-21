using Reflector.Properties;
using System;

namespace Reflector
{
    internal class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .AddWireDataContext<WireDataContext>()
                .AddInversionModule<ViewModules>()
                .Run();
        }
    }
}
