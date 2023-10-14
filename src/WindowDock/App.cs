using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using System.Windows;
using WindowDock.Forms;

namespace WindowDock;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : JamesApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow> ();
    }
}
