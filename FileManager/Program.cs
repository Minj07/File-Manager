using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
            Database.User user = loginForm.user;
            if (user != null)
            {
                Application.Run(new MainForm(user));
            }


        }
    }
}
