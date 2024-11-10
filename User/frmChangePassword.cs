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
    public partial class frmChangePassword : Form
    {
        int _UserID = -1;
        clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private void _LoadDefaultValues()
        {
            txtCurrentPW.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPW.Text = string.Empty;
            txtCurrentPW.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            _User = clsUser.Find(_UserID);

            if(_User == null)
            {
                MessageBox.Show($"Could not Find User with id : {_UserID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void txtCurrentPW_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPW.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPW, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPW, null);
            };


            if (_User.Password!= txtCurrentPW.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPW, "Current Password is Wrong");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPW, null);
            };
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            };

           
        }

        private void txtConfirmPW_Validating(object sender, CancelEventArgs e)
        {

            if (txtNewPassword.Text.Trim() != txtConfirmPW.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPW, "Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPW, null);
            };
        }
        void _ValidatePassWord()
        {
            if (txtNewPassword.Text != txtConfirmPW.Text)
            {
                txtConfirmPW.BackColor = Color.Red;
                txtNewPassword.BackColor = default;
            }
            else
            {
                txtConfirmPW.BackColor = Color.LightGreen;
                txtNewPassword.BackColor = Color.LightGreen;
            }
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
            _User.Password = txtNewPassword.Text.Trim();
            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadDefaultValues();
                
            }
            else
            {
                MessageBox.Show("An Erro Occured,Password didn't Change",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            _ValidatePassWord();
        }

        private void txtConfirmPW_TextChanged(object sender, EventArgs e)
        {
            _ValidatePassWord();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _LoadDefaultValues();
        }
    }
}
