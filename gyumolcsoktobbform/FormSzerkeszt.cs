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
    public partial class FormSzerkeszt : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd = null;

        public FormSzerkeszt()
        {
            InitializeComponent();
        }
        

        private void FormSzerkeszt_Load(object sender, EventArgs e)
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
           
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE `zoldsegek` SET `nev`= @nev,`egysegar`= @Egyseg,`mennyiseg`= @Meret WHERE `id` = @id";
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nev", textBox2.Text);
            cmd.Parameters.AddWithValue("@Egyseg", textBox3.Text);
            cmd.Parameters.AddWithValue("@mennyiseg", textBox4.Text);
            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Módosítás sikeres votl!");
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

            }
            else
            {
                MessageBox.Show("Az adatok módosítása sikertelen!");
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
