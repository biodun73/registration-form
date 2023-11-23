using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace insertand_fetchdata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }


        SqlConnection conn = new SqlConnection("Data Source=ABIODUN\\JOHNSERVER;Initial Catalog=worker;Integrated Security=True;Encrypt=False");


        private void button1_Click(object sender, EventArgs e)
        {


            SqlCommand cmd;
            string workerid = txtWorker.Text;
            string firstname = txtFirstname.Text;
            string lastname = txtLastname.Text;
            string status = cboBox.SelectedItem.ToString();
            string address = txtAddress.Text;
            string mail = txtMail.Text;
            try
            {

                conn.Open();
                cmd = new SqlCommand(@"INSERT INTO[dbo].[workers]([workerid],[firstname],[lastname],[status],[address],[mail])VALUES('" + workerid + "','" + firstname + "', '" + lastname + "', '" + status + "', '" + address + "', '" + mail + "') ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Inserted", "Error detected", MessageBoxButtons.YesNo);
                getData();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void getData()
        {
            conn = new SqlConnection("Data Source=ABIODUN\\JOHNSERVER;Initial Catalog=worker;Integrated Security=True;Encrypt=False");
            SqlCommand com = new SqlCommand(@"SELECT * FROM [dbo].[workers]", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void getUpdate()
        {
            string workerid = txtWorker.Text;
            string firstname = txtFirstname.Text;
            string lastname = txtLastname.Text;
            string status = cboBox.SelectedItem.ToString();
            string address = txtAddress.Text;
            string mail = txtMail.Text;
            conn = new SqlConnection("Data Source=ABIODUN\\JOHNSERVER;Initial Catalog=worker;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand com = new SqlCommand("UPDATE [dbo].[workers] SET[workerId] = '" + txtWorker.Text + "' , [firstname] = '" + txtFirstname.Text + "', [lastname] = '" + txtLastname.Text + "', [status] = '" + cboBox.SelectedItem.ToString() + "', [address] = '" + txtAddress.Text + "', [mail] = '" + txtMail.Text + "' WHERE [workerid]= '" + txtWorker.Text + "'  ", conn);
            com.ExecuteNonQuery();
            MessageBox.Show("Data Updated", "Error detected", MessageBoxButtons.YesNo);
            conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            getUpdate();
            getData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            getDelete();
            getData();

        }
        public void getDelete()
        {
            conn = new SqlConnection("Data Source=ABIODUN\\JOHNSERVER;Initial Catalog=worker;Integrated Security=True;Encrypt=False");
            conn.Open();
            SqlCommand com = new SqlCommand(@"DELETE FROM[dbo].[workers] WHERE [workerid]= '" + txtWorker.Text + "'" , conn);
            com.ExecuteNonQuery();
            MessageBox.Show("Data Deleted","",MessageBoxButtons.YesNo);
            conn.Close();

        }
    }
}

