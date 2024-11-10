using DVDL_Classes;
using DVLD_Business;
using DVLD_DivideAndConquer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DivideAndConquer.People.Controls
{

    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        clsPerson _Person;
        #region
        [Category("Person Info")]
        public int PersonID
        {
            get { return _PersonID; }
            set
            {
                _PersonID = value;


                _Person = clsPerson.Find(_PersonID);
                if (_Person != null)
                {
                    LoadPersonInfo(_PersonID);
                }
                else
                {
                    LoadDefaultValues();
                }
            }
        }
        [Category("Person Info")] 
            public clsPerson PersonInfo
        {
            get
            {
                return _Person;
            }
        }
        #endregion




        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        void _LoadImage()
        {
            if (_Person.ImagePath == string.Empty)
            {

                pbxPersonIMG.Image = (_Person.Gendor == 0) ? Resources.UnKnown_Male : Resources.UnKnown_Female;

                return;
            }
            else //_Person.ImagePath != string.Empty
            {
                if (File.Exists(_Person.ImagePath))
                    pbxPersonIMG.ImageLocation = _Person.ImagePath;
                else
                {
                    pbxPersonIMG.Image = (_Person.Gendor == 0) ? (Resources.DeletedMaleImage) : (Resources.DeletedFemaleImage);
                }
            }

        }
        public void LoadDefaultValues()
        {
            lblPersonID.Text = "[????]";
            lblFullName.Text = "[????]"; ;
            
            lblGender.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            pbxPersonIMG.Image = Resources.UnKnown_Male;
            llblEditPersonInfo.Enabled = false;
        }
        string _getGender()
        {
            return (_Person.Gendor == 0) ? ("Male") : ("Female");
        }
        void _FillPersonInfo()
        {
            llblEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FullName;

            lblGender.Text = _getGender();
            lblNationalNo.Text = _Person.NationalNo;
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            _LoadImage();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                LoadDefaultValues();
                MessageBox.Show($"There is no Person with Person ID = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();

        }

        public void LoadPersonInfo(string NationalNO)
        {
            _Person = clsPerson.Find(NationalNO);
            if(_Person == null)
            {
                LoadDefaultValues();
                MessageBox.Show($"There is no Person with National No. = {NationalNO}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
            
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
