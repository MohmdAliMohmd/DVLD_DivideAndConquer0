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

namespace DVLD_DivideAndConquer.Tests.Test_Types
{
    public partial class frmTestTypesList : Form
    {
        DataTable _dtAllTestTypes;
        public frmTestTypesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTestTypesList_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestType.GetTestTypes();
            dgvTestTypesList.DataSource = _dtAllTestTypes;
            lblRecordsCount.Text = _dtAllTestTypes.Rows.Count.ToString();
            if(dgvTestTypesList.Rows.Count>0)
            {
                dgvTestTypesList.Columns[0].HeaderText = "ID";
                dgvTestTypesList.Columns[0].Width = 110;
                
                dgvTestTypesList.Columns[1].HeaderText = "Title";
                dgvTestTypesList.Columns[1].Width = 200;
                
                dgvTestTypesList.Columns[2].HeaderText = "Description";
                dgvTestTypesList.Columns[2].Width = 460;
                
                dgvTestTypesList.Columns[3].HeaderText = "Fees";
                dgvTestTypesList.Columns[3].Width = 120;
            }
        }

        private void dgvTestTypesList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender,e);
        }

        private void dgvTestTypesList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmTestTypesList_Load(null, null);
        }

        private void dgvTestTypesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmTestTypesList_Load(null, null);
        }
    }
}
