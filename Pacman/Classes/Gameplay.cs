using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Media;

namespace Pacman
{
    class Gameplay
    { 
        public int mapWidth { get; private set; }
        public int mapHeight { get; private set; }
        public int sizeOfSides { get; private set; }
        public int livesCount { get; private set; }
        public int score { get; private set; }
        public int attemptCount { get; private set; }
        public int eatenCount { get; private set; }
        public int[,] mapArray { get; private set; }
        public bool superModActivated { get; private set; }

        public Player player { get; private set; }
        public List<Ghost> ghosts { get; private set; }
        public GameResults gameResults { get; private set; }
        public Game form { get; private set; }
        public System.Windows.Forms.Timer superModTimer { get; private set; }

        public Gameplay(Game form)
        {
            mapWidth = 28;
            mapHeight = 31;
            sizeOfSides = 25;
            livesCount = 2;
            score = 0;
            attemptCount = 0;
            eatenCount = 0;
            superModActivated = false;

            this.form = form;

            superModTimer = new System.Windows.Forms.Timer();
            superModTimer.Interval = 10000;
            superModTimer.Tick += new EventHandler(SuperModTimer_Tick);

            ghosts = new List<Ghost>();

            GenerateMap();
            CreateGameObjects();
            VisibleGameObjects(false);


            gameResults = new GameResults();

            player.objectTimer.Tick += new EventHandler(AccumulationScore);
            player.objectTimer.Tick += new EventHandler(UsingAttempt);
        }
        ~Gameplay() { }

        private void PlaySounds(UnmanagedMemoryStream sound)
        {
            SoundPlayer player = new SoundPlayer(sound);
            player.Play();
        }

        private void ReadMapArray()
        {
            try
            {
                string[] lines = File.ReadAllLines("Map.txt");
                mapArray = new int[lines.Length, lines[0].Split(' ').Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] temp = lines[i].Split(' ');
                    for (int j = 0; j < temp.Length; j++)
                        mapArray[i, j] = Convert.ToInt32(temp[j]);
                }
            }
            catch { MessageBox.Show("Не вдалося завантажити карту, будь ласка перевірте наявність файлу Map.txt",
                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); };
        }
        private void GenerateMap()
        {
            ReadMapArray();

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (!mapArray[i, j].Equals(1))
                    {
                        string name = "freeZone";

                        if (mapArray[i, j].Equals(7))
                            name = "A";
                        else if (mapArray[i, j].Equals(8))
                            name = "B";
                        
                        form.Controls.Add(new PictureBox()
                        {
                            BackColor = Color.Black,
                            Name = name,
                            Size = new Size(sizeOfSides, sizeOfSides),
                            Location = new Point(j * sizeOfSides, sizeOfSides * i),
                            Visible = false
                        });
                    }
                    if (mapArray[i, j].Equals(1) || mapArray[i, j].Equals(6))
                    {
                        form.Controls.Add(new PictureBox()
                        {
                            BackColor = Color.Blue,
                            Size = new Size(sizeOfSides, sizeOfSides),
                            Location = new Point(j * sizeOfSides, sizeOfSides * i)
                        });
                    }
                    else if (mapArray[i, j].Equals(2) || mapArray[i, j].Equals(4))
                    {
                        form.Controls.Add(new PictureBox()
                        {
                            Image = Resource.coin,
                            Name = "coin",
                            Size = new Size(sizeOfSides, sizeOfSides),
                            Location = new Point(j * sizeOfSides, sizeOfSides * i)
                        });
                    }
                    else if (mapArray[i, j].Equals(3))
                    {
                        form.Controls.Add(new PictureBox()
                        {
                            Image = Resource.big_coin,
                            Name = "bigCoin",
                            Size = new Size(sizeOfSides, sizeOfSides),
                            Location = new Point(j * sizeOfSides, sizeOfSides * i)
                        });
                    }
                }
            }
        }
        private void CreateGameObjects()
        {
            player = new Player(form, Resource.pacdx, 350, 575, 200, mapArray, new List<int>() { 1, 6 }, sizeOfSides);
            ghosts.Add(new Ghost(form, "red", Resource.rup, 275, 275, 250, mapArray, new List<int>() { 1 }, player.objectPicture, sizeOfSides));
            ghosts.Add(new Ghost(form, "blue", Resource.bup, 300, 350, 200, mapArray, new List<int>() { 1 }, player.objectPicture, sizeOfSides));
            ghosts.Add(new Ghost(form, "pink", Resource.pup, 400, 275, 210, mapArray, new List<int>() { 1 }, player.objectPicture, sizeOfSides));
            ghosts.Add(new Ghost(form, "orange", Resource.oup, 375, 350, 250, mapArray, new List<int>() { 1 }, player.objectPicture, sizeOfSides));
        }

        public void GameStart()
        {
            player.objectTimer.Start();
            ghosts.Find(item => item.name.Equals("red")).Controller(0);
            ghosts.Find(item => item.name.Equals("pink")).Controller(0);

        }

        private void AccumulationScore(object sender, EventArgs eventArgs)
        {
            if (form.Controls.Find("coin", true).Length.Equals(0)
                && form.Controls.Find("bigCoin", true).Length.Equals(0)
                && form.Controls.Find("coinPoint", true).Length.Equals(0))
                GameOver("win");


            foreach (Control control in form.Controls)
            {
                if (player.objectPicture.Location.Equals(control.Location))
                    if (control.Name.Equals("coin") || control.Name.Equals("coinPoint"))
                    {
                        PlaySounds(Resource.credit);
                        form.Controls.Remove(control);
                        score += 10;
                    }
                    else if (control.Name.Equals("bigCoin"))
                    {
                        PlaySounds(Resource.credit);
                        form.Controls.Remove(control);
                        score += 30;
                        SuperMod();
                    }
            }
            form.lbScore.Text = score.ToString();

            if (score >= 300)
            {
                ghosts.Find(item => item.name.Equals("blue")).Controller(0);
            }

            if (score >= 1200)
            {
                ghosts.Find(item => item.name.Equals("orange")).Controller(0);
            }
        }

        private void EatGhost(Ghost ghost)
        {
            Methods.PlaySound("eatGhosts.wav");

            eatenCount++;

            ghost.eaten = true;
            ghost.superModActivated = false;
            ghost.objectPicture.Image = ghost.objectImage;
            ghost.objectTimer.Interval = ghost.spead;
            ghost.Spawn();
            ghost.Controller(0);

            score += eatenCount * 200;
        }
        
        private void UsingAttempt(object sender, EventArgs eventArgs)
        {
            if (ghosts.Any(item => item.objectPicture.Location.Equals(player.objectPicture.Location)))
            {
                if (superModActivated && ghosts.Any(item => item.objectPicture.Location
                    .Equals(player.objectPicture.Location) && !item.eaten))
                    EatGhost(ghosts.Find(item => item.objectPicture.Location
                    .Equals(player.objectPicture.Location) && !item.eaten));
                else
                {
                    PlaySounds(Resource.death);
                    VisibleGameObjects(false);

                    Thread.Sleep(3000);

                    player.Spawn();
                    foreach (Ghost ghost in ghosts)
                    {
                        ghost.Spawn();
                        ghost.Controller(0);
                    }

                    attemptCount++;

                    if ((livesCount - 1).Equals(-1))
                    {
                        GameOver("lose");
                    }
                    else
                    {
                        livesCount -= 1;
                        foreach (Ghost ghost in ghosts)
                            ghost.objectPicture.Image = ghost.objectImage;
                        VisibleGameObjects(true);
                    }
                }
            }
            form.lbLives.Text = livesCount.ToString();
        }

        public void GameOver(string result)
        {
            SaveResult(Methods.GetCurrentUser().login, score, attemptCount);

            Image resultImage;

            player.objectTimer.Stop();
            player.objectPicture.Visible = false;

            foreach (Ghost ghost in ghosts)
            {
                ghost.objectTimer.Stop();
                ghost.objectPicture.Visible = false;
            }

            if (result.Equals("win"))
                resultImage = Resource.gameWin;
            else if (result.Equals("lose"))
                resultImage = Resource.gameOver;
            else
                resultImage = Resource.goMenu;

            form.Controls.Add(form.gameEnd = new Panel()
            {
                Width = form.Width,
                Height = form.Height,
                BackgroundImage = resultImage
            });

            form.gameEnd.BringToFront();

            Thread.Sleep(3000);

            form.GoMenu();
        }

        public void VisibleGameObjects(bool value)
        {
            player.objectPicture.Visible = value;
            foreach (Ghost ghost in ghosts)
                ghost.objectPicture.Visible = value;
        }

        private void SuperMod()
        {
            superModTimer.Stop();

            superModActivated = true;

            foreach (Ghost ghost in ghosts)
            {
                ghost.objectPicture.Image = Resource.crazy;
                ghost.eaten = false;
                ghost.objectTimer.Interval = 350;
                ghost.superModActivated = true;
            }

            superModTimer.Start();
        }

        private void SuperModTimer_Tick(object sender, EventArgs eventArgs)
        {
            superModActivated = false;

            foreach (Ghost ghost in ghosts)
            {
                ghost.objectPicture.Image = ghost.objectImage;
                ghost.objectTimer.Interval = ghost.spead;
                ghost.superModActivated = false;
            }
            
            eatenCount = 0;
            superModTimer.Stop();
        }

        private void SaveResult(string nickname, int score, int attempt)
        {
            if (score.Equals(0))
                return;
            else
            {
                gameResults.SetResultsValue(new Result(nickname, score, attempt));
                Methods.Save(Resource.ResultsPath, FileMode.OpenOrCreate, gameResults.resultsList);
            }
        }
    }
}
