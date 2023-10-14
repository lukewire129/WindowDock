using System.Windows;
using System.Windows.Controls;

namespace WindowDock.Option.UI.Units;
public  class StyleGroupBox : ListBox
{
    static StyleGroupBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata (typeof (StyleGroupBox), new FrameworkPropertyMetadata (typeof (StyleGroupBox)));
    }
    protected override DependencyObject GetContainerForItemOverride()
    {
        return new StyleGroupBoxItem ();
    }
}
