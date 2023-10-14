using Jamesnet.Wpf.Controls;
using Prism.Regions;
using System.Windows.Input;

namespace WindowDock.Forms;
public partial class MainWindow : JamesWindow
{
    public MainWindow(IRegionManager regionManager)
    {
        InitializeComponent ();
        regionManager.RegisterViewWithRegion ("MainRegion", "MainContent");
        //regionManager.RegisterViewWithRegion ("MainRegion", "OptionContent");
        this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
    }

    private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove ();
    }
}