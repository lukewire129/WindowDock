using Jamesnet.Wpf.Controls;
using System.Windows;

namespace WindowDock.Option.UI.Views;

public class OptionContent : JamesContent
{
    static OptionContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(OptionContent), new FrameworkPropertyMetadata(typeof (OptionContent)));
    }
}
