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
    public partial class frmDonorReport : Form
    {
        public frmDonorReport()
        {
            InitializeComponent();
        }

        private void frmDonorReport_Load(object sender, EventArgs e)
        {
            // get list of emails of all donors and add to the combo box
            List<string> donors = ListUtil.donorList.Select(x => x.Email).ToList();
            cmbDonor.DataSource = donors;

            // set the listbox and datagridview source to all donations (we show all until user filters)
            lstDonationReport.DataSource = ListUtil.donations;
            dtaDonationReport.DataSource = ListUtil.donations;            
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // get selected combo box value
            string selectedDonor = cmbDonor.Text;

            // You try the long way... (I did it using LINQ below)
            // 1. loop through the donor list
            // 2. find name that matches
            // 3. get the id of that object
            // 4. store it in an int (currentDonor).

            int currentDonor = ListUtil.donorList.Where(x => x.Email.
                    Equals(selectedDonor)).First().DonorId;

            // You try the long way... (I did it using LINQ below)
            // 1. loop through the donations list
            // 2. find every donation where the donor id matches the currentDonor
            // 3. get a list of "matching"  objects
            // 4. set the listbox/datagridview datasource as the list we got

            lstDonationReport.DataSource = ListUtil.donations.
                    Where(x => x.DonorId.Equals(currentDonor)).ToList();

            dtaDonationReport.DataSource = ListUtil.donations.
                Where(x => x.DonorId.Equals(currentDonor)).ToList();

            double total = ListUtil.donations.Where(x => x.DonorId.Equals(currentDonor)).Select(y => y.Amount).Sum();

            MessageBox.Show("Total is R " + total);
        }
    }
}
