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
        [ObservableProperty]
        private ObservableCollection<QuickFile> _quickFiles;
        public MainWindowViewModel()
        {
            IConService conService = new IConService ($"{Environment.GetFolderPath (System.Environment.SpecialFolder.ApplicationData)}\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\");
            this.QuickFiles = new ObservableCollection<QuickFile>(conService.GetFiles ());
        }

        [RelayCommand]
        private void RunProc(QuickFile quickFile)
        {
            Process.Start (quickFile.FullPath);
        }
    }
}
