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
    public partial class dealer : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=factor;uid=root;pwd=rootroot");
        MySqlCommand cmd;
        public dealer()
        {
            InitializeComponent();
            //con.Open();
            //MySqlCommand cmd = new MySqlCommand("ShowT", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("tname", "dealers");
            //MySqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home emp = new Home();
            emp.Show();
        }

        private void dealer_Load(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from dealers ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name, add, phone;
                name = textBox1.Text;
                add = textBox2.Text;
                phone = textBox3.Text;
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO dealers(d_name,d_address,d_phone) VALUES('" + name + "', '" + add + "', '" + phone + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from dealers ", con);
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
                    MessageBox.Show("ERROR IN ADD");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in dealers Form ADD :( ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataGridViewRow selectR = dataGridView1.Rows[ind];

                //int x = int.Parse(selectR.Cells[0].Value.ToString());
                //MessageBox.Show(x.ToString());
                string name = textBox1.Text;
                string add = textBox2.Text;
                string phone = textBox3.Text;

                MySqlCommand cmd = new MySqlCommand("update dealers set d_name = '" + name + "' , d_address='" + add + "' ,d_phone='" + phone + "' where d_id = " + int.Parse(selectR.Cells[0].Value.ToString()),con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from dealers ", con);
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
                MessageBox.Show("Error in dealers Form update :( ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                DataGridViewRow selectR = dataGridView1.Rows[ind];
                MySqlCommand cmd = new MySqlCommand("delete from dealers where d_id = " + int.Parse(selectR.Cells[0].Value.ToString()),con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from dealers ", con);
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



                //string name, add, phone, id;

                // con.Open();
                //MySqlCommand cmd = new MySqlCommand("delete from dealers where d_id = " + 1, con);
                //cmd.ExecuteNonQuery();
                //MessageBox.Show("added");
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in dealers Form delete :( ");
            }
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
