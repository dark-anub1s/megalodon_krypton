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
    public partial class Login_UI : KryptonForm
    {
        public Login_UI()
        {
            InitializeComponent();
        }

        private void Login_UI_Load(object sender, EventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            user_registration new_user = new user_registration();
            new_user.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void rsaIcon_Click(object sender, EventArgs e)
        {

        }

        private void openKey_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog rsa_key = new OpenFileDialog();
                rsa_key.Title = "RSA Private Key";


                if (rsa_key.ShowDialog() == DialogResult.OK)
                {
                    rsaKey.Text = rsa_key.FileName;
                }
            }
            catch
            {
                MessageBox.Show("Error.");
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text == "thiggins" && rsaKey.Text == "key")
            {
                user_account user_acc = new user_account();
                this.Hide();
                user_acc.Closed += (s, args) => this.Close();
                user_acc.Show();
            }
        }
    }
}
