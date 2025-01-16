using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Grifindo_Travels_Systam
{
    public partial class _2_Login : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-26JBM5S;Initial Catalog=Grifindo_Travels_Systam;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        public _2_Login()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome obj = new Welcome();
            obj.Show();
        }

        private void checkBox_Password_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Password.Checked == false)
                txtPassword.UseSystemPasswordChar = true;

            else
                txtPassword.UseSystemPasswordChar = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM Sing_Up WHERE UserName='" + txtUName.Text + "' and Password1='" + txtPassword.Text + "'", conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i == 1)
            {

                MessageBox.Show("Welcome to Grifindo Travels System");

            }
            else
            {
                MessageBox.Show("Invalid Login !!! Try Again", "password", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

            this.Hide();
            _2_Home frm = new _2_Home();
            frm.Show();
        }
    }
}
