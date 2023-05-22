using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflector.Data.Arguments
{
    public class CurrentTypePubArgs : EventArgs
    {
        public Assembly Assembly { get; set; }
    }
}
