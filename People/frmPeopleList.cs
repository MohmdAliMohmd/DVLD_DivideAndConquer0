using DVDL_Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DivideAndConquer.People
{
    public partial class frmPeopleList : Form
    {
        public frmPeopleList()
        {
            InitializeComponent();
        }
        
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

        private void _RefreshPeopleList()
        {
            //_dtAllPeople = clsPerson.GetAllPeople();
            //_dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
            //                                           "FirstName", "SecondName", "ThirdName", "LastName",
            //                                           "GendorCaption", "DateOfBirth", "CountryName",
            //                                           "Phone", "Email");

            dgvPeopleList.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeopleList.Rows.Count.ToString();
        }

        private void frmPeopleList_Load(object sender, EventArgs e)
        {
           
            dgvPeopleList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12,FontStyle.Bold);
            
            dgvPeopleList.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeopleList.Rows.Count.ToString();
            cbxFilterBy.SelectedIndex = 0;
            if(dgvPeopleList.Rows.Count>0)
            {
                dgvPeopleList.Columns[0].HeaderText = "Person ID";
                dgvPeopleList.Columns[0].Width = 110;

                dgvPeopleList.Columns[1].HeaderText = "National No.";
                dgvPeopleList.Columns[1].Width = 140;

                dgvPeopleList.Columns[2].HeaderText = "First Name";
                dgvPeopleList.Columns[2].Width = 120;

                dgvPeopleList.Columns[3].HeaderText = "Second Name";
                dgvPeopleList.Columns[3].Width = 140;

                dgvPeopleList.Columns[4].HeaderText = "Third Name";
                dgvPeopleList.Columns[4].Width = 130;

                dgvPeopleList.Columns[5].HeaderText = "Last Name";
                dgvPeopleList.Columns[5].Width = 120;

                dgvPeopleList.Columns[6].HeaderText = "Gender";
                dgvPeopleList.Columns[6].Width = 70;

                dgvPeopleList.Columns[7].HeaderText = "BirthDay";
                dgvPeopleList.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPeopleList.Columns[7].Width = 100;

                dgvPeopleList.Columns[8].HeaderText = "Nationality";
                dgvPeopleList.Columns[8].Width = 120;

                dgvPeopleList.Columns[9].HeaderText = "Phone";
                dgvPeopleList.Columns[9].Width = 110;

                dgvPeopleList.Columns[10].HeaderText = "Email";
                dgvPeopleList.Columns[10].Width = 150;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPeopleList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }

        private void dgvPeopleList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);

        }
        /*
         * None
Person ID
National No.
First Name
Second Name
Third Name
Last Name
Nationality
Gendor
Phone
Email
         */
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;
            switch (cbxFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(txtFilterValue.Text.Trim()==string.Empty || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            
            lblRecordsCount.Text = _dtAllPeople.Rows.Count.ToString();
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Enabled = (cbxFilterBy.Text != "None");
            if(txtFilterValue.Enabled)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (cbxFilterBy.Text == "Person ID" || cbxFilterBy.Text == "Phone")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (cbxFilterBy.Text == "First Name" || cbxFilterBy.Text == "Second Name" || cbxFilterBy.Text == "Third Name" || cbxFilterBy.Text == "Last Name" || cbxFilterBy.Text == "Nationality" || cbxFilterBy.Text == "Gender")
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvPeopleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;
            if (clsPerson.DeletePerson(PersonID))
            {
                MessageBox.Show($"Success to delete Person with ID: {PersonID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                _RefreshPeopleList();
                
            }
            else
                MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
