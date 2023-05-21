using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Reflector.Types.Local.Converters
{
    internal class TreeDepthConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int level = -1;
            DependencyObject d = value as DependencyObject;
            DependencyObject parent = VisualTreeHelper.GetParent(d);

            while (parent is not TreeView)
            {
                if (parent is TreeViewItem)
                {
                    level++;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }

            return new Thickness(level * 20, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
