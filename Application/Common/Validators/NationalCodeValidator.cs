using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Common.Validators
{
    public static class NationalCodeValidator
    {
        public static bool IsValid(string nationalCode)
        {
            if (nationalCode.Length != 10 || !nationalCode.All(char.IsDigit))
                return false;

            var invalidCodes = new[]
            {
            "0000000000","1111111111","2222222222","3333333333","4444444444",
            "5555555555","6666666666","7777777777","8888888888","9999999999"
            };

            if (invalidCodes.Contains(nationalCode))
                return false;

            var check = nationalCode[9] - '0';
            var sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += (nationalCode[i] - '0') * (10 - i);
            }

            var remainder = sum % 11;

            return (remainder < 2 && check == remainder) ||
                   (remainder >= 2 && check == (11 - remainder));
        }
    }
}
