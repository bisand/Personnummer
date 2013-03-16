namespace PersOrgNo
{
    public static class OrganizationNumber
    {
        public static bool IsOrgNoValid(this string orgNo)
        {
            return CheckOrganisationNumber(orgNo);
        }

        private static bool CheckOrganisationNumber(string organisationNumber)
        {
            var result = false;

            if (string.IsNullOrWhiteSpace(organisationNumber))
                return false;

            organisationNumber = organisationNumber.Trim();
            organisationNumber = organisationNumber.Replace(" ", "");

            if (organisationNumber.Length == 9)
            {
                int n1, n2, n3, n4, n5, n6, n7, n8, k1;

                if (!int.TryParse(organisationNumber[0].ToString(), out n1))
                    return false;
                if (!int.TryParse(organisationNumber[1].ToString(), out n2))
                    return false;
                if (!int.TryParse(organisationNumber[2].ToString(), out n3))
                    return false;
                if (!int.TryParse(organisationNumber[3].ToString(), out n4))
                    return false;
                if (!int.TryParse(organisationNumber[4].ToString(), out n5))
                    return false;
                if (!int.TryParse(organisationNumber[5].ToString(), out n6))
                    return false;
                if (!int.TryParse(organisationNumber[6].ToString(), out n7))
                    return false;
                if (!int.TryParse(organisationNumber[7].ToString(), out n8))
                    return false;

                // Get the check sum.
                if (!int.TryParse(organisationNumber[8].ToString(), out k1))
                    return false;

                // Calculate the check sums.
                var kn1 = 11 - (((3 * n1) + (2 * n2) + (7 * n3) + (6 * n4) + (5 * n5) + (4 * n6) + (3 * n7) + (2 * n8)) % 11);

                if ((k1 == kn1) || (kn1 > 10))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}