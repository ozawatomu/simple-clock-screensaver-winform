using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClockScreensaver
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
            if (args.Length > 0)
            {
                string arg = args[0].ToUpperInvariant().Trim().Substring(0, 2);
                switch (arg)
                {
                    case "/C":
                        // Options
                        ShowOptions();
                        break;
                    case "/P":
                        // Preview
                        //ShowScreenSaver();
                        break;
                    case "/S":
                        // Screensaver
                        ShowScreenSaver();
                        break;
                    case "/D":
                        // Screensaver debug
                        ShowScreenSaver();
                        break;
                    default:
                        MessageBox.Show("Invalid command line argument: " + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                ShowScreenSaver();
            }
		}

        static void ShowScreenSaver()
        {
            Application.Run(new ScreensaverForm());
        }

        static void ShowOptions()
        {
            Application.Run(new ScreensaverOptionsForm());
        }
	}
}
