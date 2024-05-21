using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using WindowDock.Main.Local.Models;

namespace WindowDock.Main.Local.Extentions
{
    public static class ModelExtentions
    {
        public static List<QuickBaseIcon> Change(this List<QuickIcon> list)
        {
            List<QuickBaseIcon> result = new ();
            foreach (var dropModel in list)
            {
                result.Add (new QuickBaseIcon ()
                {
                    ToolTipName = dropModel.ToolTipName,
                    FullPath = dropModel.FullPath,
                    Type = dropModel.Type,
                });
            }

            return result;
        }
        public static List<QuickIcon> Change(this List<QuickBaseIcon> list)
        {
            List<QuickIcon> result = new ();
            foreach (var dropModel in list)
            {
                result.Add (new QuickIcon ()
                {
                    Type = dropModel.Type,
                    ToolTipName = dropModel.ToolTipName,
                    FullPath = dropModel.Type == LinkType.Program? dropModel.FullPath : null,
                    FileImage = dropModel.Type == LinkType.Program ? dropModel.FullPath.Convert() : null
                });
            }

            return result;
        }

        public static BitmapImage Convert(this string fileName)
        {
            Bitmap bitmap = (Bitmap)Icon.ExtractAssociatedIcon (fileName).ToBitmap ();
            MemoryStream ms = new MemoryStream ();
            ((System.Drawing.Bitmap)bitmap).Save (ms, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage image = new BitmapImage ();
            image.BeginInit ();
            ms.Seek (0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit ();
            return image;
        }
    }
}
