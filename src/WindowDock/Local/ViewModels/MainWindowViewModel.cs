using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WindowDock.Local.Common;
using WindowDock.Local.Models;

namespace WindowDock.Local.ViewModels
{
    public partial class MainWindowViewModel : ObservableBase
    {
        [ObservableProperty] ObservableCollection<QuickIcon> _quickFiles;
        public MainWindowViewModel()
        {
            IConService conService = new IConService ($"{Environment.GetFolderPath (System.Environment.SpecialFolder.ApplicationData)}\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\");
            this.QuickFiles = new ObservableCollection<QuickIcon>(conService.GetFiles ());
        }

        [RelayCommand]
        private void RunProc(QuickIcon quickFile)
        {
            if(quickFile.Type == LinkType.Add)
            {
                return;
            }
            Process.Start (quickFile.FullPath);
        }
    }
}
