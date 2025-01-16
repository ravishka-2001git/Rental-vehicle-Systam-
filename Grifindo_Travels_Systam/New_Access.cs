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
    public partial class New_Access : Form
    {
        public New_Access()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-26JBM5S;Initial Catalog=Grifindo_Travels_Systam;Integrated Security=True");

        private void btnNewLogin_Save_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Insert into User_login(Full_Name,UserName,Password1,Confirm)Values(@Name,@UserName,@Password,@Confirm)", conn);
            cmd2.Parameters.AddWithValue("Name", txtLogin_Name.Text);
            cmd2.Parameters.AddWithValue("UserName", txtLogin_AddUserName.Text);
            cmd2.Parameters.AddWithValue("Password", txtLogin_AddPassword.Text);
            cmd2.Parameters.AddWithValue("Confirm", txtLogin_AddConfirm.Text);
            if (txtLogin_Name.Text != string.Empty || txtLogin_AddUserName.Text != string.Empty || txtLogin_AddPassword.Text != string.Empty || txtLogin_AddConfirm.Text != string.Empty)
            {
                if (txtLogin_AddPassword.Text == txtLogin_AddConfirm.Text)
                {
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Added a new Login Access");
                    conn.Close();
                    Bind_data_New_Login();
                }
                else
                {
                    MessageBox.Show("Please Enter the Both Password Same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Eomplete Every Column", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }
        private void Bind_data_New_Login()
        {
            SqlCommand cmd1 = new SqlCommand("Select Full_Name As Name,UserName,Password1 As Password,Confirm from User_login", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView_Login.DataSource = dt;
            dataGridView_Login.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
        }

        private void New_Access_Load(object sender, EventArgs e)
        {
            Bind_data_New_Login();
        }

        private void btnNewLogin__New_Click(object sender, EventArgs e)
        {
            txtLogin_Name.Text = "";
            txtLogin_AddUserName.Text = "";
            txtLogin_AddPassword.Text = "";
            txtLogin_AddConfirm.Text = "";
            txt_LoginSearch.Text = "";
        }

        private void btnNewLogin__Update_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("Update User_login set Full_Name=@Name,UserName=@UserName,Password1=@Password,Confirm=@Confirm where Full_Name=@Name", conn);

            cmd3.Parameters.AddWithValue("UserName", txtLogin_AddUserName.Text);
            cmd3.Parameters.AddWithValue("Password", txtLogin_AddPassword.Text);
            cmd3.Parameters.AddWithValue("Confirm", txtLogin_AddConfirm.Text);
            cmd3.Parameters.AddWithValue("Name", txtLogin_Name.Text);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();
            Bind_data_New_Login();
        }

        private void dataGridView_Login_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView_Login.Rows[index];
            txtLogin_Name.Text = selectedrow.Cells[0].Value.ToString();
            txtLogin_AddUserName.Text = selectedrow.Cells[1].Value.ToString();
            txtLogin_AddPassword.Text = selectedrow.Cells[2].Value.ToString();
            txtLogin_AddConfirm.Text = selectedrow.Cells[3].Value.ToString();
        }

        private void btnNewLogin__Delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Delete from User_login where Full_Name=@Name", conn);
            cmd4.Parameters.AddWithValue("Name", txtLogin_Name.Text);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            Bind_data_New_Login();
        }

        private void btnNewLogin__Search_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Select Full_Name As Name,UserName,Password1 As Password,Confirm from User_login where UserName like @UserName+'%'", conn);
            cmd1.Parameters.AddWithValue("UserName", txt_LoginSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView_Login.DataSource = dt;
            dataGridView_Login.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
        }
    }
}
