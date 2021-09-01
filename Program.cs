//David Norvell
//OCCC C# Spring 2021 Online
//program.cs

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_CS2563_DavidNorvell
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static StringBuilder username;
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //We could just hide these, but leaving z0mbie windows sucking down CPU time is just horrible practice. So we have a boolean with a public getter that'll help us here. 
            //If login is successful, we nuke the instance of LoginForm below, close and dispose of it properly.
            //If they hit register, we do the same but send them to the registration form instead of the main menu.

            LoginForm a = new LoginForm();
            Application.Run(a);

            if (a.isSuccess == true)
            {
                pchrMainMenu b = new pchrMainMenu();
                Application.Run(b);
            }
            else if (a.isRegister == true)
            {
                Registration c = new Registration();
                Application.Run(c);
            }
        }

      
    }
}
