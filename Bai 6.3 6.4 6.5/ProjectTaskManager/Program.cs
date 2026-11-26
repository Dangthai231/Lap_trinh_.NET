using System;
using System.Windows.Forms;
using ProjectTaskManager.GUI;

namespace ProjectTaskManager
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (args[0] == "--test")
                {
                    TestRunner.RunTests();
                    return;
                }
                if (args[0] == "--screenshot")
                {
                    ApplicationConfiguration.Initialize();
                    ScreenshotHelper.CaptureScreenshots();
                    return;
                }
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}
