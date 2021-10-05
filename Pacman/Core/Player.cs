using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    class Player : GameObject
    {
        public Player(Form form, Image image,
            int startLocationX, int startLocationY, int spead, int[,]map, List<int> wrongWay, int sizeOfSides)
            : base(form.Controls, image, startLocationX, startLocationY, spead, map, wrongWay, sizeOfSides)
        {
            form.KeyDown += new KeyEventHandler(KeyboardControl);
        }

        private void KeyboardControl(object sender, KeyEventArgs eventArgs)
        {
            switch (eventArgs.KeyCode)
            {
                case Keys.D:
                    dirX = 1;
                    dirY = 0;
                    objectPicture.Image = Resource.pacdx;
                    break;
                case Keys.A:
                    dirX = -1;
                    dirY = 0;
                    objectPicture.Image = Resource.pacsx;
                    break;
                case Keys.W:
                    dirY = -1;
                    dirX = 0;
                    objectPicture.Image = Resource.pacup;
                    break;
                case Keys.S:
                    dirY = 1;
                    dirX = 0;
                    objectPicture.Image = Resource.pacdown;
                    break;
            }
        }
    }
}
