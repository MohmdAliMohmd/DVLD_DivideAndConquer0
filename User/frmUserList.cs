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

namespace DVLD_DivideAndConquer.User
{
    public partial class frmUserList : Form
    {
        private static DataTable _dtAllUsers ;
        
        public frmUserList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*None
User ID
UserName
Person ID
Full Name
Is Active*/
        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbxFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbxIsActive.Visible = true;
                cbxIsActive.SelectedIndex = 0;
                cbxIsActive.Focus();
            }
            else
            {
                cbxIsActive.Visible = false;
                txtFilterValue.Visible = true;
                txtFilterValue.Enabled = (cbxFilterBy.Text != "None");
                if (txtFilterValue.Enabled)
                {
                    txtFilterValue.Text = string.Empty;
                    txtFilterValue.Focus();
                }
            }

        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUserList.DataSource = _dtAllUsers;
            lblRecordsCount.Text = dgvUserList.Rows.Count.ToString();
            cbxFilterBy.SelectedIndex = 0;
            if (dgvUserList.Rows.Count > 0)
            {
                dgvUserList.Columns[0].HeaderText = "User ID";
                dgvUserList.Columns[0].Width = 110;

                dgvUserList.Columns[1].HeaderText = "Person ID";
                dgvUserList.Columns[1].Width = 120;

                dgvUserList.Columns[2].HeaderText = "Full Name";
                dgvUserList.Columns[2].Width = 450;

                dgvUserList.Columns[3].HeaderText = "UserName";
                dgvUserList.Columns[3].Width = 140;

                dgvUserList.Columns[4].HeaderText = "Is Active";
                dgvUserList.Columns[4].Width = 110;
            }

        }

        private void dgvUserList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);

        }

        private void dgvUserList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser ();
            frm.ShowDialog();
            frmUserList_Load(null,null);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            frmUserList_Load(null, null);
        }

       

        private void dgvUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUserList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmUserList_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUserInfo frm = new frmUserInfo((int)dgvUserList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmUserList_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddEditUser frm = new frmAddEditUser((int)dgvUserList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmUserList_Load(null, null);
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUserList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmUserList_Load(null,null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUserList.CurrentRow.Cells[0].Value;
            if (clsUser.Delete(UserID))
            {
                MessageBox.Show("User deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserList_Load(null,null);

            }
            else
                MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            /*None
User ID
UserName
Person ID
Full Name
Is Active*/

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbxFilterBy.Text)
            {

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;



                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUserList.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvUserList.Rows.Count.ToString();
        }

        private void cbxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbxIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();


        }
    }
    
    
}
