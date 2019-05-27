using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;

namespace SP2_Tool
{
    public static class Program
    {
        public static readonly string ApplicationData = Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData);

        public static readonly string SP2ToolDir = Path.Combine(ApplicationData,
            "Hyper_Development_Team", "SP2 Tool");

        public static readonly string TempDir = Path.Combine(SP2ToolDir, "Temp");
        public static TempFileCollection TempData { get; private set; }

        public const string VersionString = "Version 0.1-alpha";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Create application data directories
            Directory.CreateDirectory(SP2ToolDir);
            Directory.CreateDirectory(TempDir);
            TempData = new TempFileCollection(TempDir, false);

            // Delete leftover data from TempDir
            foreach (var tempFile in Directory.GetFiles(TempDir))
            {
                File.Delete(tempFile);
            }

            // Start the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(args));

            // Delete all temporary data
            TempData.Delete();
        }
    }
}
