using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematyczne_Rybki
{
    public partial class Gra : Form
    {
        //timer
        private System.Timers.Timer t;
        
        //rozmiar okna
        private int rozmiarX, rozmiarY;
        private int border = 150;

        
        //rybki
        private Rybki[] rybki;
        private int iloscRybek = 6;
       

        //statystyki
        private Statystyki s;

        //przegrana
        private bool przegrana = false;
        


        public Gra()
        {
            InitializeComponent();

            rozmiarX = this.Width;
            rozmiarY = this.Height;

            s = new Statystyki();
            
            progressBar.Maximum = s.czas;
            progressBar.Value = s.czas;
            progressBar.Step = -1;

            labelCzas.Text = "Czas: " + s.czas.ToString();
            t = new System.Timers.Timer();
            t.Interval = 1000; // jedna sekunda


            t.Start();
            t.Elapsed += zegar;
            Application.Idle += petlaGry;


            // tworzy nowe rybki
            int miejsceX = rozmiarX - 2 * border;
            int miejsceY = rozmiarY - 2 * border;
            int XnaRybke = miejsceX / iloscRybek;
            int YnaRybke = miejsceY / iloscRybek;
            
            rybki = new Rybki[iloscRybek];
            for (int i = 0; i < iloscRybek; i++)
            {
                rybki[i] = new Rybki(this, ("../../../Zasoby/Rybki/" + (i + 1).ToString() + ".png"), pozycjaX(i, XnaRybke), pozycjaY(i, YnaRybke));
            }

            
        }

        private int pozycjaX(int ktoraRybka, int XnaRybke)
        {
            Random rnd = new Random();
            int pozycja = border + (ktoraRybka * XnaRybke);
            return pozycja;
        }

        private int pozycjaY(int ktoraRybka, int YnaRybke)
        {
            Random rnd = new Random();
            int pozycja = rozmiarY/2+rnd.Next((-rozmiarY/2)+border, (rozmiarY/2) -border);
            return pozycja;
        }


        private void zegar(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s.czas--;
                
                if (s.czas < 0)
                {
                    s.czas = 0;
                    przegrana = true;
                }

                if (przegrana)
                {
                    t.Stop();
                }

                progressBar.PerformStep();
                labelCzas.Text = "Czas: " + s.czas.ToString();
            }));
        }

        private void petlaGry(object sender, EventArgs e)
        {
            if (przegrana)
            {
                t.Stop();
                MessageBox.Show("Przegra³eœ!");
            }
            
            
            
        }

        private void labelCzas_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}