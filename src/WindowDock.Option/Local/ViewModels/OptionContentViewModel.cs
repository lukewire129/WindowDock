using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Event;
using Jamesnet.Wpf.Mvvm;
using Lombok.NET;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using WindowDock.Core.Enums;
using WindowDock.Core.Event;
using WindowDock.Option.Local.Models;

namespace WindowDock.Option.Local.ViewModels
{
    [AllArgsConstructor]
    public partial class OptionContentViewModel : ObservableBase, IDialogAware, IViewLoadable
    {
        [ObservableProperty] 
        string _title = "Notification";
        [ObservableProperty]

        ObservableCollection<StyleModel> _styleModels;
        private readonly IEventHub _eventHub;

        public void OnLoaded(IViewable view)
        {
            StyleModels = new ()
            {
                new StyleModel(StyleEnum.Style1, "Style1"),
                new StyleModel(StyleEnum.Style2, "Style2"),
                new StyleModel(StyleEnum.Style3, "Style3"),
                new StyleModel(StyleEnum.Style4, "Style4"),
                new StyleModel(StyleEnum.Style5, "Style5"),
            };
        }

        [RelayCommand]
        private void SelectStyle(StyleModel styleModel)
        {
            this._eventHub.Publish<StyleChangedPubsub, StyleEnum> (styleModel.type);
        }
        #region Dialog 사용안함
        public event Action<IDialogResult> RequestClose;
        [RelayCommand]
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
        #endregion
    }
}