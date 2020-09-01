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
    public partial class store : Form
    {

        MySqlConnection con = new MySqlConnection("server=localhost;database=factor;uid=root;pwd=rootroot");
        MySqlCommand cmd;
        public store()
        {
            InitializeComponent();
        }

        private void store_Load(object sender, EventArgs e)
        {
            //con.Open();
            //cmd = new MySqlCommand("SELECT max(quan_goods) FROM notready", con);
            //MySqlDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            //textBox1.Text = dr.GetValue(0).ToString();
            //dr.Close();

            //MySqlDataAdapter da = new MySqlDataAdapter("select * from ready ", con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;

            //con.Close();

        }
    }
}
