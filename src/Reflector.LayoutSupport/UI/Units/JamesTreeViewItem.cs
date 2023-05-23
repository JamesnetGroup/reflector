using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflector.LayoutSupport.UI.Units
{
    public class JamesTreeViewItem : TreeViewItem
    {
        public static DependencyProperty ClickProperty = DependencyProperty.Register("Click", typeof(ICommand), typeof(JamesTreeViewItem), new PropertyMetadata(null));

        public ICommand Click
        {
            get => (ICommand)GetValue(ClickProperty);
            set => SetValue(ClickProperty, value);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext == DataContext)
            {
                Click?.Execute(fe.DataContext);
            }
        }
    }
}
