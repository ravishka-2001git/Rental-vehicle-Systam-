using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Travels_Systam
{
    public partial class _3_Sales_Dashboard : Form
    {
        public _3_Sales_Dashboard()
        {
            InitializeComponent();
        }

        private void btnSale_Customer_Click(object sender, EventArgs e)
        {
            _4_Coutomer C = new _4_Coutomer();
            C.TopLevel = false;
            panel_Sale.Controls.Add(C);
            C.BringToFront();
            C.Show();
        }

        private void btnSale_Rent_Click(object sender, EventArgs e)
        {
            _7_Rent R = new _7_Rent();
            R.TopLevel = false;
            panel_Sale.Controls.Add(R);
            R.BringToFront();
            R.Show();
        }

        private void btnSale_DayTour_Click(object sender, EventArgs e)
        {
            _9_Day_Tour DT = new _9_Day_Tour();
            DT.TopLevel = false;
            panel_Sale.Controls.Add(DT);
            DT.BringToFront();
            DT.Show();
        }

        private void btnSale_LoneTour_Click(object sender, EventArgs e)
        {
            _8_Long_Tour LT = new _8_Long_Tour();
            LT.TopLevel = false;
            panel_Sale.Controls.Add(LT);
            LT.BringToFront();
            LT.Show();
        }

        private void btnSale_Payment_Click(object sender, EventArgs e)
        {
            Payments P = new Payments();
            P.TopLevel = false;
            panel_Sale.Controls.Add(P);
            P.BringToFront();
            P.Show();
        }
    }
}
