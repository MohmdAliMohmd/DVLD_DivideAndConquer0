using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVDL_Classes;
using DVLD_Business;
using DVLD_DivideAndConquer.Drivers;
using DVLD_DivideAndConquer.Licenses.International_Licenses;

namespace DVLD_DivideAndConquer.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternaionalLicensesHistory;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void dgvLocalLicensesHistory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);
        }

        private void dgvLocalLicensesHistory_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }

        private void dgvInternaionalLicensesHistory_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }

        private void dgvInternaionalLicensesHistory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);
        }

        private void _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicensesHistory = clsDriver.GetLicenses(_DriverID);


            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory;
            lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;
                dgvLocalLicensesHistory.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy"; 

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;
                dgvLocalLicensesHistory.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;

            }
        }

        private void _LoadInternaionalLicenseInfo()
        {

            _dtDriverInternaionalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);


            dgvInternaionalLicensesHistory.DataSource = _dtDriverInternaionalLicensesHistory;
            lblInternaionalLicensesRecords.Text = dgvInternaionalLicensesHistory.Rows.Count.ToString();

            if (dgvInternaionalLicensesHistory.Rows.Count > 0)
            {
                dgvInternaionalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternaionalLicensesHistory.Columns[0].Width = 160;

                dgvInternaionalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternaionalLicensesHistory.Columns[1].Width = 130;

                dgvInternaionalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternaionalLicensesHistory.Columns[2].Width = 130;

                dgvInternaionalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternaionalLicensesHistory.Columns[3].Width = 180;
                dgvInternaionalLicensesHistory.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvInternaionalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternaionalLicensesHistory.Columns[4].Width = 180;
                dgvInternaionalLicensesHistory.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvInternaionalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternaionalLicensesHistory.Columns[5].Width = 120;

            }
        }

        public void LoadInfo(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(_DriverID);

            _LoadLocalLicenseInfo();
            _LoadInternaionalLicenseInfo();

        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver != null)
            {
                _DriverID = _Driver.DriverID;
            }
            _LoadLocalLicenseInfo();
            _LoadInternaionalLicenseInfo();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID =(int) dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            Local_Licenses.frmShowLicenseInfo frm = new Local_Licenses.frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void InternaionalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternaionalLicenseID = (int)dgvInternaionalLicensesHistory.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternaionalLicenseID);
            frm.ShowDialog();
        }

        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();
            _dtDriverInternaionalLicensesHistory.Clear();
        }

        private void dgvLocalLicensesHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            Local_Licenses.frmShowLicenseInfo frm = new Local_Licenses.frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void dgvInternaionalLicensesHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int InternaionalLicenseID = (int)dgvInternaionalLicensesHistory.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternaionalLicenseID);
            frm.ShowDialog();
        }
    }
}
