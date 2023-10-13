using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WindowDock.Main.UI.Units
{
    public class QuickListItem : Button
    {
        public static readonly DependencyProperty SelectCommandProperty =
            DependencyProperty.Register ("SelectCommand", typeof (ICommand), typeof (QuickListItem), new PropertyMetadata (null));

        public ICommand SelectCommand
        {
            get { return (ICommand)GetValue (SelectCommandProperty); }
            set { SetValue (SelectCommandProperty, value); }
        }
        static QuickListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickListItem), new FrameworkPropertyMetadata(typeof(QuickListItem)));
        }
        public QuickListItem()
        {
            this.Click += (s, e) =>
            {
                this.SelectCommand?.Execute (this.DataContext);
            };
        }
    }
}
