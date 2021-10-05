using System;
using System.Windows.Forms;
using System.IO;


namespace Pacman
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            lbPlay.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);
            lbAuthorization.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);
            lbResults.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);
            lbExit.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);

            lbPlay.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
            lbAuthorization.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
            lbResults.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
            lbExit.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
        }

        private void LbPlay_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            if (string.IsNullOrEmpty(Methods.GetCurrentUser().login))
            {
                Authorization authorization = new Authorization();
                authorization.Show();
            }
            else
            {
                Game game = new Game();
                game.Show();
            }
        }
        private void LbAuthorization_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Authorization authorization = new Authorization();
            authorization.Show();
        }
        private void LbResults_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Results results = new Results();
            results.Show();
        }

        private void LbExit_Click(object sender, EventArgs e)
        {
            File.Delete(Resource.CurrentUserPath);
            Application.Exit();
        }
    }
}
