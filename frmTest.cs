using DVDL_V0._01.Global_Classes;
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

namespace DVLD_DivideAndConquer
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.Show();
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(1);
            frm.Show();
        }

        private void txtPersonID_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyDigits_KeyPress(sender, e);
        }

        private void btnShowPersonInfo_Click(object sender, EventArgs e)
        {
            ctrlPersonCard1.PersonID = Convert.ToInt32(txtPersonID.Text.Trim());
        }

        private void btnPeopleList_Click(object sender, EventArgs e)
        {
            frmPeopleList frm = new frmPeopleList();
            frm.Show();

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string str1 = string.Empty;
            string str2 = "";

            if (str1.Equals(str2))
                MessageBox.Show("Yes");
            else
                MessageBox.Show("No");
        }

        private void btnShowUserInfo_Click(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(int.Parse(txtUserID.Text.Trim()));
        }

        private void txtPersonID_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
