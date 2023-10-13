using System.Windows.Media;

namespace WindowDock.Local.Models
{
    public enum LinkType
    {
        Program,
        Add,
    }
    public class QuickIcon
    {
        public LinkType Type { get; set; } = LinkType.Add;
        public ImageSource FileImage { get; set; }
        public string FullPath { get; set; }
        public string ToolTipName { get; set; }
    }
}
