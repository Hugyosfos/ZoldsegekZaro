using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZoldsegekZaro
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd = null;
        public Form1()
        {

            InitializeComponent();
        }

        private void szerkesztToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formSzerkeszt.Show();
        }

        private void törölToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formtöröl.Show();
        }

        private void újAdatMegadásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formruj.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "zoldsegek";
            conn = new MySqlConnection(builder.ConnectionString);
            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message + Environment.NewLine + "A program leáll");

                Environment.Exit(0);
            }
            finally
            {
                conn.Close();
            }
            listBox1_update();
           
        }

        private void listBox1_update()
        {

            listBox1.Items.Clear();
            cmd.CommandText = "SELECT * FROM `zoldsegek`;";
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dr.Read();
                Zoldsegek uj = new Zoldsegek(dr.GetInt32("id"), dr.GetString("nev"), dr.GetDouble("egysegar"), dr.GetDouble("mennyiseg"));
                listBox1.Items.Add(uj);
               
            }
            conn.Close();
            
        }
       
    }
}
