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

namespace DVLD_DivideAndConquer.Applications.Local_Driving_License
{
    public partial class frmAddEditLocalLicensesDrivingLicenseApplication : Form
    {
        enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;
        int _LocalDrivingLicenseApplicationID = -1;
        int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddEditLocalLicensesDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditLocalLicensesDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _FillLicenseClassesInComboBox()
        {
            DataTable _dtLicenseClasses = clsLicenseClass.GetLicenseClasses();
            foreach(DataRow row in _dtLicenseClasses.Rows)
            {
                cmbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        void _LoadDefaultValues()
        {
            _FillLicenseClassesInComboBox();
            if(_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Local Driving Application";
                ctrlPersonCardWithFilter1.LoadDefaultValues();
                tpApplicationInfo.Enabled = false;
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                cmbLicenseClass.SelectedIndex = 2;
                lblID.Text = "[????]";
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {

                lblTitle.Text = "Edit Local Driving Application";
                tpApplicationInfo.Enabled = true;
                
            }
        }

        void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnable = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Application with ID : {_LocalDrivingLicenseApplicationID}", "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cmbLicenseClass.SelectedIndex = cmbLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClassInfo.ClassName);
            lblCreatedBy.Text = clsUser.Find(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
        }

        void DataBackEvent(object sender, int PersonID)
        {
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);
        }

        

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalApplicationInfo.SelectedTab = tcLocalApplicationInfo.TabPages["tpPersonalInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalApplicationInfo.SelectedTab = tcLocalApplicationInfo.TabPages["tpApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicensesDrivingLicenseApplication_Load(null, null);
        }

        private void frmAddEditLocalLicensesDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!this.ValidateChildren())
            //{
            //    Here we dont continue becuase the form is not valid
            //    MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
            //        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;

            //}
            int LicenseClassID = clsLicenseClass.Find(cmbLicenseClass.Text).LicenseClassID;
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForPersonByLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);
            if(ActiveApplicationID !=-1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLicenseClass.Focus();
                return;
            }
            if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if(_LocalDrivingLicenseApplication.Save())
            {
                lblID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Edit Local Driving License Application";
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Didn't Save Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmAddEditLocalLicensesDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
