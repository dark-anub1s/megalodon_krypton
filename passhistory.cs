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
    public partial class passhistory : KryptonForm
    {
        List<string> passHistoryList;
        public passhistory(List<string> passHistory)
        {
            InitializeComponent();
            passHistoryList = passHistory;
            if (passHistoryList.Count() >= 1)
            {
                pass1.Text = passHistoryList[0];
            }

            if (passHistoryList.Count() >= 2)
            {
                pass2.Text = passHistoryList[1];
            }

            if (passHistoryList.Count() >= 3)
            {
                pass3.Text = passHistoryList[2];
            }

            if (passHistoryList.Count() >= 4)
            {
                pass4.Text = passHistoryList[3];
            }

            if (passHistoryList.Count() >= 5)
            {
                pass5.Text = passHistoryList[4];
            }

            if (passHistoryList.Count() >= 6)
            {
                pass6.Text = passHistoryList[5];
            }

        }

        private void passhistory_Load(object sender, EventArgs e)
        {
            
        }

        private void deleteHistory_Click(object sender, EventArgs e)
        {
            passHistoryList.Clear();
            this.Close();
        }
    }
}
