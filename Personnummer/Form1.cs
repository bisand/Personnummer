using System;
using System.Windows.Forms;

namespace Personnummer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = CheckPersonNumber(textBox1.Text) ? "OK" : "FEIL!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = CheckOrganisationNumber(textBox2.Text) ? "OK" : "FEIL!";
        }
        
        private static bool CheckPersonNumber(string personNumber)
        {
            var result = false;

            if (personNumber != null && string.IsNullOrEmpty(personNumber))
                return false;

            if (personNumber != null)
                personNumber = personNumber.Trim();

            if (personNumber != null && personNumber.Length == 11)
            {
                int d1, d2, m1, m2, y1, y2, i1, i2, i3, k1, k2;

                if (!int.TryParse(personNumber[0].ToString(), out d1))
                    return false;
                if (!int.TryParse(personNumber[1].ToString(), out d2))
                    return false;
                if (!int.TryParse(personNumber[2].ToString(), out m1))
                    return false;
                if (!int.TryParse(personNumber[3].ToString(), out m2))
                    return false;
                if (!int.TryParse(personNumber[4].ToString(), out y1))
                    return false;
                if (!int.TryParse(personNumber[5].ToString(), out y2))
                    return false;
                if (!int.TryParse(personNumber[6].ToString(), out i1))
                    return false;
                if (!int.TryParse(personNumber[7].ToString(), out i2))
                    return false;
                if (!int.TryParse(personNumber[8].ToString(), out i3))
                    return false;

                // Get the check sums.
                if (!int.TryParse(personNumber[9].ToString(), out k1))
                    return false;
                if (!int.TryParse(personNumber[10].ToString(), out k2))
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

        private static bool CheckOrganisationNumber(string organisationNumber)
        {
            var result = false;

            if (organisationNumber != null && string.IsNullOrEmpty(organisationNumber))
                return false;

            if (organisationNumber != null)
                organisationNumber = organisationNumber.Trim();

            if (organisationNumber != null && organisationNumber.Length == 9)
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