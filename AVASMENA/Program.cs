using AVASMENA.API;

namespace AVASMENA
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Loggers.Logger.CheackAndCreaterFile();
            if (Task.Run(() => UpdateVersionCheck.MainVersion()).GetAwaiter().GetResult())
            {
                Application.Run(new MainForms.MainForm());
            }
        }
    }
}