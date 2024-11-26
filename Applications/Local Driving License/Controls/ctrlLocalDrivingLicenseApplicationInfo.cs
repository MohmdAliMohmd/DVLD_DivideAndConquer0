using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_DivideAndConquer.Applications.Local_Driving_License.Controls
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;
        int _LicenseID = -1;

        #region
        [Category("Local Driving License Info")]
        public int LocalDrivingLicenseApplicationID
        {
            get
            {
                return _LocalDrivingLicenseApplicationID;
            }
        }
        #endregion
        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        void _LoadDefaultValue()
        {
            ctrlApplicationBasicInfo1.LoadDefaultValues();
            llblViewLicenseInfo.Enabled = false;
            lblID.Text = "[????]";
            lblAppliedFor.Text = "[????]";
            lblPassedTests.Text = "0";
        }

        void _FillLocalDrivingLicenseInfo()
        {

            _LicenseID = _LocalDrivingLicenseApplication.GetActiveApplicationID();
            llblViewLicenseInfo.Enabled = (_LicenseID != -1);
            lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);

        }

        private void llblViewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null)
            {
                _LoadDefaultValue();
                MessageBox.Show($"No Application with ApplicationID = { LocalDrivingLicenseApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseInfo();
        }
        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _LoadDefaultValue();
                MessageBox.Show($"No Application with ApplicationID = {LocalDrivingLicenseApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseInfo();
        }
    }

}
