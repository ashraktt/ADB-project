using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dates_Factory
{
    public partial class login : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=factor;uid=root;pwd=rootroot");
        MySqlCommand cmd;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select count(*) from admin where username = '" + textBox1.Text + "' and pass = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    this.Hide();
                    Home home = new Home();
                    home.Show();
                }

                else
                {
                    MessageBox.Show(" INVALID LOGIN  :( \n TRY AGAIN ^^  ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Login Form :( ");

            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
