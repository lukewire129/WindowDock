using System;
using WindowDock.Properties;

namespace WindowDock
{
    public class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App ()
                    .AddInversionModule<ViewModules> ()
                    .AddInversionModule<DirectModules> ()
                    .AddWireDataContext<WireDataContext> ()
                    .Run ();
        }
    }
}
