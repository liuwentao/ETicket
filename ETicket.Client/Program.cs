using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ETicket.Client;
using System.IO;

namespace ETicket.Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new EnterFrm());
          
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception == null)
            {
                return;
            }
            using (var writer = new StreamWriter(@"c:\ticket.log"))
            {
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss>>") + e.Exception.Message);
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss>>") + e.Exception.StackTrace);
            }
        }
    }
}
