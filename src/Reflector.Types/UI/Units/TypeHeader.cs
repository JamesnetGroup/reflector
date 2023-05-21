using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflector.Types.UI.Units
{
    public class TypeHeader : Control
    {
        static TypeHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TypeHeader), new FrameworkPropertyMetadata(typeof(TypeHeader)));
        }
    }
}
