using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace megalodon
{
    public partial class pass_gen : KryptonForm
    {
        private static bool upper, lower, number, special;
        private static int PasswordSize;
        private List<string> passHistList = new List<string>();

        public pass_gen()
        {
            InitializeComponent();
        }

        private void passSize_Click(object sender, EventArgs e)
        {

        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (UpperCheck.CheckState == CheckState.Checked)
            {
                upper = true;
            }
            else
            {
                upper = false;
            }

            if (LowerCheck.CheckState == CheckState.Checked)
            {
                lower = true;
            }
            else
            {
                lower = false;
            }
            if (NumberCheck.CheckState == CheckState.Checked)
            {
                number = true;
            }
            else
            {
                number = false;
            }

            if (SpecialCheck.CheckState == CheckState.Checked)
            {
                special = true;
            }
            else
            {
                special = false;
            }

            if (upper == false && lower == false && number == false && special == false)
            {
                MessageBox.Show("You must check at least one checkbox to generate a password!", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                passwordBox.Text = PasswordGenerator.GeneratePassword(upper, lower, number, special, PasswordSize);
            }
            
            if (passHistList.Count == 6)
            {
                passHistList.RemoveAt(0);
                passHistList.Add(passwordBox.Text);
            }
            else
            {
                passHistList.Add(passwordBox.Text);
            }
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
          passhistory passhistory = new passhistory(passHistList);
          passhistory.Show();
        }

        private void passwordSizeBar_Scroll(object sender, EventArgs e)
        {
            passSize.Text = passwordSizeBar.Value.ToString();
            PasswordSize = passwordSizeBar.Value;
        }



        private void pass_gen_Load(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public static class PasswordGenerator
    {
        private static string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string Numbers = "1234567890";
        private static string SpecialChars = "!@#$%^&*()_-+=?><,.:;";

        public static string GeneratePassword(
            bool useUpper,
            bool useLower,
            bool useNumbers,
            bool useSpecial,
            int PasswordSize)
        {
            Random rand = new Random();
            string charSet = string.Empty;
            char[] password = new char[PasswordSize];

            if (useUpper) charSet += Upper;
            if (useLower) charSet += Upper.ToLower();
            if (useNumbers) charSet += Numbers;
            if (useSpecial) charSet += SpecialChars;

            for (int i = 0; i < PasswordSize; i++)
            {
                password[i] = charSet[rand.Next(charSet.Length - 1)];
            }

            return string.Join(null, password);
        }
    }
}
