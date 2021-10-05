using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    abstract class GameObject
    {
        public int dirX { get; set; }
        public int dirY { get; set; }
        public int sizeOfSides { get; private set; }
        public int startLocationX { get; private set; }
        public int startLocationY { get; private set; }
        public int spead { get; set; }

        public int[,] map { get; private set; }
        public List<int> wrongWay { get; private set; }
        
        public PictureBox objectPicture { get; set; }
        public Image objectImage { get; private set; }
        public Timer objectTimer { get; set; }

        public Control.ControlCollection controls { get; private set; }


        public GameObject(Control.ControlCollection controls, Image image,
            int startLocationX, int startLocationY, int spead, int[,]map, List<int> wrongWay, int sizeOfSides)
        {
            this.sizeOfSides = sizeOfSides;
            this.startLocationX = startLocationX;
            this.startLocationY = startLocationY;
            this.map = map;
            this.wrongWay = wrongWay;
            this.controls = controls;
            this.spead = spead;
            objectTimer = new Timer();
            objectImage = image;
            Create();
            Spawn();
            objectTimer.Interval = spead;
            objectTimer.Tick += new EventHandler(Update);
        }

        private void Create()
        {
            objectPicture = new PictureBox();
            objectPicture.Image = objectImage;
            objectPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            objectPicture.Size = new Size(sizeOfSides, sizeOfSides);
            controls.Add(objectPicture);
            objectPicture.BringToFront();
        }

        public void Spawn()
        {
            dirX = 0;
            dirY = 0;
            objectPicture.Location = new Point(startLocationX, startLocationY);
        }

        private void Update(object sender, EventArgs eventArgs)
        {
            Move(dirX * sizeOfSides, dirY * sizeOfSides);
        }

        public int CheckMatrixValue(int[,] mapArray, PictureBox gameObject, int x, int y)
        {
            int value = 0;

            try
            {
                value = mapArray[(gameObject.Location.Y + y) / sizeOfSides, (gameObject.Location.X + x) / sizeOfSides];
            }
            catch { return 0; }

            return value;
        }

        private bool IsWay(int x, int y)
        {
            if (!wrongWay.Exists(item => item.Equals(CheckMatrixValue(map, objectPicture, x, y))))
            {
                foreach (Control item in controls)
                {
                    if (new Point(objectPicture.Location.X + x, objectPicture.Location.Y + y)
                        .Equals(item.Location))
                    {
                        if (item.Name.Equals("A"))
                            objectPicture.Location = controls.Find("B", true)[0].Location;
                        if (item.Name.Equals("B"))
                            objectPicture.Location = controls.Find("A", true)[0].Location;

                        return true;
                    }
                }
            }
            return false;
        }

        public virtual void Move(int x, int y)
        {
            if(IsWay(x, y))
                 objectPicture.Location = new Point(
                 objectPicture.Location.X + x,
                 objectPicture.Location.Y + y);
        }
    }
}
