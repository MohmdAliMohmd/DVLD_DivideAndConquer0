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

namespace DVLD_DivideAndConquer.User
{
    public partial class frmAddEditUser : Form
    {
        int _UserID = -1;
        clsUser _User;
        enum enMode {AddNew = 1,Update =2}
        enMode _Mode;
        public int UserID
        {
            set
            {
                _UserID = value;
                _User = clsUser.Find(_UserID);
                if (_User != null)
                {
                    //ctrl
                }

            }
            get
            {
                return _UserID;
            }
        }
        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _User = new clsUser();
           
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        void _SetTitle()
        {
            lblTitle.Text = (_Mode == enMode.AddNew) ? "Add New User" : "Edit User";
        }

        void _LoadDefaultValues()
        {
            _SetTitle();
            lblTitle.BackColor = Color.LightSteelBlue;
            tpLogInInfo.Enabled = false;
            btnSave.Enabled = false;
            btnNext.Enabled = false;
            ctrlPersonCardWithFilter1.LoadDefaultValues();
            
        }

        void _FillUserInfo()
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            txtUsername.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPW.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            
        }

       
       void  _LoadUserIfo()
        {
            _User = clsUser.Find(_UserID);
            if(_User == null)
            {
                MessageBox.Show($"No User with ID : {_UserID}" , "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            ctrlPersonCardWithFilter1.FilterEnable = false;
            tpLogInInfo.Enabled = true;
            btnNext.Enabled = true;
            btnSave.Enabled = true;
            _FillUserInfo();
        }

        void _ValidatePassWord()
        {
            if (txtPassword.Text != txtConfirmPW.Text)
            {
                txtConfirmPW.BackColor = Color.Red;
                txtPassword.BackColor = default;
            }
            else
            {
                txtConfirmPW.BackColor = Color.LightGreen;
                txtPassword.BackColor = Color.LightGreen;
            }
        }

        bool _PassWordMatched()
        {
            return (txtPassword.Text == txtConfirmPW.Text);
        }
        bool _ReadyToSave()
        {
            return (txtUsername.Text.Trim() != string.Empty && _PassWordMatched());
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';

                txtConfirmPW.UseSystemPasswordChar = false;
                txtConfirmPW.PasswordChar = '\0';
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;

                txtConfirmPW.UseSystemPasswordChar = false;
            }
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            if (_Mode == enMode.Update)
                _LoadUserIfo();


        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            _ValidatePassWord();
            btnSave.Enabled = _ReadyToSave();
        }

        private void txtConfirmPW_TextChanged(object sender, EventArgs e)
        {
            _ValidatePassWord();
            btnSave.Enabled = _ReadyToSave();
        }

      

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
           if(ctrlPersonCardWithFilter1.PersonID != -1) 
            {
                if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    lblTitle.BackColor = Color.Salmon;
                    lblTitle.Text += "  == Already a User ==";
                    MessageBox.Show("Selected Person already is a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();

                }
                else
                {
                    _SetTitle();
                    lblTitle.BackColor = Color.LightGreen;
                    btnNext.Enabled = true;
                    tpLogInInfo.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = _ReadyToSave();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUsername.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                
                //change form mode to update.
                _Mode = enMode.Update;
                _SetTitle();
                lblUserID.Text = _User.UserID.ToString();
                lblTitle.BackColor = Color.LightGreen;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            if (_Mode == enMode.Update)
                _LoadUserIfo();
           
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            };
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtConfirmPW_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPW.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPW, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPW, null);
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLogInInfo"];
        }
    }
}
