using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GestionLocation
{
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void populate()
        {

            con.Open();

            string query = "select * from CarTbl ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CardDGV.DataSource = ds.Tables[0];


            con.Close();


        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (RegNoTb.Text == "" || Brand.Text == "" || Model.Text == ""||Price.Text=="")
            {

                MessageBox.Show("Manque d'information");

            }
            else
            {
                try
                {
                    con.Open();

                    string query = "insert into CarTbl values ('" + RegNoTb.Text + "','" + Brand.Text + "','" + Model.Text + "','"+Disponibilite.SelectedItem.ToString()+"',"+Price.Text+")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Voiture cree avec success");

                    con.Close();
                    populate();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void fillAvailable()
        {

            con.Open();

            string query = "select Available from CarTbl  ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Available", typeof(string));

            dt.Load(rdr);

            Search.ValueMember = "Available";
            Search.DataSource = dt;



            con.Close();

        }


        private void Car_Load(object sender, EventArgs e)
        {
            populate();
           // fillAvailable();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (RegNoTb.Text == "")
            {


                MessageBox.Show("Missing information");

            }
            else
            {

                try
                {
                    con.Open();
                    string query = "delete from CarTbl where RegNum='" + RegNoTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Deleted Successfully");

                    con.Close();
                    populate();


                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }

            }
        }

        private void CardDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegNoTb.Text = CardDGV.SelectedRows[0].Cells[0].Value.ToString();
            Brand.Text = CardDGV.SelectedRows[0].Cells[1].Value.ToString();
            Model.Text = CardDGV.SelectedRows[0].Cells[2].Value.ToString();
            Disponibilite.SelectedItem = CardDGV.SelectedRows[0].Cells[3].Value.ToString();
            Price.Text = CardDGV.SelectedRows[0].Cells[4].Value.ToString();


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (RegNoTb.Text == "" || Brand.Text == "" || Model.Text == "" || Price.Text == "")
            {

                MessageBox.Show("Manque d'information");

            }
            else
            {

                try
                {

                    con.Open();

                    string query = "update CarTbl set Brand= '" + Brand.Text + "',Model='" + Model.Text + "', Available='"+Disponibilite.SelectedItem.ToString()+"', Price = "+Price.Text+" where RegNum='" + RegNoTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car mise a jour avec success");

                    con.Close();
                    populate();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void Search_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string flag = "";
            if(Search.SelectedItem.ToString() == "Available")
            {
                flag = "Yes";

            }
            else
            {

                flag = "No";

            }

            con.Open();

            string query = "select * from CarTbl where Available = '"+ flag +"' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CardDGV.DataSource = ds.Tables[0];


            con.Close();



        }
    }
}
