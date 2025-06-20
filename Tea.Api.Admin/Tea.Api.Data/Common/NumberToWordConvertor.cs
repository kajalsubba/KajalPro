using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Data.Common
{
    public static class NumberToWordConvertor
    {
        static string[] ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

       public static string ConvertToWords(long number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "" + ConvertToWords(Math.Abs(number));

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += ConvertToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += ConvertToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                if (number < 10)
                    words += ones[number];
                else if (number < 20)
                    words += teens[number - 10];
                else
                {
                    words += tens[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + ones[number % 10];
                }
            }

            return words;
        }
        }
}
