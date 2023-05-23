using System;
using System.Reflection;

namespace Reflector.Data.Arguments
{
    public class CurrentTypePubArgs : EventArgs
    {
        public Assembly Assembly { get; set; }

        public CurrentTypePubArgs(Assembly assembly)
        {
            Assembly = assembly;
        }
    }
}
