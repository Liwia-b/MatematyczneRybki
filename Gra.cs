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
        
        //rybki
        private Rybki[] rybki;
        
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
            progressBar.BackColor = Color.Red;

            // tworzy nowe rybki
            rybki = new Rybki[5];
            for (int i = 0; i < 5; i++)
            {
                rybki[i] = new Rybki(this, ("../../../Zasoby/Rybki/" + (i + 1).ToString() + ".png"), rozmiarX/2, rozmiarY/2);
            }

            t = new System.Timers.Timer();
            t.Interval = 1000; // jedna sekunda
            
            
            t.Start();
            labelCzas.Text = "Czas: " + s.czas.ToString();
            t.Elapsed += zegar;
            Application.Idle += petlaGry;
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