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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZoldsegekZaro
{
    public partial class FormUj : Form
    {
        MySqlConnection conn = null;
        MySqlCommand cmd = null;
        public FormUj()
        {
            InitializeComponent();
        }

        private void FormUj_Load(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Adjon meg egy azonosítót(ID)");
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Adjon meg egy nevet");
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Adjon meg egy egységárat");
                textBox3.Focus();
                return;

            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Adjon meg egy mennyiséget");
                textBox4.Focus();
                return;

            }


            cmd.CommandText = "INSERT INTO `zoldsegek`(`id`, `nev`, `egysegar` ,`mennyiseg`) VALUES (@id, @nev, @Egyseg ,@mennyiseg)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@nev", textBox3.Text);
            cmd.Parameters.AddWithValue("@Egyseg", textBox2.Text);
            cmd.Parameters.AddWithValue("@mennyiseg", textBox4.Text);
            conn.Open();
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sikeres adatrözgítés!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";

                    
                }
                else
                {
                    MessageBox.Show("sikertelen adatrögzítés, próbálja újra.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
