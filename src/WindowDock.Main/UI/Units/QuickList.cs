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
    }
}
