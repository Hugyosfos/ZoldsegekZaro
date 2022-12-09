using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ZoldsegekZaro
{
    internal static class Program
    {
        static public FormTöröl formtöröl = null;
        static public Form1 form1 = null;
        static public FormUj formruj = null;
        static public FormSzerkeszt formSzerkeszt = null;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formtöröl = new FormTöröl();
            form1 = new Form1();
            formruj = new FormUj();
            formSzerkeszt = new FormSzerkeszt();
            Application.Run(form1);
        }
    }
}
