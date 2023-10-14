using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WindowDock.Main.Local.Common;
using WindowDock.Main.Local.Models;

namespace WindowDock.Main.Local.ViewModels
{
    public partial class MainContentViewModel : ObservableBase
    {
        private readonly IDialogService _dialogService;
        [ObservableProperty] ObservableCollection<QuickIcon> _quickFiles;
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty (ref _title, value); }
        }
        public MainContentViewModel(IDialogService dialogService)
        {
            IConService conService = new IConService ($"{Environment.GetFolderPath (System.Environment.SpecialFolder.ApplicationData)}\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\");
            this.QuickFiles = new ObservableCollection<QuickIcon>(conService.GetFiles ());
            this._dialogService = dialogService;
        }

        [RelayCommand]
        private void RunProc(QuickIcon quickFile)
        {
            if(quickFile.Type == LinkType.Option)
            {
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
