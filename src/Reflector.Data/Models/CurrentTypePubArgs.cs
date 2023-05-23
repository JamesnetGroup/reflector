using System;
using System.Reflection;

namespace Reflector.Data.Models
{
    public class CurrentTypeEventArgs : EventArgs
    {
        public Assembly Assembly { get; set; }

        public CurrentTypeEventArgs(Assembly assembly)
        {
            Assembly = assembly;
        }
    }
}
