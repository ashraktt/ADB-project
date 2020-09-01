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

namespace Dates_Factory
{
    public partial class update_sup : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=factor;uid=root;pwd=rootroot");
        MySqlCommand cmd;
        public update_sup()
        {
            InitializeComponent();
        }

        private void update_sup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int pr = int.Parse(textBox4.Text) * int.Parse(textBox5.Text);
                cmd = new MySqlCommand("update suppliers set quan_goods = '" + textBox4.Text + "', price_per_kilo = " + float.Parse(textBox5.Text.ToString()) + ",s_money= " +pr + " where s_id = " + int.Parse(textBox1.Text),con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                }
                else
                    MessageBox.Show("ERROR IN insert into store");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR IN update_emp"); con.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
