using DVDL_Classes;
using DVLD_Business;
using DVLD_DivideAndConquer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsTestType;

namespace DVLD_DivideAndConquer.Tests
{
    public partial class frmTestAppointmentsList : Form
    {

        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        public frmTestAppointmentsList(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {

                        lblTitle.Text = "Vision Test Appointments";
                        pbxTestTypeIMG.Image = Resources.Vision_Test;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        pbxTestTypeIMG.Image = Resources.WrittenTest;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        pbxTestTypeIMG.Image = Resources.test_drive2;
                        break;


                    }
            }
        }

        private void frmTestAppointmentsList_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();


            ctrlLocalDrivingLicenseInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvLicenseTestAppointments.DataSource = _dtLicenseTestAppointments;
            lblRecordsCount.Text = dgvLicenseTestAppointments.Rows.Count.ToString();

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            

                clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);


                if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
                {
                    MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                //---
                clsTest LastTest = localDrivingLicenseApplication.GetLatestTestPerTypeType(_TestType);

                if (LastTest == null)
                {
                    frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                    frm1.ShowDialog();
                frmTestAppointmentsList_Load(null, null);
                    return;
                }

                //if person already passed the test s/he cannot retak it.
                if (LastTest.TestResult == true)
                {
                    MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmScheduleTest frm2 = new frmScheduleTest
                    (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
                frm2.ShowDialog();
            frmTestAppointmentsList_Load(null, null);
                //---

            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;


            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();
            frmTestAppointmentsList_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmTestAppointmentsList_Load(null, null);
        }

        private void dgvLicenseTestAppointments_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseLeave(sender, e);
        }

        private void dgvLicenseTestAppointments_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsGlobal.DataGridView_CellMouseMove(sender, e);
        }
    }
}
