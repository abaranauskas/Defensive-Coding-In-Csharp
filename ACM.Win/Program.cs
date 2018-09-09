using System;
using System.Threading;
using System.Windows.Forms;

namespace ACM.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //=======================================================================================
            //globalus exception handler jis skiriasi pagal aplikacijos tipa sis 
            //skirtas windowsForms

            //for UI thread exceptions
            Application.ThreadException += 
                                new ThreadExceptionEventHandler(GlobalExceptionHandler);

            //Force allWindows Forms errors to go through our handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //For non-UI thread exeptions
            AppDomain.CurrentDomain.UnhandledException +=
                                new UnhandledExceptionEventHandler(GlobalExceptionHandler);


            //=======================================================================================
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PedometerWin());
        }

        static void GlobalExceptionHandler(object sender, EventArgs e)
        {
            //log issue
            MessageBox.Show("Buvo problema su applilkacija. Susisiekite su suportu!");
            System.Windows.Forms.Application.Exit();
        }
    }
}
