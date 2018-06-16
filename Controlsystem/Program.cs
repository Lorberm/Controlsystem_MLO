using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing;
using System.Diagnostics;
using System.Security.Principal;

namespace Controlsystem
{
    static class Program
    {
        //added check for admin later on
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsIdentity  identity  = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("MLO_Control not running as an admin! You might not be able to use some functions, i.e. the Net-Feature");
            }

            Application.Run(new Form1());
        }
    }
}
