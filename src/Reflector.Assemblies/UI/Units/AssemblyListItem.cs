using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflector.Assemblies.UI.Units
{
    public class AssemblyListItem : TreeViewItem
    {
        public static DependencyProperty ClickProperty = DependencyProperty.Register("Click", typeof(ICommand), typeof(AssemblyListItem), new PropertyMetadata(null));

        public ICommand Click
        {
            get => (ICommand)GetValue(ClickProperty);
            set => SetValue(ClickProperty, value);
        }

        static AssemblyListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AssemblyListItem), new FrameworkPropertyMetadata(typeof(AssemblyListItem)));
        }

        public AssemblyListItem()
        {
            MouseLeftButtonDown += AssemblyListItem_MouseLeftButtonDown;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext == DataContext)
            {
                Click?.Execute(fe.DataContext);
            }
        }

        private void AssemblyListItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AssemblyListItem();
        }
    }
}
