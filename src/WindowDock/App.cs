using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Location;
using Prism.Ioc;
using System.Windows;
using WindowDock.Forms;
using WindowDock.Main.Local.Services;
using WindowDock.Main.Local.ViewModels;
using WindowDock.Main.UI.Views;
using WindowDock.Option.Local.ViewModels;
using WindowDock.Option.UI.Views;

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

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes (containerRegistry);

        containerRegistry.RegisterSingleton<IViewable, MainContent> ("MainContent");
        containerRegistry.RegisterSingleton<IConService> ();
        containerRegistry.RegisterDialogWindow<CustomDialogWindow> ();
        containerRegistry.RegisterDialog<OptionContent, OptionContentViewModel> ();
    }

    protected override void RegisterWireDataContexts(ViewModelLocatorCollection items)
    {
        base.RegisterWireDataContexts (items);

        items.Register<MainContent, MainContentViewModel> ();
        items.Register<OptionContent, OptionContentViewModel> ();
    }
}
