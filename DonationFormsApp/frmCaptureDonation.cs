using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DonationFormsApp
{
    public partial class frmCaptureDonation : Form
    {
        public frmCaptureDonation()
        {
            InitializeComponent();
        }

        private void frmCaptureDonation_Load(object sender, EventArgs e)
        {
            // get list of emails of all donors and add to the combo box

            // the way we know...
            /*
            List<string> donorNames = new List<string>();
            foreach (Donor donor in ListUtil.donorList)
            {
                donorNames.Add(donor.Name);
            }
            */

            // using LINQ
            List<string> donors = ListUtil.donorList.Select(x => x.Email).ToList();
            cmbDonor.DataSource = donors;
        }

        private void btnCaptueDonation_Click(object sender, EventArgs e)
        {
            // get selected combo box value
            string comboBoxSelection = cmbDonor.Text;
            
            // now that we have the selected donor email, go through the list and get the relevant donor
            Donor currentDonor = ListUtil.donorList.Where(x => x.Email.Equals(comboBoxSelection)).First();

            // now that we have the donor object, get the donor id (we need it to make a donation object
            int currentDonorId = currentDonor.DonorId;

            Donation donation = new(ListUtil.donations.Count, Convert.ToDouble(txbAmount.Text), 
                                    txbCause.Text, currentDonorId);

            ListUtil.donations.Add(donation);

            MessageBox.Show("Donation Added");

            this.Close();
        }


    }
}
