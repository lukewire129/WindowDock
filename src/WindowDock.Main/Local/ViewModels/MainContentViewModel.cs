using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Lombok.NET;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WindowDock.Main.Local.Common;
using WindowDock.Main.Local.Models;

namespace WindowDock.Main.Local.ViewModels
{
    [AllArgsConstructor]
    public partial class MainContentViewModel : ObservableBase, IViewLoadable
    {
        [ObservableProperty] 
        ObservableCollection<QuickIcon> _quickFiles;

        private readonly IDialogService _dialogService;
        private readonly IConService _conService;

        public void OnLoaded(IViewable view)
        {
            this.QuickFiles = new ObservableCollection<QuickIcon> (_conService.GetFiles ());
        }

        [RelayCommand]
        private void RunProc(QuickIcon quickFile)
        {
            if(quickFile.Type == LinkType.Option)
            {
                string Title;
                var message = "This is a message that should be shown in the dialog.";
                //using the dialog service as-is
                _dialogService.Show ("OptionContent", new DialogParameters ($"message={message}"), r =>
                {
                    if (r.Result == ButtonResult.None)
                        Title = "Result is None";
                    else if (r.Result == ButtonResult.OK)
                        Title = "Result is OK";
                    else if (r.Result == ButtonResult.Cancel)
                        Title = "Result is Cancel";
                    else
                        Title = "I Don't know what you did!?";
                });
                return;
            }
            Process.Start (quickFile.FullPath);
        }
    }
}
