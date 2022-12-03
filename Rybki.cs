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
        public Label Rownanie;
        private Gra main;

        public Rybki(Gra main, string img, int x, int y)
        {
            this.main = main;
            this.x = x;
            this.y = y;
            int zoomFactor = 2;

            Rybka = new PictureBox();
            Rownanie = new Label();
            
            Rownanie.Text = "60*(400+200)";
            Rownanie.BackColor = Color.White;
            Rownanie.AutoSize = true;
            Rybka.Image = Image.FromFile(img);

            Rybka.Size = new Size(Rybka.Image.Width / zoomFactor, Rybka.Image.Height / zoomFactor);
            Rybka.SizeMode = PictureBoxSizeMode.StretchImage;
            Rybka.BackColor = Color.Transparent;
            
            Rybka.Location = new Point(x, y);
            Rownanie.Location = new Point(Rybka.Location.X+Rybka.Size.Width/3, y+75);
            main.Paint += new System.Windows.Forms.PaintEventHandler(paint);
            main.Controls.Add(Rownanie);
            
        }

        // rysowanie rybki
        private void paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Rybka.Image, Rybka.Left, Rybka.Top, Rybka.Width, Rybka.Height);
        }

    }
    
}
