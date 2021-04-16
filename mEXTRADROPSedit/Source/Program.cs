using System;
using System.Windows.Forms;
using mEXTRADROPSedit.Core;
using mEXTRADROPSedit.UI;

namespace mEXTRADROPSedit
{
    internal static class Program
    {
        public static string Path = "new";

        public static ExtraDropTable Table = new ExtraDropTable();

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}