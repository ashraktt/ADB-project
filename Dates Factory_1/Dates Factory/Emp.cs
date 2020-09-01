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
    public partial class Emp : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=factor;uid=root;pwd=rootroot");
        MySqlCommand cmd;
        public Emp()
        {
            InitializeComponent();
            
        }

      

        private void Emp_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from employee ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                cmd = new MySqlCommand("INSERT INTO employee (e_name,e_address,e_phone) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from employee ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("ERROR IN ADD");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in employee Form ADD :( ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataGridViewRow selectR = dataGridView1.Rows[ind];
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from employee where e_id = " + int.Parse(selectR.Cells[0].Value.ToString());
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from employee ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                 
                    con.Close();
                }
                else
                {
                    MessageBox.Show("ERROR IN delete");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in employee Form delete :( ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataGridViewRow selectR = dataGridView1.Rows[ind];

                MySqlCommand cmd = new MySqlCommand("update employee set e_name = '" + textBox1.Text + "' , e_address='" + textBox2.Text + "' ,e_phone='" + textBox3.Text + "' where e_id = " + int.Parse(selectR.Cells[0].Value.ToString()), con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from employee ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";


                }
                else
                {
                    MessageBox.Show("ERROR IN update");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in employee Form update :( ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home emp = new Home();
            emp.Show();
        }
        public int ind;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            ind = index;
            DataGridViewRow selectR = dataGridView1.Rows[index];
            textBox1.Text = selectR.Cells[1].Value.ToString();
            textBox2.Text = selectR.Cells[2].Value.ToString();
            textBox3.Text = selectR.Cells[3].Value.ToString();
        }
    }
}
