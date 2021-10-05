using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        public void Registered(string nickname)
        {
            lbMessage.Text = "User with the nickname \"" + nickname + "\" is registered!";
        }

        public void EmptyTextBoxs()
        {
            lbMessage.Text = "You haven't entered a nickname or password!";
            lbMessage.ForeColor = Color.Red;
        }

        public void EmptyTextBox()
        {
            lbMessage.Text = "You haven't entered a nickname!";
            lbMessage.ForeColor = Color.Red;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
