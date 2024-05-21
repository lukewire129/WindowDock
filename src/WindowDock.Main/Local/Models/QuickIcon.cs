using System.Windows.Media;

namespace WindowDock.Main.Local.Models
{
    public enum LinkType
    {
        Program,
        Option,
    }
    public class QuickIcon : QuickBaseIcon
    {
        public ImageSource FileImage { get; set; }
    }

    public class QuickBaseIcon
    {
        public LinkType Type { get; set; } = LinkType.Option;
        public string FullPath { get; set; }
        public string ToolTipName { get; set; }
    }
}
