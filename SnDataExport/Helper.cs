using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnDataExport
{
    public static class Helper
    {
        public static string FillLeadingZero(this int num, int total_digit)
        {
            string str_val = string.Empty;
            for (int i = 0; i < total_digit - num.ToString().Length; i++)
            {
                str_val += "0";
            }

            return str_val + num.ToString();
        }
    }
}
