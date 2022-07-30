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
    public partial class user_account : KryptonForm
    {
        public user_account()
        {
            InitializeComponent();
        }

        private void user_account_Load(object sender, EventArgs e)
        {

        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pass_gen passwordGen = new pass_gen();
            passwordGen.Show();
        }
    }
}
