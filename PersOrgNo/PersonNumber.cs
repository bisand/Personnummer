using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersOrgNo
{
    public static class PersonNumber
    {
        public static bool IsPersonNoValid(this string persNo)
        {
            return CheckPersonNumber(persNo);
        }

        private static bool CheckPersonNumber(string persNo)
        {
            var result = false;

            if (string.IsNullOrWhiteSpace(persNo))
                return false;

            persNo = persNo.Trim();
            persNo = persNo.Replace(" ", "");

            if (persNo.Length == 11)
            {
                int d1, d2, m1, m2, y1, y2, i1, i2, i3, k1, k2;

                if (!int.TryParse(persNo[0].ToString(), out d1))
                    return false;
                if (!int.TryParse(persNo[1].ToString(), out d2))
                    return false;
                if (!int.TryParse(persNo[2].ToString(), out m1))
                    return false;
                if (!int.TryParse(persNo[3].ToString(), out m2))
                    return false;
                if (!int.TryParse(persNo[4].ToString(), out y1))
                    return false;
                if (!int.TryParse(persNo[5].ToString(), out y2))
                    return false;
                if (!int.TryParse(persNo[6].ToString(), out i1))
                    return false;
                if (!int.TryParse(persNo[7].ToString(), out i2))
                    return false;
                if (!int.TryParse(persNo[8].ToString(), out i3))
                    return false;

                // Get the check sums.
                if (!int.TryParse(persNo[9].ToString(), out k1))
                    return false;
                if (!int.TryParse(persNo[10].ToString(), out k2))
                    return false;

                // Calculate the check sums.
                var kn1 = 11 - (((3 * d1) + (7 * d2) + (6 * m1) + (1 * m2) + (8 * y1) + (9 * y2) + (4 * i1) + (5 * i2) + (2 * i3)) % 11);
                var kn2 = 11 - (((5 * d1) + (4 * d2) + (3 * m1) + (2 * m2) + (7 * y1) + (6 * y2) + (5 * i1) + (4 * i2) + (3 * i3) + (2 * kn1)) % 11);

                if (((k1 == kn1) || (kn1 > 10)) && ((k2 == kn2) || (kn2 > 10)))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
