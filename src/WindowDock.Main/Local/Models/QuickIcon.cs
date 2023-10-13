using System.Windows.Media;

namespace WindowDock.Main.Local.Models
{
    public enum LinkType
    {
        Program,
        Option,
    }
    public class QuickIcon
    {
        public LinkType Type { get; set; } = LinkType.Option;
        public ImageSource FileImage { get; set; }
        public string FullPath { get; set; }
        public string ToolTipName { get; set; }
    }
}
