using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Global.Event;
using Jamesnet.Wpf.Mvvm;
using Lombok.NET;
using Prism.Services.Dialogs;
using System;

namespace WindowDock.Option.Local.ViewModels
{
    [AllArgsConstructor]
    public partial class OptionContentViewModel : ObservableBase, IDialogAware
    {
        [ObservableProperty] string _title = "Notification";

        public event Action<IDialogResult> RequestClose;
        private readonly IEventHub _eventHub;

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower () == "true")
                result = ButtonResult.OK;
            else if (parameter?.ToLower () == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose (new DialogResult (result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke (dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}