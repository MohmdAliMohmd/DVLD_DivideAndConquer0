using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }

        public static bool CreateFolderIfNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating Folder : {ex.Message}");
                    return false;
                }
            }
            return true;
        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo fileInfo = new FileInfo(FileName);
            string exten = fileInfo.Extension;
            return GenerateGUID() + exten;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if(!CreateFolderIfNotExist(DestinationFolder))
            {
                return false;
            }
            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);
            try 
            {
                File.Copy(SourceFile,destinationFile,true);
            }
            catch(IOException iox)
            { MessageBox.Show(iox.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            SourceFile = destinationFile;
            return true;
        }
    }
}
