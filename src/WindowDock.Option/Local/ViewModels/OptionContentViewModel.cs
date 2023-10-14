﻿using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;

namespace WindowDock.Option.Local.ViewModels
{
    public partial class OptionContentViewModel : ObservableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string> (CloseDialog));

        [ObservableProperty]
        private string _message;

        [ObservableProperty]
        private string _title = "Notification";

        public event Action<IDialogResult> RequestClose;

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
            Message = parameters.GetValue<string> ("message");
        }
    }
}