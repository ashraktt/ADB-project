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
    public partial class supler : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;database=factor;uid=root;pwd=rootroot");
        MySqlCommand cmd;
        public supler()
        {
            InitializeComponent();
        }

        private void supler_Load(object sender, EventArgs e)
        {
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from suppliers ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                
                int pr = int.Parse(textBox4.Text) * int.Parse(textBox5.Text);
                textBox6.Text = pr.ToString();
                cmd = new MySqlCommand("insert into suppliers (s_name,s_address,s_phone,quan_goods,price_per_kilo ,s_money) values ( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'," + pr + " ) ", con);


                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from suppliers ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                }
                else
                {
                    MessageBox.Show("ERROR IN ADD");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Supplier Form ADD :( ");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
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
            textBox4.Text = selectR.Cells[4].Value.ToString();
            textBox5.Text = selectR.Cells[5].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
               
                DataGridViewRow selectR = dataGridView1.Rows[ind];
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from suppliers where s_id = " + int.Parse(selectR.Cells[0].Value.ToString());
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from suppliers ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    con.Close();
                }
                else
                {
                    MessageBox.Show("ERROR IN delete");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Supplier Form delete :( ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataGridViewRow selectR = dataGridView1.Rows[ind];
                cmd.CommandType = CommandType.Text;
                
                cmd.CommandText = "update suppliers set s_name ='" + textBox1.Text + "', s_address ='" + textBox2.Text + "', s_phone='" + textBox3.Text + "' , quan_goods='" + textBox4.Text + "', price_per_kilo =" + float.Parse(textBox5.Text.ToString()) + " where s_id =" + int.Parse(selectR.Cells[0].Value.ToString());
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("DONE");
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from suppliers ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    con.Close();
                }
                else
                {
                    MessageBox.Show("ERROR IN update");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Supplier Form update :( ");
            }
        }
    }
}
