using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematyczne_Rybki
{
    internal class menu
    {

        private int padding = 20;
        private int pomniejszenie = 2;
        private Gra main;
        public bool widoczne = false;
        public PictureBox psklep, pmenu;
        private Rectangle pasekczasu, tlopaskaczasu;
        private int szerokoscpaskaczasu = 150;
        private Label czas, nazwagracza, poziom, pieniadze;
        private static Image omenu = Image.FromFile("../../../Zasoby/Inne/menu.png");
        private static Image osklep = Image.FromFile("../../../Zasoby/Inne/sklep.png");

        public menu(Gra main)
        {
            this.main = main;

            // ikony menu i sklepu
            psklep = new PictureBox();
            pmenu = new PictureBox();

            pmenu.Size = new Size(omenu.Width / pomniejszenie, omenu.Height / pomniejszenie);
            psklep.Size = new Size(osklep.Width / pomniejszenie, osklep.Height / pomniejszenie);

            pmenu.Location = new Point(padding, padding);
            psklep.Location = new Point(padding + pmenu.Width + padding, padding);

            pmenu.Image = omenu;
            psklep.Image = osklep;

            // czasomierz
            int paddingpaska = 10;
            pasekczasu = new Rectangle();
            pasekczasu.Size = new Size(szerokoscpaskaczasu, 25);

            tlopaskaczasu = new Rectangle();
            tlopaskaczasu.Size = new Size(pasekczasu.Width+paddingpaska, pasekczasu.Height + paddingpaska);

            tlopaskaczasu.Location = new Point(Gra.rozmiaroknaX - tlopaskaczasu.Width - padding, padding*3);
            pasekczasu.Location = new Point(tlopaskaczasu.X+paddingpaska/2, tlopaskaczasu.Y+paddingpaska/2);

            czas = new Label();
            czas.Text = "CZAS: XX";

            nazwagracza = new Label();
            nazwagracza.Text = "Liwia";

            pieniadze = new Label();
            pieniadze.Text = "500";
            pieniadze.Location = new Point(psklep.Location.X + psklep.Width, psklep.Location.Y + 7);

            poziom = new Label();
            poziom.Text = "POZIOM: 1";

            main.Paint += new PaintEventHandler(paintMenu);
        }

        private void paintMenu(object sender, PaintEventArgs e)
        {
            
            Pen obrys = new Pen(Color.Black, 5);
            Brush bialy = new SolidBrush(Color.WhiteSmoke);
            Brush rozowy = new SolidBrush(Color.LightCoral);
            Brush zielony = new SolidBrush(Color.Green);


            Font czcionka = new Font("Arial", 24, FontStyle.Bold);

            if (widoczne == true)
            {
                e.Graphics.DrawImage(pmenu.Image, pmenu.Left, pmenu.Top, pmenu.Width, pmenu.Height);
                e.Graphics.DrawImage(psklep.Image, psklep.Left, psklep.Top, psklep.Width, psklep.Height);
                e.Graphics.DrawString(pieniadze.Text, czcionka, zielony, pieniadze.Location);


                e.Graphics.DrawRectangle(obrys, tlopaskaczasu);
                e.Graphics.DrawRectangle(obrys, pasekczasu);

                e.Graphics.FillRectangle(bialy, tlopaskaczasu);
                e.Graphics.FillRectangle(rozowy, pasekczasu);

                // gracz
                SizeF szerokoscGracza = e.Graphics.MeasureString(nazwagracza.Text, czcionka);
                nazwagracza.Location = new Point(tlopaskaczasu.X + (tlopaskaczasu.Width - (int)szerokoscGracza.Width) / 2, tlopaskaczasu.Y - tlopaskaczasu.Height - 10);
                e.Graphics.DrawString(nazwagracza.Text, czcionka, rozowy, nazwagracza.Location);

                // czas
                SizeF szerokoscCzasu = e.Graphics.MeasureString(czas.Text, czcionka);
                czas.Location = new Point(tlopaskaczasu.X + (tlopaskaczasu.Width - (int)szerokoscCzasu.Width) / 2, tlopaskaczasu.Y + tlopaskaczasu.Height + 10);
                e.Graphics.DrawString(czas.Text, czcionka, bialy, czas.Location);

            }
        }

        public void zaktualizujCzas(int czasAktualny, int czasUstawiony)
        {
            czas.Text = "CZAS: " + czasAktualny.ToString();
            pasekczasu.Width = (szerokoscpaskaczasu * czasAktualny) / czasUstawiony;
        }

    }
}
