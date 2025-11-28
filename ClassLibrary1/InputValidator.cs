using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenijIdiotGame.Common
{
    public class InputValidator
    {
        public static bool TryParseToNumber(string input, out int number, out string errorMessage)
        {
            try
            {
                number = int.Parse(input);
                errorMessage = string.Empty;
                return true;
            }
            catch (FormatException)
            {
                errorMessage = "Введите число";
                number = 0;
                return false;
            }
            catch (OverflowException)
            {
                errorMessage = "Число очень большое. Введите число в диапазоне от -2 147 483 648 до 2 147 483 647";
                number = 0;
                return false;
            }
        }
    }
}
