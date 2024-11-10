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

namespace DVLD_DivideAndConquer.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;

            if(handler != null)
            {
                handler(PersonID);
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private bool _showAddPersonBtn = true;
        private int _PersonID = -1;
        private bool _FilterEnable = true;
        #region
        [Category("Person Card With Filter")]
        public bool ShowAddPersonBTN
        {
            get { return _showAddPersonBtn ; }
            set { _showAddPersonBtn  = value;
                btnAddPerson.Visible = _showAddPersonBtn;
            }
        }

       

        [Category("Person Card With Filter")]
        public bool FilterEnable
        {
            get { return _FilterEnable;  }
            set 
            {
                _FilterEnable = value;
                gbFilter.Enabled = _FilterEnable;
            }
        }

       

        [Category("Person Card With Filter")]
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        [Category("Person Card With Filter")]
        public clsPerson SelectedPersonInfo
        {
            get
            {
                return ctrlPersonCard1.PersonInfo;
            } 
        }
        #endregion
        public void LoadPersonInfo(int PersonID)
        {
            cbxFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            //FilterEnable = false;
            _FindNow();
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
            }
            if(cbxFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();

            if(OnPersonSelected != null && FilterEnable)
            {
                OnPersonSelected(ctrlPersonCard1.PersonID);
            }
        }
        

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                txtFilterValue.Focus();
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This Filed is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void _FindNow()
        {
            switch(cbxFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;
                case "National No":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;
                default:
                    break;
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();

        }
        private void DataBackEvent(object sender, int PersonID)
        {
            cbxFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbxFilterBy.SelectedIndex = 1;
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
        }
        public void LoadDefaultValues()
        {
            cbxFilterBy.SelectedIndex = 1;
            txtFilterValue.Clear();
            ctrlPersonCard1.LoadDefaultValues();
            txtFilterValue.Focus();
        }
    }
}
