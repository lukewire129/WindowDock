using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;
using WindowDock.Main.UI.Views;

namespace WindowDock.Properties
{
    public class ViewModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewable, MainContent> ("MainContent");
        }
    }
}
