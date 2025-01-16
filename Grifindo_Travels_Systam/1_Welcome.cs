using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Travels_Systam
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            ProgressBar1.Value = 0;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            this.Hide();
            _2_Login frm = new _2_Login();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Value += 1;
            ProgressBar1.Text = ProgressBar1.Value.ToString() + "%";
            if (ProgressBar1.Value == 100)
            {
                timer1.Enabled = false; 
            }
        }
    }
}
