using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVDL_Classes;
using DVDL_V0._01.Global_Classes;
using DVLD_Business;
using DVLD_DivideAndConquer.Licenses.Detain_License;
using DVLD_DivideAndConquer.Licenses.Local_Licenses;

namespace DVLD_DivideAndConquer.Applications.Rlease_Detained_License
{
    public partial class frmDetainedLicensesList : Form
    {
        private DataTable _dtDetainedLicenses;

        public frmDetainedLicensesList()
        {
            InitializeComponent();
        }

        private void frmDetainedLicensesList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            _dtDetainedLicenses = clsDetain.GetDetainedLicenses();

            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;
                dgvDetainedLicenses.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;
                dgvDetainedLicenses.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 140;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = 0;
                cbIsReleased.Focus();
            }
            else
            {
                cbIsReleased.Visible = false;
                txtFilterValue.Visible = true;
                txtFilterValue.Enabled = (cbFilterBy.Text != "None");


                txtFilterValue.Focus();
            }
        }

        /*None
Detain ID
Is Released
National No.
Full Name
Release Application ID*/
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;
            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == string.Empty || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
                lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
            }
            else
            {
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] like {1}%", FilterColumn, txtFilterValue.Text.Trim());
                lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
            }
          
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;
            
            switch(FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue= "0"; 
                    break;
            }
            if (FilterValue == "All")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }
            _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                clsTextBoxFilter.txtBoxAcceptOnlyDigits_KeyPress(sender, e);
            else
                clsTextBoxFilter.txtBoxAcceptOnlyLetters_KeyPress(sender, e);

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(LicenseID);
            frm.ShowDialog();

            frmDetainedLicensesList_Load(null, null);
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            
            frmDetainedLicensesList_Load(null, null);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
            
            frmDetainedLicensesList_Load(null, null);
        }

        private void dgvDetainedLicenses_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);
        }

        private void dgvDetainedLicenses_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }

        private void dgvDetainedLicenses_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
