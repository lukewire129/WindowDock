using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using WindowDock.Main.Local.Models;

namespace WindowDock.Main.UI.Units
{
    public class QuickList : ListBox
    {
        public ICommand DropFileCommand
        {
            get { return (ICommand)GetValue (DropFileCommandProperty); }
            set { SetValue (DropFileCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DropFileCommandProperty =
            DependencyProperty.Register ("DropFileCommand", typeof (ICommand), typeof (QuickList), new PropertyMetadata (null));
        static QuickList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickList), new FrameworkPropertyMetadata(typeof(QuickList)));
        }

        public QuickList()
        {
            AllowDrop = true;
            DragEnter += DropBox_DragEnter;
            DragLeave += DropBox_DragLeave;
            DragOver += DropBox_DragOver;
            Drop += DropBox_Drop;
        }

        private void DropBox_Drop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData (DataFormats.FileDrop);

            DropFileCommand?.Execute (new QuickIcon ()
            {
                Type = LinkType.Program,
                FullPath = data[0],
                ToolTipName = Path.GetFileNameWithoutExtension (data[0])
            });
        }

        private void DropBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent (typeof (ListBoxItem)))
            {
                e.Effects = DragDropEffects.Move;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DropBox_DragLeave(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
        }

        private void DropBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Move;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new QuickListItem ();
        }



        public Thickness ChildrenSpacing
        {
            get { return (Thickness)GetValue (ChildrenSpacingProperty); }
            set { SetValue (ChildrenSpacingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChildrenSpacing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChildrenSpacingProperty =
            DependencyProperty.Register ("ChildrenSpacing", typeof (Thickness), typeof (QuickList), new PropertyMetadata (new Thickness (10, 10, 10 ,10)));

        public void IsStyleChange(bool OnOff = false)
        {
            if(OnOff)
            {
                this.ChildrenSpacing = new Thickness (0, 0, 0, 0);
                return;
            }
            this.ChildrenSpacing = new Thickness (10, 10, 10, 10);
        }
    }
}
