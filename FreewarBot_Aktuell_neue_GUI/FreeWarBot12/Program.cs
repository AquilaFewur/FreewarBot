namespace FreeWarBot12
{
    using System;
    using System.Windows.Forms;
    using System.Threading;

    internal static class Program
    {
        [STAThread]

   
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        
            
            Application.Run(new frmLogin());
        }
        
    }
}

