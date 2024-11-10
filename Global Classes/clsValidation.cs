using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DVDL_Classes
{
    public class clsValidation
    {
        public static bool IsValidEmail(string email)
        {
            string Pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            Regex regex = new Regex(Pattern);
            return regex.IsMatch(email);
        }

        public static bool IsValidEmail2(string email)
        {

            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.()\w{2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }

        public static bool IsValidInteger(string Number)
        {
            string Pattern = @"^[0-9]*$";
            Regex regex = new Regex(Pattern);
            return regex.IsMatch(Number);
        }

        public static bool IsValidFloat(string Number)
        {
            string Pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            Regex regex = new Regex(Pattern);
            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (IsValidInteger(Number)||IsValidFloat(Number));
        }

            
    }
}
