﻿using DVDL_Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DivideAndConquer.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationsList : Form
    {
        DataTable _dtAllLocalDrivigLicenseApplications;
        public frmLocalDrivingLicenseApplicationsList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingLicenseApplicationsList_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivigLicenseApplications = clsLocalDrivingLicenseApplication.GetAllApplications();
            dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivigLicenseApplications;
            lblRecordsCount.Text = _dtAllLocalDrivigLicenseApplications.Rows.Count.ToString();
            if(_dtAllLocalDrivigLicenseApplications.Rows.Count>0)
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 120;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 300;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 140;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 350;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 130;
            }
            cbxFilterBy.SelectedIndex = 0;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
           

                string FilterColumn = "";
                //Map Selected Filter to real Column name 
                switch (cbxFilterBy.Text)
                {

                    case "L.D.L.AppID":
                        FilterColumn = "LocalDrivingLicenseApplicationID";
                        break;

                    case "National No.":
                        FilterColumn = "NationalNo";
                        break;


                    case "Full Name":
                        FilterColumn = "FullName";
                        break;

                    case "Status":
                        FilterColumn = "Status";
                        break;


                    default:
                        FilterColumn = "None";
                        break;

                }

                //Reset the filters in case nothing selected or filter value conains nothing.
                if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
                {
                    _dtAllLocalDrivigLicenseApplications.DefaultView.RowFilter = "";
                    lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                    return;
                }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                //in this case we deal with integer not string.
                _dtAllLocalDrivigLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllLocalDrivigLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
            
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Enabled = (cbxFilterBy.Text != "None");

            if (txtFilterValue.Enabled)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            _dtAllLocalDrivigLicenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void dgvLocalDrivingLicenseApplications_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);
        }

        private void dgvLocalDrivingLicenseApplications_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicensesDrivingLicenseApplication frm = new frmAddEditLocalLicensesDrivingLicenseApplication();
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void dgvLocalDrivingLicenseApplications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicensesDrivingLicenseApplication frm = new frmAddEditLocalLicensesDrivingLicenseApplication((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if(LocalDrivingLicenseApplication != null)
            {
                if(LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplicationsList_Load(null, null);
                }
                else MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (MessageBox.Show("Are you sure do want to Cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;


                int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Cancel())
                    {
                        MessageBox.Show("Application Canceled Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLocalDrivingLicenseApplicationsList_Load(null, null);
                    }
                    else MessageBox.Show("Could not Cancel applicatoin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilterBy.Text == "L.D.L.AppID" )
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (cbxFilterBy.Text == "Full Name" || cbxFilterBy.Text == "Status" )
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ScheduleTestsMenue_Click(object sender, EventArgs e)
        {

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
