using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASProjektWPF.Classes
{
    public static class CustomValidations
    {

        public static bool IsCorrectText(string text)
        {
            if(text == null || text.Length == 0) {  return false; }
            if (Regex.IsMatch(text,"^[a-zA-Z ]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsCorrectNumbers(string text)
        {
            if (text == null || text.Length == 0) { return false; }
            if (Regex.IsMatch(text, "^[0-9]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsCorrectTextAndNumbers(string text)
        {
            if (text == null || text.Length == 0) { return false; }
            if (Regex.IsMatch(text, "^[a-zA-Z0-9 ]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsCorrectEmail(string text)
        {
            if (text == null || text.Length == 0) { return false; }
            if (Regex.IsMatch(text, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
