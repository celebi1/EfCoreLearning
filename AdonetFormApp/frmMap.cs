using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdonetFormApp
{
    public partial class frmMap : Form
    {
        public frmMap()
        {
            InitializeComponent();
        }

        private void btnOpenCityForm_Click(object sender, EventArgs e)
        {
            frmCity frmCity = new frmCity();
            frmCity.Show();
        }

        private void btnOpenCustomerForm_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.Show();
        }
    }
}
