using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
   public class Validation
   {
        public static bool isValidText(string x)
        {
            if (x == null)
                return false;
            if (x.Length == 0)
                return false;
            if (x.Trim().Length == 0) //This checks for whitespace only "Strings" 
                return false;

            return true;
            
        }
        public static bool isValidInt(string x)
        {
            int test = 0;
            if (int.TryParse(x, out test))
            return true;
            else
            return false;

        }

        public static bool isValidDecimal(string x)
        {
            decimal test = 0.0m;
            if (decimal.TryParse(x, out test))
                return true;
            else
                return false;
        }

        public static bool isValidDouble(string x)
        {
            double test = 0.0;
            if (double.TryParse(x, out test))
                return true;
            else
                return false;

        
        }
   }
}
