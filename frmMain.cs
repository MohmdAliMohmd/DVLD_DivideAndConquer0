using DVDL_Classes;
using DVLD_DivideAndConquer.Applications.ApplicationTypes;
using DVLD_DivideAndConquer.Applications.International_License;
using DVLD_DivideAndConquer.Applications.Local_Driving_License;
using DVLD_DivideAndConquer.Applications.Renew_Local_License;
using DVLD_DivideAndConquer.Applications.ReplaceLostOrDamagedLicense;
using DVLD_DivideAndConquer.Applications.Rlease_Detained_License;
using DVLD_DivideAndConquer.Drivers;
using DVLD_DivideAndConquer.Licenses.Detain_License;
using DVLD_DivideAndConquer.People;
using DVLD_DivideAndConquer.Tests.Test_Types;
using DVLD_DivideAndConquer.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.LogIn;
namespace DVLD_DivideAndConquer
{
    public partial class frmMain : Form
    {
        frmLogIn _LoginForm;
        public frmMain(frmLogIn loginForm)
        {
            InitializeComponent();
            _LoginForm = loginForm; 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LoginForm.Show();
            this.Close();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LoginForm.Show();
            this.Close();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicensesDrivingLicenseApplication frm = new frmAddEditLocalLicensesDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleList frm = new frmPeopleList();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriversList frm = new frmDriversList();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserList frm = new frmUserList();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationsList frm = new frmLocalDrivingLicenseApplicationsList();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypesList frm = new frmTestTypesList();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmApplicationTypesList frm = new  frmApplicationTypesList();
            frm.ShowDialog();
        
        }

        private void manageDetaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicensesList frm = new frmDetainedLicensesList();
            frm.ShowDialog();
        }

        private void InternaionalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void InternaionalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicesnseApplicationsList frm = new frmInternationalLicesnseApplicationsList();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm=   new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDriverLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();  
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationsList frm = new frmLocalDrivingLicenseApplicationsList();
            frm.ShowDialog();
        }
    }
}
