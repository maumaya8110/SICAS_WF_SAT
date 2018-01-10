using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace AutoUpdater
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Splash splash = new Splash("AppImage.jpg");
                    splash.Show();
                    Utils.pb = splash.AutoUpProgressBar;
                    Application.DoEvents();

                    Updater up = new Updater();

                    up.AppUpdate();
                    //Application.DoEvents();

                    splash.Close();
                }
                else
                {
                    if (args[0] == "--s")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new AutoUpdater.SettingsForm());
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message);
                MessageBox.Show(ex.Message, "Mensaje de advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }   //  End void main
    }   //  End Class
}   //  End Namespace
