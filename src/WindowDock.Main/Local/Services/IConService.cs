using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using WindowDock.Main.Local.Extentions;
using WindowDock.Main.Local.Models;

namespace WindowDock.Main.Local.Services
{
    public partial class IConService
    {
        private readonly string _directory;

        public IConService()
        {
            _directory = $"{Environment.GetFolderPath (System.Environment.SpecialFolder.ApplicationData)}\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\";
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
                    FileImage = file.Convert(),
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
    }
}
