using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_V0._01.Global_Classes
{
    internal class clsTextBoxFilter
    {
        public static bool ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                Temp.Focus();
                e.Cancel = true;
                return true;
            }
            else
            {
                e.Cancel = false;
                return false; 
            }

        }

        public static void txtBoxAcceptOnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }

        public static void txtBoxAcceptOnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8 && ch != 46)
                e.Handled = true;
        }
    }
}
