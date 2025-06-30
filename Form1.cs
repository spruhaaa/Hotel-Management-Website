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

namespace HospitalManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=");
            con.Open();
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            SqlCommand cmd = new SqlCommand("select username,password from logintab where Username='" + txtUsername.Text + "'and Password='" + txtPassword.Text + ", con");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();
        }
    }
}
