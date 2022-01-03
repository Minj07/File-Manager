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

            LoginForm loginForm;
            MainForm mainForm;

            DialogResult result;

            do
            {
                loginForm = new LoginForm();
                Application.Run(loginForm);
                if (loginForm.DialogResult != DialogResult.OK)
                {
                    break;
                }

                Database.User user = loginForm.user;
                mainForm = new MainForm(user);
                Application.Run(mainForm);
                result = mainForm.DialogResult;

            } while (result == DialogResult.OK);
            

        }
    }
}
