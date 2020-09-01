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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Emp emp = new Emp();
            emp.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            supler emp = new supler();
            emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            dealer emp = new dealer();
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            store emp = new store();
            emp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_store emp = new update_store();
            emp.Show();
        }
    }
}
