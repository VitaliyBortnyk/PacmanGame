using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman
{
    class Ghost : GameObject
    {
        public string name { get; private set; }
        public bool right { get; set; }
        public bool left { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public bool eaten { get; set; }
        public bool superModActivated { get; set; }

        public PictureBox target { get; private set; }

        public Ghost(Form form, string name, Image image,
            int startLocationX, int startLocationY, int spead, int[,] map, List<int> wrongWay, PictureBox target, int sizeOfSides)
            : base(form.Controls, image, startLocationX, startLocationY, spead, map, wrongWay, sizeOfSides)
        {
            this.name = name;
            right = false;
            left = false;
            up = false;
            down = false;
            eaten = false;
            superModActivated = false;
            this.target = target;
        }

        private int IndexX(PictureBox gameObject)
        {
            return gameObject.Location.X / sizeOfSides;
        }
        private int IndexY(PictureBox gameObject)
        {
            return gameObject.Location.Y / sizeOfSides;
        }

        public override void Move(int x, int y)
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
                    }
                }

                if (CheckMatrixValue(map, objectPicture, x, y).Equals(4) || CheckMatrixValue(map, objectPicture, x, y).Equals(5))
                    Controller(0);

                objectPicture.Location = new Point(
                 objectPicture.Location.X + x,
                 objectPicture.Location.Y + y);
            }
            else
            {
                objectTimer.Stop();
                Controller(CheckMatrixValue(map, objectPicture, x, y));
            }

        }
        public void Controller(int index)
        {
            if (dirX.Equals(0) && dirY.Equals(0) && index.Equals(0))
            {
                dirX = 1;
                dirY = 0;
                right = false;
                up = false;
                down = false;
                left = true;
                objectTimer.Start();
            }
            else if ((IndexX(objectPicture) < IndexX(target)) && left.Equals(false) && right.Equals(false))
            {
                dirY = 0;
                right = false;
                up = false;
                down = false;
                left = false;

                if (superModActivated && !eaten)
                {
                    dirX = -1;
                    right = true;
                }
                else
                {
                    dirX = 1;
                    left = true;
                }
                objectTimer.Start();
            }
            else if ((IndexX(objectPicture) > IndexX(target)) && right.Equals(false) && left.Equals(false))
            {
                dirY = 0;
                left = false;
                up = false;
                down = false;
                right = false;

                if (superModActivated && !eaten)
                {
                    dirX = 1;
                    left = true;
                }
                else
                {
                    dirX = -1;
                    right = true;
                }
                objectTimer.Start();
            }
            else if ((IndexY(objectPicture) < IndexY(target)) && down.Equals(false) && up.Equals(false))
            {
                dirX = 0;
                up = false;
                right = false;
                left = false;
                down = false;

                if (superModActivated && !eaten)
                {
                    dirY = -1;
                    up = true;
                }
                else
                {
                    dirY = 1;
                    down = true;
                }
                objectTimer.Start();
            }
            else if ((IndexY(objectPicture) > IndexY(target)) && up.Equals(false) && down.Equals(false))
            {
                dirX = 0;
                down = false;
                right = false;
                left = false;
                up = false;

                if (superModActivated && !eaten)
                {
                    dirY = 1;
                    down = true;
                }
                else
                {
                    dirY = -1;
                    up = true;
                }
                objectTimer.Start();
            }
            else if (IndexX(objectPicture) < IndexX(target) && IndexY(objectPicture).Equals(IndexY(target)))
            {
                dirY = 0;
                right = false;
                up = false;
                down = false;
                left = false;

                if (superModActivated && !eaten)
                {
                    dirX = -1;
                    right = true;
                }
                else
                {
                    dirX = 1;
                    left = true;
                }
                objectTimer.Start();
            }
            else if (IndexX(objectPicture) > IndexX(target) && IndexY(objectPicture).Equals(IndexY(target)))
            {
                dirY = 0;
                right = false;
                up = false;
                down = false;
                left = false;

                if (superModActivated && !eaten)
                {
                    dirX = 1;
                    left = true;
                }
                else
                {
                    dirX = -1;
                    right = true;
                }
                objectTimer.Start();
            }
            else if (IndexX(objectPicture).Equals(IndexX(target)) && IndexY(objectPicture) < IndexY(target))
            {
                dirX = 0;
                up = false;
                right = false;
                left = false;
                down = false;

                if (superModActivated && !eaten)
                {
                    dirY = -1;
                    up = true;
                }
                else
                {
                    dirY = 1;
                    down = true;
                }
                objectTimer.Start();
            }
            else if (IndexX(objectPicture).Equals(IndexX(target)) && IndexY(objectPicture) > IndexY(target))
            {

                dirX = 0;
                down = false;
                right = false;
                left = false;
                up = false;

                if (superModActivated && !eaten)
                {
                    dirY = 1;
                    down = true;
                }
                else
                {
                    dirY = -1;
                    up = true;
                }
                objectTimer.Start();
            }
            else if ((IndexX(objectPicture) < IndexX(target)) && right.Equals(false) || down.Equals(true) || up.Equals(true))
            {
                dirY = 0;
                right = false;
                up = false;
                down = false;
                left = false;

                if (superModActivated && !eaten)
                {
                    dirX = -1;
                    right = true;
                }
                else
                {
                    dirX = 1;
                    left = true;
                }
                objectTimer.Start();
            }
            else if ((IndexX(objectPicture) > IndexX(target)) && left.Equals(false) || up.Equals(true) || down.Equals(true))
            {

                dirY = 0;
                right = false;
                up = false;
                down = false;
                left = false;

                if (superModActivated && !eaten)
                {
                    dirX = 1;
                    left = true;
                }
                else
                {
                    dirX = -1;
                    right = true;
                }
                objectTimer.Start();
            }
            else if ((IndexY(objectPicture) < IndexY(target)) && up.Equals(false) || left.Equals(true) || right.Equals(true))
            {
                dirX = 0;
                up = false;
                right = false;
                left = false;
                down = false;

                if (superModActivated && !eaten)
                {
                    dirY = -1;
                    up = true;
                }
                else
                {
                    dirY = 1;
                    down = true;
                }
                objectTimer.Start();
            }
            else if ((IndexY(objectPicture) > IndexY(target)) && down.Equals(false) || right.Equals(true) || left.Equals(true))
            {
                dirX = 0;
                down = false;
                right = false;
                left = false;
                up = false;

                if (superModActivated && !eaten)
                {
                    dirY = 1;
                    down = true;
                }
                else
                {
                    dirY = -1;
                    up = true;
                }
                objectTimer.Start();
            }
        }

    }
}
