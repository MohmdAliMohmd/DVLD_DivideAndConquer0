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
using DVLD_Business;
using DVLD_DivideAndConquer.Licenses;
using DVLD_DivideAndConquer.Licenses.Local_Licenses;

namespace DVLD_DivideAndConquer.Applications.Rlease_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        int _SlectedLicenseID = -1;
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SlectedLicenseID = LicenseID;

            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SlectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
       
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SlectedLicenseID = obj;
            lblLicenseID.Text = _SlectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (_SlectedLicenseID != -1);
            if (_SlectedLicenseID == -1)
            {
                btnRelease.Enabled = false;
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This License isn't Detained, Choose another one", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }


           
            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.DetainID.ToString();
            lblDetainDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.DetainDate.ToShortDateString();

            lblLicenseID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
         
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();
            
            lblFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedLicenseInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            btnRelease.Enabled = true;

        }

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SlectedLicenseID);
            frm.ShowDialog();

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You want to Release this Detained License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int ApplicationID = -1;
            bool IsReleased = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID);

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

       
    }
}
