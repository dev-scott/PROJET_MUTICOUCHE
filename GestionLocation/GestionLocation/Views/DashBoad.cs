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
    public partial class DashBoad : Form
    {
        public DashBoad()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void DashBoad_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CarLbl.Text = dt.Rows[0][0].ToString();


            string querycust = "select Count(*) from CustomerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycust, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            CustomerLbl.Text = dt1.Rows[0][0].ToString();


            string queryuser = "select Count(*) from UserTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryuser, con);
            DataTable dt2 = new DataTable();
            sda.Fill(dt2);
            UserLbl.Text = dt2.Rows[0][0].ToString();

        }

        private void Mycar_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
