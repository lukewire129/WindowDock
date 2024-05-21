using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Lombok.NET;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WindowDock.Main.Local.Services;
using WindowDock.Main.Local.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using WindowDock.Core.Utils;
using WindowDock.Main.Local.Extentions;

namespace WindowDock.Main.Local.ViewModels
{
    [AllArgsConstructor]
    public partial class MainContentViewModel : ObservableBase, IViewLoadable
    {
        [ObservableProperty] ObservableCollection<QuickIcon> _quickFiles;

        private readonly IDialogService _dialogService;
        private readonly IConService _conService;

        public void OnLoaded(IViewable view)
        {
            if (File.Exists ("data.txt") == false)
            {
                this.QuickFiles = new ObservableCollection<QuickIcon> (_conService.GetFiles ());
                return;
            }

            using (StreamReader sw = File.OpenText ("data.txt"))
            {
                string data = sw.ReadToEnd ();
                var objs = Base64String.Get<QuickBaseIcon> (data);
                this.QuickFiles = new ObservableCollection<QuickIcon> (objs.Change ());
            }
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

        [RelayCommand]
        private void DropFile(QuickIcon dropFile)
        {
            dropFile.FileImage = dropFile.FullPath.Convert();
            this.QuickFiles.Insert (this.QuickFiles.Count() -1 ,dropFile);
            Save (this.QuickFiles.ToList ().Change ());
        }

        private void Save(List<QuickBaseIcon> objs)
        {
            string base64 = Base64String.Get (objs);
            using (StreamWriter sw = File.CreateText ("data.txt"))
                sw.Write (base64);
        }
    }
}
