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
namespace GestionLocation
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sados\Documents\GestionLocationDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(Uid.Text== "" || Uname.Text =="" || Upass.Text == "")
            {

                MessageBox.Show("Manque d'information");

            }
            else
            {

                try
                {

                    con.Open();

                    string query = "insert into UserTbl values (" + Uid.Text + ",'" + Uname.Text + "','" + Upass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query , con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Utilisateur cree avec success");

                    con.Close();
                    populate();

                }
                catch(Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {

            con.Open();

            string query = "select * from UserTbl ";
            SqlDataAdapter da = new SqlDataAdapter(query , con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];


            con.Close() ;


        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if(Uid.Text == "")
            {


                MessageBox.Show("Missing information");

            }else
            {

                try
                {
                    con.Open();
                    string query = "delete from UserTbl where Id=" + Uid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query , con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully");

                    con.Close();
                    populate();


                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }

            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || Uname.Text == "" || Upass.Text == "")
            {

                MessageBox.Show("Manque d'information");

            }
            else
            {

                try
                {

                    con.Open();

                    string query = "update UserTbl set Uname= '" + Uname.Text + "',Upass='" + Upass.Text + "' where Id=" + Uid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Utilisateur mise a jour avec success");

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
    }
}
