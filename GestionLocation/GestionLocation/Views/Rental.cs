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
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

namespace GestionLocation
{
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sados\Documents\GestionLocationDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void fillcombo()
        {

            Con.Open();

            string query = "select RegNum from CarTbl where Available ='"+"Yes"+"' ";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));

            dt.Load(rdr);

            CarRenCb.ValueMember = "RegNum";
            CarRenCb.DataSource= dt;



            Con.Close();

        }

        private void fillCustomer()
        {

            Con.Open();

            string query = "select CustId from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));

            dt.Load(rdr);

            CustCb.ValueMember = "CustId";
            CustCb.DataSource = dt;



            Con.Close();

        }

        private void fetchCustName()
        {
               
            Con.Open();
            string query = "select * from CustomerTbl where CustId = "+CustCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {

                CustNameTb.Text = dr["CustName"].ToString();

            }
            Con.Close() ;

        }

        private void populate()
        {

            Con.Open();

            string query = "select * from RentalTbl ";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentalDGV.DataSource = ds.Tables[0];


            Con.Close();


        }

        private void UpdateonRent()
        {
            Con.Open();
            string query = "update CarTbl set Available='" + "No" + "' where RegNum='" + CarRenCb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Car mise a jour avec success");

            Con.Close();


        }

        private void UpdateonRentDelete()
        {
            Con.Open();
            string query = "update CarTbl set Available='" + "Yes" + "' where RegNum='" + CarRenCb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Car mise a jour avec success");

            Con.Close();


        }


        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }

        private void CardDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentalDGV.SelectedRows[0].Cells[0].Value.ToString();
            CarRenCb.SelectedValue = RentalDGV.SelectedRows[0].Cells[1].Value.ToString();
           // CustNameTb.Text = RentalDGV.SelectedRows[0].Cells[3].Value.ToString();
            FeesTb.Text =RentalDGV.SelectedRows[0].Cells[5].Value.ToString();


        }

        private void CarRenCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || FeesTb.Text == "")
            {

                MessageBox.Show("Manque d'information");

            }
            else
            {
                try
                {
                    Con.Open();

                    string query = "insert into RentalTbl values (" + IdTb.Text + ",'" + CarRenCb.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + RentalDate.Value + "','" +ReturDate.Value+ "',"+FeesTb.Text+" )";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Rented");

                    Con.Close();
                    UpdateonRent();
                    populate();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
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
                    Con.Open();
                    string query = "delete from RentalTbl where RentId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Deleted Successfully");

                    Con.Close();
                    UpdateonRentDelete();
                    populate();



                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }

            }
        }
    }
}
