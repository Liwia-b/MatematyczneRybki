using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematyczne_Rybki
{

    public class Rybki
    {

        public int x, y, ySin;
        public PictureBox Rybka;
        public Label Rownanie;
        public int liczbaRybki;
        private Gra main;

        public bool prawo = false;
        public int predkoscRybek = 1;

        public Rybki(Gra main, string img, int x, int y)
        {
            this.main = main;
            this.x = x;
            this.y = y;
            int zoomFactor = 2;

            Rybka = new PictureBox();
            Rownanie = new Label();

            Random rnd = new Random();

            liczbaRybki = rnd.Next(1, 100);
            Rownanie.Text = liczbaRybki.ToString();
            Rownanie.Visible = false;

            Rybka.Image = Image.FromFile(img);
            if (rnd.Next(1, 3) == 1)
            {
                prawo = true;
                Image nowaRybka = Rybka.Image;
                nowaRybka.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Rybka.Image = nowaRybka;
            }
            Rybka.Visible = true;

            Rybka.Size = new Size(Rybka.Image.Width / zoomFactor, Rybka.Image.Height / zoomFactor);
            Rybka.SizeMode = PictureBoxSizeMode.StretchImage;
            Rybka.BackColor = Color.Transparent;

            y = (int)(y + Math.Sin(x / 100.0) * 150);
            Rybka.Location = new Point(x, y);
            Rownanie.Location = new Point(Rybka.Location.X + Rybka.Size.Width / 5, y + 75);
            main.Paint += new PaintEventHandler(paintRybka);
        }

        // rysowanie rybki
        private void paintRybka(object sender, PaintEventArgs e)
        {
            if (Rybka.Visible == true)
            {
                e.Graphics.DrawImage(Rybka.Image, Rybka.Left, Rybka.Top, Rybka.Width, Rybka.Height);
            }

            if (Rybka.Visible == true && Rownanie.Visible == true)
            {
                Size rozmiar = TextRenderer.MeasureText(Rownanie.Text, Rownanie.Font);
                Rectangle tlo = new Rectangle(Rownanie.Location, rozmiar);
                e.Graphics.FillRectangle(Brushes.White, tlo);
                e.Graphics.DrawString(Rownanie.Text, Rownanie.Font, new SolidBrush(Rownanie.ForeColor), Rownanie.Location);
            }

        }

        public void animacjaGracza(int innaRybka)
        {

            ySin = (int)(y + Math.Sin(innaRybka / 100.0) * 50);
            if (ySin > main.Height - Rybka.Size.Height)
                ySin = main.Height - Rybka.Size.Height;

            if (ySin < 0) ySin = 0;

            Rownanie.Location = new Point(x + Rybka.Size.Width / 6, ySin + 75);
            Rybka.Location = new Point(x, ySin);
        }

        public void animacjaRybek()
        {
            if (prawo)
            {
                x += predkoscRybek;
            }
            else
            {
                x -= predkoscRybek;
            }

            if (x > main.Width - Rybka.Size.Width)
            {
                x = main.Width - Rybka.Size.Width;
                Image nowaRybka = Rybka.Image;
                nowaRybka.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Rybka.Image = nowaRybka;
                prawo = false;
            }

            if (x <= 0)
            {
                x = 0;
                Image tmp = Rybka.Image;
                tmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Rybka.Image = tmp;
                prawo = true;
            }

            ySin = (int)(y + Math.Sin(x / 100.0) * 150);
            if (ySin > main.Height - Rybka.Size.Height)
                ySin = main.Height - Rybka.Size.Height;

            if (ySin < 0) ySin = 0;

            Rownanie.Location = new Point(x + Rybka.Size.Width / 6, ySin + 75);
            Rybka.Location = new Point(x, ySin);
            main.Invalidate();
        }

    }

}
