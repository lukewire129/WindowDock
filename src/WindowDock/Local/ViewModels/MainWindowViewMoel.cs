using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Composition;
using Jamesnet.Wpf.Mvvm;

namespace WindowDock.Local.ViewModels;

public partial class MainWindowViewMoel : ObservableBase, IViewLoadable
{
    private readonly ContentManager _contentManager;

    public MainWindowViewMoel(ContentManager contentManager)
    {
        this._contentManager = contentManager;
    }

    public void OnLoaded(IViewable view)
    {
        this._contentManager.ActiveContent ("MainRegion", "MainContent");
    }
}
