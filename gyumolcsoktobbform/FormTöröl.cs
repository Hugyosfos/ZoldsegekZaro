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
    public partial class FormTöröl : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd = null;
        public FormTöröl()
        {
            InitializeComponent();
        }

        private void FormTöröl_Load(object sender, EventArgs e)
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
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            cmd.CommandText = "DELETE FROM `zoldsegek` WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nev", textBox3.Text);
            cmd.Parameters.AddWithValue("@Egysegar", textBox2.Text);
            cmd.Parameters.AddWithValue("@Meret", textBox4.Text);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Sikeresen törlés!");
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

             
            }
            else
            {
                MessageBox.Show("sikertelen  törlés!");
            }

        }
    }
}
