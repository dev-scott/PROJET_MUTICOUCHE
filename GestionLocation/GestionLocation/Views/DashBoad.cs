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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sados\Documents\GestionLocationDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DashBoad_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CarLbl.Text = dt.Rows[0][0].ToString();
        }

        private void Mycar_Click(object sender, EventArgs e)
        {

        }
    }
}
