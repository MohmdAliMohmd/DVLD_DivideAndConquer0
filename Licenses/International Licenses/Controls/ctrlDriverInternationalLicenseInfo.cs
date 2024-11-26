using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLD_Business;
using DVLD_DivideAndConquer.Properties;

namespace DVLD_DivideAndConquer.Licenses.International_Licenses.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        int _InternationalLicenseID;
        clsInternationalLicense _InternationalLicense;
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        #region
        [Category("International License Info")]
        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }
        #endregion
        void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.ImagePath == string.Empty)
            {

                pbPersonImage.Image = (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0) ? Resources.UnKnown_Male : Resources.UnKnown_Female;

                return;
            }
            else //_Person.ImagePath != string.Empty
            {
                if (File.Exists(_InternationalLicense.DriverInfo.PersonInfo.ImagePath))
                    pbPersonImage.ImageLocation = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;
                else
                {
                    pbPersonImage.Image = (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0) ? (Resources.DeletedMaleImage) : (Resources.DeletedFemaleImage);
                }
            }

        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID ;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            if( _InternationalLicense == null )
            {
                MessageBox.Show($"Couldn't find Internationa License ID = {_InternationalLicenseID}"  ,
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }
            lblInternationalLicenseID.Text = _InternationalLicenseID.ToString();
            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblGendor.Text = (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text= _InternationalLicense.DriverInfo.PersonInfo.NationalNo;

            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = (_InternationalLicense.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicense.DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();

            _LoadPersonImage();
        }

       
    }
}
