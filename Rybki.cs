using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematyczne_Rybki
{

    public class Rybki
    {
        public int x, y;
        public PictureBox Rybka;
        private Gra main;

        public Rybki(Gra main, string img, int x, int y)
        {
            this.main = main;
            this.x = x;
            this.y = y;

            Random rnd = new Random();
            int num = rnd.Next(400);

            Rybka = new PictureBox();
            Rybka.Image = Image.FromFile(img);
            Rybka.SizeMode = PictureBoxSizeMode.Zoom;
            Rybka.BackColor = Color.Transparent;
            Rybka.Location = new Point(x-num, y-num);
            main.Paint += new System.Windows.Forms.PaintEventHandler(paint);
        }

        // rysowanie rybki
        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Rybka.Image, Rybka.Left, Rybka.Top, Rybka.Width, Rybka.Height);
        }

    }
    
}
