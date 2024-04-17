using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    /*
    @Author WhyY0u CHECK NAME GITHUB
    The code is not for commercial use
    */
    static class Program
    {

        //public const string connectionString = "Data Source=DESKTOP-400BU96\\SQLEXPRESS;Initial Catalog=Session1;Integrated Security=True";
        public const string connectionString = "Data Source=WIN-0B908PJ6FUC;Initial Catalog=Session1;Integrated Security=True";


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
