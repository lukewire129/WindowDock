using Prism.Services.Dialogs;
using System.Windows;
using System.Windows.Input;

namespace WindowDock.Forms
{
    /// <summary>
    /// DialogWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CustomDialogWindow : Window, IDialogWindow
    {
        public IDialogResult Result { get; set; }
        public CustomDialogWindow()
        {
            InitializeComponent ();
            this.MouseLeftButtonDown += CustomDialogWindow_MouseLeftButtonDown;
        }

        private void CustomDialogWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove ();
        }
    }
}
