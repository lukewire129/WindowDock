using IWshRuntimeLibrary;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using WindowDock.Main.Local.Models;

namespace WindowDock.Main.Local.Common
{
    public class IConService
    {
        private readonly string _directory;

        public IConService(string directory)
        {
            this._directory = directory;
        }

        public List<QuickIcon> GetFiles()
        {
            List<string> files = GetRootPath ();
            List<QuickIcon> quickFiles = new List<QuickIcon> ();

            foreach (var file in files)
            {
                quickFiles.Add (new QuickIcon ()
                {
                    Type = LinkType.Program,
                    FileImage = Convert ((Bitmap)Icon.ExtractAssociatedIcon (file).ToBitmap ()),
                    FullPath = file,
                    ToolTipName = Path.GetFileNameWithoutExtension (file)
                });
            }

            quickFiles.Add (new ()
            {
                Type = LinkType.Option,
                ToolTipName = "옵션"
            });

            return quickFiles;
        }
        private List<string> GetRootPath()
        {
            List<string> files = Directory.GetFiles (this._directory, "*.lnk").ToList ();

            List<string> tempFullPath = new List<string> ();
            foreach (var file in files)
            {
                WshShell shell = new WshShell ();
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut (file);
                if (string.IsNullOrEmpty (link.TargetPath))
                    continue;
                if (link.TargetPath.ToLower ().Contains ("update"))     // update 시작하는 바로가기는 제외
                    continue;
                if (link.TargetPath.ToLower ().Contains ("proxy"))     // proxy 시작하는 바로가기는 제외
                    continue;
                tempFullPath.Add (link.TargetPath);
            }

            return tempFullPath;
        }

        private BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream ();
            ((System.Drawing.Bitmap)src).Save (ms, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage image = new BitmapImage ();
            image.BeginInit ();
            ms.Seek (0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit ();
            return image;
        }
    }
}
