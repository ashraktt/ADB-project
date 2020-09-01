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
    public partial class update_store : Form
    {
        public update_store()
        {
            InitializeComponent();
        }

        private void update_store_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_emp emp = new update_emp();
            emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_sup sup = new update_sup();
            sup.Show();
        }
    }
}
