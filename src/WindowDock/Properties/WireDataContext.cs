using Jamesnet.Wpf.Global.Location;
using WindowDock.Main.Local.ViewModels;
using WindowDock.Main.UI.Views;
using WindowDock.Option.Local.ViewModels;
using WindowDock.Option.UI.Views;

namespace WindowDock.Properties
{
    public class WireDataContext : ViewModelLocationScenario
    {
        protected override void Match(ViewModelLocatorCollection items)
        {
            items.Register<MainContent, MainContentViewModel> ();
            items.Register<OptionContent, OptionContentViewModel> ();
        }
    }
}
