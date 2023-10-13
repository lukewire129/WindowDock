using Jamesnet.Wpf.Controls;
using System.Windows.Input;

namespace WindowDock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : JamesWindow
    {
        public MainWindow()
        {
            InitializeComponent ();
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            //this.PreviewMouseLeftButtonDown += MainWindow_PreviewMouseLeftButtonDown;
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove ();
        }
    }
}
