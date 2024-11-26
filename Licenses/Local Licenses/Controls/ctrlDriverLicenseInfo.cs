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
using DVDL_Classes;

namespace DVLD_DivideAndConquer.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        int _LicenseID;
        clsLicense _License;
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        #region
        [Category("License Info")]
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        [Category("License Info")]
        public clsLicense SelectedLicenseInfo
            { get { return _License; } }
        #endregion


        void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.ImagePath == string.Empty)
            {

                pbPersonImage.Image = (_License.DriverInfo.PersonInfo.Gendor == 0) ? Resources.UnKnown_Male : Resources.UnKnown_Female;

                return;
            }
            else //_Person.ImagePath != string.Empty
            {
                if (File.Exists(_License.DriverInfo.PersonInfo.ImagePath))
                    pbPersonImage.ImageLocation = _License.DriverInfo.PersonInfo.ImagePath;
                else
                {
                    pbPersonImage.Image = (_License.DriverInfo.PersonInfo.Gendor == 0) ? (Resources.DeletedMaleImage) : (Resources.DeletedFemaleImage);
                }
            }

        }
        void _LoadPersonImage2()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.UnKnown_Male;
            else
                pbPersonImage.Image = Resources.UnKnown_Female;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    pbPersonImage.Image = (_License.DriverInfo.PersonInfo.Gendor == 0) ? (Resources.DeletedMaleImage) : (Resources.DeletedFemaleImage);

        }

        public void LoadInfo(int LicenseID)
            {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);
            if(_License == null)
            {
                MessageBox.Show($"Couldn't find License ID = {_LicenseID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            lblLicenseID.Text = _License.LicenseID.ToString();

            lblIsActive.Text = (_License.IsActive) ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblNotes.Text=_License.Notes==string.Empty?"No Notes":_License.Notes;

            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblDriverID.Text= _License.DriverInfo.DriverID.ToString();
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReason.ToString();  
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            _LoadPersonImage();



        }
    }
}
