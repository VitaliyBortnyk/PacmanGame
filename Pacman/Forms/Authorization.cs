using System;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Authorization : Form
    {
        private bool isChanged;
        private GameAuthorization gameAuthorization;

        public Authorization()
        {
            InitializeComponent();

            isChanged = false;
            gameAuthorization = new GameAuthorization();

            pbVisible.Image = Resource.visible;
            pbVisible.Cursor = System.Windows.Forms.Cursors.Hand;

            lbLogIn.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);
            lbRegistration.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);
            lbMenu.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);

            lbLogIn.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
            lbRegistration.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
            lbMenu.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
        }

        private void PasswordVisible(PictureBox clicableImage, TextBox passwordTB)
        {
            if (!isChanged)
            {
                clicableImage.Image = Resource.invisible;
                passwordTB.UseSystemPasswordChar = false;
                isChanged = true;
            }
            else
            {
                clicableImage.Image = Resource.visible;
                passwordTB.UseSystemPasswordChar = true;
                isChanged = false;
            }
        }

        private void PbVisible_Click(object sender, EventArgs e)
        {
            PasswordVisible(pbVisible, tbPassword);
        }

        private void tbNickname_TextChanged(object sender, EventArgs e)
        {
            gameAuthorization.enteredLogin = tbNickname.Text;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            gameAuthorization.enteredPassword = tbPassword.Text;
        }

        private void ClearTextBox(TextBox nicknameTB, TextBox passwordTB)
        {
            nicknameTB.Text = string.Empty;
            passwordTB.Text = string.Empty;
        }

        private void UpdateMessages(Label incorectNickLB, Label incorectPasswordLB)
        {
            incorectNickLB.Text = gameAuthorization.incorectLogin;
            incorectPasswordLB.Text = gameAuthorization.incorectPassword;
            if(gameAuthorization.isEmptyString)
            {
                InfoForm infoForm = new InfoForm();
                infoForm.EmptyTextBoxs();
                infoForm.ShowDialog();
            }
        }

        private void ClearMessages(Label incorectNickLB, Label incorectPasswordLB)
        {
            gameAuthorization.incorectLogin = string.Empty;
            gameAuthorization.incorectPassword = string.Empty;
            gameAuthorization.isEmptyString = false;

            UpdateMessages(incorectNickLB, incorectPasswordLB);
        }

        private void LbLogIn_Click(object sender, EventArgs e)
        {
            ClearMessages(lbIncorectNick, lbIncorectPassword);

            if (gameAuthorization.LogIn())
            {
                Game game = new Game();
                game.Show();
                this.Close();
            }
            else
                UpdateMessages(lbIncorectNick, lbIncorectPassword);
        }

        private void LbRegistration_Click(object sender, EventArgs e)
        {
            ClearMessages(lbIncorectNick, lbIncorectPassword);

            if (gameAuthorization.Registration())
            {
                InfoForm infoForm = new InfoForm();
                infoForm.Registered(gameAuthorization.enteredLogin);
                infoForm.Show();
                ClearTextBox(tbNickname, tbPassword);
            }
            else
                UpdateMessages(lbIncorectNick, lbIncorectPassword);
        }

        private void LbMenu_Click(object sender, EventArgs e)
        {
            this.Close();

            Menu menu = new Menu();
            menu.Visible = true;
        }

        private void TextBox_Validator(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 64 || e.KeyChar >= 91 &&
                e.KeyChar <= 96 || e.KeyChar >= 123) && symbol != 8 && symbol != 95)
            {
                e.Handled = true;
            }
        }
    }
}
