using DVDL_Classes;
using DVLD_Business;
using DVLD_DivideAndConquer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DivideAndConquer.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplication _Application;

        private int _ApplicationID;
        #region
        [Category("Application Info")]
        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        #endregion
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
      public  void LoadDefaultValues()
        {
            _ApplicationID = -1;
            llblViewPersonInfo.Enabled = false;

            lblID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblFees.Text = "[$$$]";
            lblType.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[??/??/????]";
            lblStatusDate.Text = "[??/??/????]";
            lblCreatedBy.Text = "[????]";
        }

        void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            llblViewPersonInfo.Enabled = true;

            lblID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.ApplicationStatus.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text =clsFormat.DateToShort( _Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort( _Application.LastStatusDate);
            lblCreatedBy.Text = _Application.CreatedByUserInfo.UserName;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                _ApplicationID = -1;
                MessageBox.Show($"No application Found with ApplicationID: {ApplicationID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadDefaultValues();
            }
            else
                _FillApplicationInfo();

        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();
            LoadApplicationInfo(_ApplicationID);
        }
    }
}
