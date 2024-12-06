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
using DVDL_V0._01.Global_Classes;
using DVLD_Business;

namespace DVLD_DivideAndConquer.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public event Action <int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        int _LicenseID = -1;
        bool _FilterEnabled = true;
        
        #region
        [Category("License With Filter Info")]
        public int LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }
        [Category("License With Filter Info")]
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        [Category("License With Filter Info")]
        public clsLicense SelectedLicenseInfo
        { get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; } }
        #endregion

        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            if(OnLicenseSelected!= null && FilterEnabled)
            {
                OnLicenseSelected(_LicenseID);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;

            }
            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsTextBoxFilter.txtBoxAcceptOnlyDigits_KeyPress(sender, e);
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }
        }
        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }
    }
}
