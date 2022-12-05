using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GestionLocation
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sados\Documents\GestionLocationDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {

            con.Open();

            string query = "select * from CustomerTbl ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];


            con.Close();


        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || AdressTb.Text == "")
            {

                MessageBox.Show("Manque d'information");

            }
            else
            {
                try
                {
                    con.Open();

                    string query = "insert into CustomerTbl values (" + IdTb.Text + ",'" + CustNameTb.Text + "','" + AdressTb.Text + "','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");

                    con.Close();
                    populate();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }


        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {


                MessageBox.Show("Missing information");

            }
            else
            {

                try
                {
                    con.Open();
                    string query = "delete from CustomerTbl where CustId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");

                    con.Close();
                    populate();


                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }

            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
            CustNameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();

            AdressTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || AdressTb.Text == "" || PhoneTb.Text == "")
            {

                MessageBox.Show("Manque d'information");

            }
            else
            {

                try
                {

                    con.Open();

                    string query = "update CustomerTbl set CustName= '" + CustNameTb.Text + "',CustAdd='" + AdressTb.Text + "', Phone='" + PhoneTb.Text + "' where CustId='" + IdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer mise a jour avec success");

                    con.Close();
                    populate();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}
