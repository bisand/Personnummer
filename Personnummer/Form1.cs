using System;
using System.Windows.Forms;
using PersOrgNo;

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
            label1.Text = textBox1.Text.IsPersonNoValid() ? "OK" : "FEIL!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = textBox2.Text.IsOrgNoValid() ? "OK" : "FEIL!";
        }
    }
}