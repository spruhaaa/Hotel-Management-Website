using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sql.Data.SqlClient;


namespace HospitalManagement
{
    public partial class Department : Form
    {
        private object dt;

        public Department()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=");
            con.Open();
            SqlCommand cmd = SqlCommand("insert into deptab values(@deptid,@deptname,@phone)",con);
            cmd.Parameters.AddWithValue("@Deptid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Deptname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!")


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=");
            con.Open();
            SqlCommand cmd = SqlCommand("update deptab set deptname=@deptname,phone-@phone)", con);
            cmd.Parameters.AddWithValue("@Deptid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Deptname", textBox2.Text);
            cmd.Parameters.AddWithValue("@Phone", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=");
            con.Open();
            SqlCommand cmd = SqlCommand("Select * from deptab",con);
            SqlDataAdapter da = new DataTable(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
              }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=");
            con.Open();
            SqlCommand cmd = SqlCommand("delete deptab where deptid=@deptid", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Are you sure you want to delete?");
        }

        private void display_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=");
            con.Open();
            SqlCommand cmd = SqlCommand("select * from deptab", con);
            DataTable dt = new DataTable(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Department_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=");
            con.Open();
            SqlCommand cmd = SqlCommand("select * from deptab", con);
            SqlDataAdapter da = new DataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
