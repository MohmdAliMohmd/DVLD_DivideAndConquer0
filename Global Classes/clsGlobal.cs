using DVLD_Business;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DVDL_Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username,string Password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectory + "\\data.txt";
                if (Username == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                string DataToSave = Username + "#//#" + Password;
                using(StreamWriter Write = new StreamWriter(FilePath))
                {
                    Write.WriteLine(DataToSave);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectory + "\\data.txt";
                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string Line;
                        while ((Line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(Line);
                            string[] Result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            Username = Result[0];
                            Password = Result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured : {ex.Message}");
                return false;
            }
        }

        public static void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
          // DataGridView dataGridView = sender as DataGridView;
            DataGridView dataGridView = (DataGridView)sender ;
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            //style1.ForeColor = Color.LightCyan;
            style2.BackColor = Color.White;
            if (e.RowIndex > -1)
                dataGridView.Rows[e.RowIndex].DefaultCellStyle = style2;
        }

        public static void DataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridView dataGridView = sender as DataGridView;
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCellStyle style1 = new DataGridViewCellStyle();
            //style1.ForeColor = Color.LightCyan;
            style1.BackColor = Color.LightGreen;
            if (e.RowIndex > -1)
                dataGridView.Rows[e.RowIndex].DefaultCellStyle = style1;
        }
    }
}
