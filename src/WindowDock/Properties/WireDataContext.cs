
using Jamesnet.Wpf.Global.Location;
using WindowDock.Local.ViewModels;

namespace WindowDock.Properties
{
    public class WireDataContext : ViewModelLocationScenario
    {
        protected override void Match(ViewModelLocatorCollection items)
        {
            items.Register<MainWindow, MainWindowViewModel> ();
        }
    }
}
