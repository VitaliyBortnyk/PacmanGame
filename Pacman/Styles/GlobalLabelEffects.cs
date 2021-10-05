using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Pacman
{
    static class GlobalLabelEffects
    {
        public static void ItemHover(object sender, EventArgs e)
        {
            SoundPlayer select = new SoundPlayer(Resource.itemHover);
            select.Play();
            ((Label)sender).Font = new Font("Showcard Gothic", 32F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ((Label)sender).ForeColor = Color.OrangeRed;
            ((Label)sender).Cursor = Cursors.Hand;
        }
        public static void ItemLeave(object sender, EventArgs e)
        {
            ((Label)sender).Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ((Label)sender).ForeColor = Color.Orange;
        }
    }
}
