using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonationFormsApp
{
    public partial class frmAddDonor : Form
    {
        public frmAddDonor()
        {
            InitializeComponent();
        }

        private void btnAddDonor_Click(object sender, EventArgs e)
        {
            // for you to do: Add error checking (nulls, numeric value, valid email, etc.)

            Donor donor = new(ListUtil.donorList.Count+1, txbName.Text, 
                txbSurname.Text, txbPhone.Text, txbEmail.Text);
            ListUtil.donorList.Add(donor);

            MessageBox.Show("Donor Added");

            this.Close();
        }
    }
}
