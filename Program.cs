using DVLD_Business;
using DVLD_DivideAndConquer.Applications.ApplicationTypes;
using DVLD_DivideAndConquer.Applications.Local_Driving_License;
using DVLD_DivideAndConquer.Drivers;
using DVLD_DivideAndConquer.Licenses;
using DVLD_DivideAndConquer.Licenses.Detain_License;
using DVLD_DivideAndConquer.People;
using DVLD_DivideAndConquer.Tests;
using DVLD_DivideAndConquer.Tests.Test_Types;
using DVLD_DivideAndConquer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.LogIn;

namespace DVLD_DivideAndConquer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
            //Application.Run(new frmShowPersonLicenseHistory(-1));
           // Application.Run(new frmDetainLicenseApplication());
            
            //Application.Run(new frmAddEditUser());
            //Application.Run(new frmChangePassword(1));
            //Application.Run(new frmPeopleList());
            //Application.Run(new frmDriversList());
            //Application.Run(new frmTestTypesList());
            //Application.Run(new frmApplicationTypesList());
            //Application.Run(new frmAddEditLocalLicensesDrivingLicenseApplication());
            //Application.Run(new frmEditApplicationType((int)clsTestType.enTestType.VisionTest));

        }
    }
}
