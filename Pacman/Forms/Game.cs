using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace Pacman
{
    public partial class Game : Form
    {
        private Gameplay gameplay { get; set; }
        public Panel ldPanel { get; private set; }
        public ProgressBar pbLoading { get; private set; }
        public Label lbScore { get; set; }
        public Label lbLives { get; set; }
        public Label lbMenu { get; private set; }
        public Panel gameEnd { get; set; }

        public Game()
        {
            InitializeComponent();

            Width = 1000;
            Height = 775;

            Loading();
            GameBar();
            gameplay = new Gameplay(this);

            lbMenu.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);
            lbMenu.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);
            lbMenu.MouseClick += new MouseEventHandler(lbMenu_Click);
        }

        public void Loading()
        {
            ldPanel = new Panel()
            {
                Size = new Size(Width, Height),
                BackColor = Color.Black
            };

            ldPanel.Controls.Add(new Label()
            {
                Size = new Size(300, 55),
                Font = new Font("Showcard Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Orange,
                Location = new Point(380, 300),
                Text = "Loading..."
            }
            );

            ldPanel.Controls.Add(pbLoading = new ProgressBar()
            {
                Style = ProgressBarStyle.Continuous,
                Location = new Point(300, 375),
                Size = new Size(400, 50),
                ForeColor = Color.Yellow,
            });
            
            ldPanel.BringToFront();
            Controls.Add(ldPanel);
            loadingTimer.Start();
        }

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            pbLoading.Increment(1);

            if (pbLoading.Value.Equals(pbLoading.Maximum))
            {
                ldPanel.Visible = false;
                gameplay.VisibleGameObjects(true);
                Methods.PlaySound("gameStart.wav");
                introTimer.Start();
                loadingTimer.Stop();
            }
        }

        private void introTimer_Tick(object sender, EventArgs e)
        {
            gameplay.GameStart();
            introTimer.Stop();
        }

        private void GameBar()
        {
            float fontSize = 0;

            Controls.Add(new Label()
            {
                Size = new Size(250, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Showcard Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Gold,
                Location = new Point(710, 50),
                Text = "Nickname:"
            });

            if (Methods.GetCurrentUser().login.Length == 16)
                fontSize = 7;
            else if (Methods.GetCurrentUser().login.Length >= 13)
                fontSize = 16;
            else if (Methods.GetCurrentUser().login.Length >= 8)
                fontSize = 20;
            else if (Methods.GetCurrentUser().login.Length >= 6)
                fontSize = 24;
            else
                fontSize = 28.2F;

            Controls.Add(new Label()
            {
                Size = new Size(280, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Broadway", fontSize, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Yellow,
                Location = new Point(710, 100),
                Text = Methods.GetCurrentUser().login
            });

            Controls.Add(new Label()
            {
                Size = new Size(280, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Showcard Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Magenta,
                Location = new Point(710, 200),
                Text = "Score"
            });

            Controls.Add(lbScore = new Label()
            {
                Size = new Size(280, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Broadway", 28.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Yellow,
                Location = new Point(710, 250),
                Text = "0"
            });

            Controls.Add(new Label()
            {
                Size = new Size(280, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Showcard Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Red,
                Location = new Point(710, 350),
                Text = "Lives"
            });

            Controls.Add(lbLives = new Label()
            {
                Size = new Size(280, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Broadway", 28.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Yellow,
                Location = new Point(710, 400),
                Text = "2"
            });

            Controls.Add(lbMenu = new Label()
            {
                Size = new Size(280, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Showcard Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.Orange,
                Location = new Point(710, 700),
                Text = "Menu"
            });
        }

        private void lbMenu_Click(object sender, EventArgs eventArgs)
        {
            gameplay.GameOver("");
        }

        public void GoMenu()
        {
            Close();

            Menu menu = new Menu();
            menu.Visible = true;
        }
    }
}
