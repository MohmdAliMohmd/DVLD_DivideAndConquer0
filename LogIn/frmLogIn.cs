using DVDL_Classes;
using DVLD_Business;
using DVLD_DivideAndConquer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.LogIn
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.Find(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (User != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if (!User.IsActive)
                {
                    txtUsername.Focus();
                    MessageBox.Show("Your Account isn't active, Contact Admin.", "InActive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                clsGlobal.CurrentUser = User;
                this.Hide();
                frmMain frm = new frmMain(this);
               frm.Show();
            }
            else
            {

                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password!", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            string Username = "",Password = "";
            if (clsGlobal.GetStoredCredential(ref Username, ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            txtUsername.Text = "";
            txtPassword.Text = string.Empty;
            chkRememberMe.Checked = false;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
            }
            else
                txtPassword.UseSystemPasswordChar = true;
        }

      
    }
}
