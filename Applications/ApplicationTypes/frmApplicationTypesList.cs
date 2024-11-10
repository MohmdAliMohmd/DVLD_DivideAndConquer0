using DVDL_Classes;
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

namespace DVLD_DivideAndConquer.Applications.ApplicationTypes
{
    public partial class frmApplicationTypesList : Form
    {
        static DataTable _dtAllApplicationTypes;
        public frmApplicationTypesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmApplicationTypesList_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetApplicationTypes();
            dgvApplicationTypesList.DataSource = _dtAllApplicationTypes;
            lblRecordsCount.Text = dgvApplicationTypesList.RowCount.ToString();
            if (dgvApplicationTypesList.Rows.Count > 0)
            {
                dgvApplicationTypesList.Columns[0].HeaderText = "Type ID";
                dgvApplicationTypesList.Columns[0].Width = 110;

                dgvApplicationTypesList.Columns[1].HeaderText = "Type Title";
                dgvApplicationTypesList.Columns[1].Width = 450;

                dgvApplicationTypesList.Columns[2].HeaderText = "Fees";
                dgvApplicationTypesList.Columns[2].Width = 120;

            }
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmApplicationTypesList_Load(null, null);
        }

        private void dgvApplicationTypesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmApplicationTypesList_Load(null, null);
        }

        private void dgvApplicationTypesList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);
        }

        private void dgvApplicationTypesList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }
    }
}
