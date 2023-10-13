using Jamesnet.Wpf.Global.Location;
using WindowDock.Local.ViewModels;
using WindowDock.Main.Local.ViewModels;
using WindowDock.Main.UI.Views;

namespace WindowDock.Properties
{
    public class WireDataContext : ViewModelLocationScenario
    {
        protected override void Match(ViewModelLocatorCollection items)
        {
            items.Register<MainWindow, MainWindowViewMoel> ();
            items.Register<MainContent, MainContentViewModel> ();
        }
    }
}
