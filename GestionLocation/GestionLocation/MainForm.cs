using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionLocation.Type.Commons;


namespace GestionLocation
{
    public partial class MainForm : Form
    {
        public List<Car> cars;
    

        public MainForm()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car car = new Car();
            car.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental rental = new Rental();
            rental.Show();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users mes_use = new Users();
            mes_use.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return ret = new Return();
            ret.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoad board = new DashBoad();
            board.Show();
        }
    }
}
