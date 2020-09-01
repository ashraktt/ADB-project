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
    public partial class update_emp : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;database=factor;uid=root;pwd=rootroot");
        MySqlCommand cmd;
        public update_emp()
        {
            InitializeComponent();
        }

        private void update_emp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("insert into emp_pro(e_id, p_id, pro_quan, type_name ) values (" + int.Parse(textBox3.Text) + "," + int.Parse(textBox1.Text) + "," + int.Parse(textBox2.Text) + ",'" + comboBox1.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                }
                else
                    MessageBox.Show("ERROR IN insert into store");

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR IN update_emp"); con.Close();


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
