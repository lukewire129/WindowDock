using System.Windows.Media;

namespace WindowDock.Local.Models
{
    public enum LinkType
    {
        Program,
        None,
    }
    public class QuickFile
    {
        public LinkType Type { get; set; } = LinkType.None;
        public ImageSource FileImage { get; set; }
        public string FullPath { get; set; }
        public string ToolTipName { get; set; }
    }
}
