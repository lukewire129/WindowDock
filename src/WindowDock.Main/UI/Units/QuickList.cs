using System.Windows;
using System.Windows.Controls;

namespace WindowDock.Main.UI.Units
{
    public class QuickList : ListBox
    {
        static QuickList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickList), new FrameworkPropertyMetadata(typeof(QuickList)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new QuickListItem ();
        }



        public Thickness ChildrenSpacing
        {
            get { return (Thickness)GetValue (ChildrenSpacingProperty); }
            set { SetValue (ChildrenSpacingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildrenSpacing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChildrenSpacingProperty =
            DependencyProperty.Register ("ChildrenSpacing", typeof (Thickness), typeof (QuickList), new PropertyMetadata (new Thickness (10, 10, 10 ,10)));


        public void IsStyleChange(bool OnOff = false)
        {
            if(OnOff)
            {
                this.ChildrenSpacing = new Thickness (0, 0, 0, 0);
                return;
            }
            this.ChildrenSpacing = new Thickness (10, 10, 10, 10);
        }

    }
}
