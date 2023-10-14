using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;
using WindowDock.Forms;
using WindowDock.Main.Local.Common;
using WindowDock.Main.UI.Views;
using WindowDock.Option.Local.ViewModels;
using WindowDock.Option.UI.Views;

namespace WindowDock.Properties;
public class ViewModules : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IViewable, MainContent> ("MainContent");
        containerRegistry.RegisterSingleton<IConService> ();
        containerRegistry.RegisterDialogWindow<CustomDialogWindow> ();
        containerRegistry.RegisterDialog<OptionContent, OptionContentViewModel> ();

        //containerRegistry.RegisterSingleton<IViewable, OptionContent> ("OptionContent");

    }
}
