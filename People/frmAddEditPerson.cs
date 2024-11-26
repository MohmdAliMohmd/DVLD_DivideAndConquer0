using DVLD_Business;
using DVLD_DivideAndConquer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVDL_V0._01.Global_Classes;
using DVDL_Classes;

namespace DVLD_DivideAndConquer.People
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        enum enGender { Male = 0, Female = 1 }
        enGender _Gender = enGender.Male;
        int _PersonID = -1;
        clsPerson _Person;
        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _Person = new clsPerson();
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;

        }
        void _SetFormTitle()
        {
            lblTitle.Text = (_Mode == enMode.AddNew) ? ("Add New Person:") : ("Edit Person:");
        }
        void _HandelLoadPersonImage()
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
                    pbxPersonIMG.Image = (_Person.Gendor == 0) ? (Resources.DeletedMaleImage) : (Resources.DeletedFemaleImage);

            }
        }
        void _LoadPersonImage()
        {
            if (_Person == null)
                pbxPersonIMG.Image = (rbMale.Checked) ? (Resources.UnKnown_Male) : (Resources.UnKnown_Female);
            else
                _HandelLoadPersonImage();


            llblRemoveIMG.Enabled = (pbxPersonIMG.ImageLocation != null);
        }
        void _SetGender()
        {
            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
        }
        void _LoadCountriesNamesToComboBox()
        {
            DataTable dtCountries = clsCountry.GetCountries();
            foreach (DataRow Country in dtCountries.Rows)
            {
                cbxCountries.Items.Add(Country["CountryName"]);
            }
            cbxCountries.SelectedIndex = cbxCountries.FindString("Syria");
        }
        void _ResetDefaultValues()
        {
            _SetFormTitle();
            _LoadCountriesNamesToComboBox();
            rbMale.Checked = true;
            pbxPersonIMG.Image = Resources.UnKnown_Male;
            llblRemoveIMG.Enabled = false;
            lblPersonID.Text = "[????]";
            txtFirstName.Text = string.Empty;
            txtSecondName.Text = string.Empty;
            txtThirdName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalNo.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            rbMale.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

        }

        void LoadPersonInfo()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _SetGender();
            _LoadPersonImage();
            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            rbMale.Checked = (_Person.Gendor == 0) ? true : false;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

        }

        void _LoadData()
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                LoadPersonInfo();
        }

        bool _HandelPersonIMage()
        {

            if (_Person.ImagePath != pbxPersonIMG.ImageLocation)
            {
                if (_Person.ImagePath != string.Empty)
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException iox)
                    {
                        MessageBox.Show($"Error : {iox.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (pbxPersonIMG.ImageLocation != null)
                {
                    string SourceFile = pbxPersonIMG.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceFile))
                    {
                        pbxPersonIMG.ImageLocation = SourceFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error in Copying Image File!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.png)|*.png|JPG|*.jpg|JPEG|*.jpeg;|BMP|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbxPersonIMG.Load(selectedFilePath);
                llblRemoveIMG.Enabled = true;

            }
        }

        private void llblRemoveIMG_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbxPersonIMG.ImageLocation = null;
            pbxPersonIMG.Image = (rbMale.Checked) ? (Resources.UnKnown_Male) : (Resources.UnKnown_Female);
            llblRemoveIMG.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyLetters_KeyPress(sender, e);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyDigits_KeyPress(sender, e);
        }

       

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {

            if (clsTextBoxFilter.TextBoxIsNullOrEmpty(sender, e))
                errorProvider1.SetError((TextBox)sender, "This field is required!");
            else
                errorProvider1.SetError((TextBox)sender, null);
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbxPersonIMG.ImageLocation == null)
                pbxPersonIMG.Image = Resources.UnKnown_Male;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbxPersonIMG.ImageLocation == null)
                pbxPersonIMG.Image = Resources.UnKnown_Female;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();

            _Person.Gendor = (rbMale.Checked) ? (byte)enGender.Male : (byte)enGender.Female;

            _Person.NationalityCountryID = clsCountry.Find(cbxCountries.Text).CountryID;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            if (!_HandelPersonIMage())
                return;
            if (pbxPersonIMG.ImageLocation != null)
                _Person.ImagePath = pbxPersonIMG.ImageLocation;
            else
                _Person.ImagePath = string.Empty;
            if (_Person.Save())
            {
                lblTitle.BackColor = Color.LightGreen;
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                _SetFormTitle();

                MessageBox.Show("Successeded to save Person Information ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Failed to save Person Information!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTitle.BackColor = Color.Red;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == string.Empty)
                return;

            if (!clsValidation.IsValidEmail(txtEmail.Text.Trim()))
            {
                txtEmail.Focus();
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "This isn't a valid Email");
            }
            else 
                    errorProvider1.SetError((TextBox)sender, null);

            if (txtEmail.Text.Trim() != _Person.Email && clsPerson.IsPersonExistByEmail(txtEmail.Text.Trim()))
            {
                txtEmail.Focus();
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "Email Address is used for another person!");
            }
            else
                errorProvider1.SetError((TextBox)sender, null);

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(clsTextBoxFilter.TextBoxIsNullOrEmpty(sender,e))
            {
                errorProvider1.SetError((TextBox)sender, "This field is required!");
            }
            else
                errorProvider1.SetError((TextBox)sender, null);

            if(txtNationalNo.Text.Trim()!= _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
                {
                txtNationalNo.Focus();
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "National Number is used for another person!");
            }
            else
                errorProvider1.SetError((TextBox)sender, null);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (clsTextBoxFilter.TextBoxIsNullOrEmpty(sender, e))
            {
                errorProvider1.SetError((TextBox)sender, "This field is required!");
            }
            else
                errorProvider1.SetError((TextBox)sender, null);

            if (txtPhone.Text.Trim() != _Person.Phone && clsPerson.IsPersonExistByPhone(txtPhone.Text.Trim()))
            {
                txtPhone.Focus();
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "Phone Number is used for another person!");
            }
            else
                errorProvider1.SetError((TextBox)sender, null);
        }
    }
}