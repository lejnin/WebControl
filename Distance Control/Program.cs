using System;
using System.Windows.Forms;

namespace WebControlApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GeneralForm form = new GeneralForm();
            Application.Run(form);
        }
    }

}
