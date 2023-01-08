using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Matematyczne_Rybki
{
    public partial class Gra : Form
    {

        //timer
        private System.Timers.Timer t;

        //stany gry
        private bool przegrana = false;

        //rozmiar okna
        public static int rozmiaroknaX = 1024;
        public static int rozmiaroknaY = 768;
        private int border = 150;

        //menu
        menu menugry;
        private bool gameover = true;

        //rybki
        private Rybki[] rybki;
        private static int maxiloscRybek = 16;
        private int iloscRybek = 3;
        
        //statystyki
        private Statystyki s;

        public Gra()
        {
            InitializeComponent();
            inicjalizacjaGry();

            t.Elapsed += zegar;
            Application.Idle += petlaGry;
        }

        private void inicjalizacjaGry()
        {
            // tworzy menu
            menugry = new menu(this);

            // dodaje muzyke
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../../Zasoby/Muzyka/audio.wav");
            player.PlayLooping();

            // tworzy nowy profil gracza
            s = new Statystyki();

            // timer
            t = new System.Timers.Timer();
            t.Interval = 1000; // jedna sekunda

            //// RYBKI -------------------------
            // tworzy tablice rybek
            rybki = new Rybki[maxiloscRybek];

            // liczy miejsce na rybki
            int miejsceX = rozmiaroknaX - 2 * border;
            int miejsceY = rozmiaroknaY - 2 * border;
            int XnaRybke = miejsceX / maxiloscRybek;
            int YnaRybke = miejsceY / maxiloscRybek;

            // tworzy rybke gracza
            rybki[0] = new Rybki(this, ("../../../Zasoby/Rybki/" + s.rybkaGracza + ".png"), losowaLiczba(border, (rozmiaroknaX - border)), losowaLiczba(border, (rozmiaroknaY - border)));
            rybki[0].Rownanie.ForeColor = Color.Red;
            
            // tworzy wszystkie rybki
            for (int i = 1; i < maxiloscRybek; i++)
            {
                rybki[i] = new Rybki(this, ("../../../Zasoby/Rybki/" + losowyObrazekRybki().ToString() + ".png"), losowaLiczba(border, (rozmiaroknaX - border)), losowaLiczba(border, (rozmiaroknaY - border)));
                rybki[i].Rownanie.Visible = false;
            }
        }

        private void zegar(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s.czasAktualny--;

                if (s.czasAktualny < 0)
                {
                    s.czasAktualny = 0;
                    przegrana = true;
                }

                if (przegrana)
                {
                    t.Stop();
                }

                menugry.zaktualizujCzas(s.czasAktualny, s.czasUstawiony);
            }));
        }

        private void petlaGry(object sender, EventArgs e)
        {
            // jezeli gracz przegral to gra sie konczy
            if (przegrana)
            {
                t.Stop();
                MessageBox.Show("Przegrana!");
                Application.ExitThread();
            }

            while (IsApplicationIdle())
            {
                // animacje rybek
                if (rybki[0].Rybka.Visible == true)
                {
                    rybki[0].animacjaGracza(rybki[1].x);
                    for (int i = 1; i < maxiloscRybek; i++)
                    {
                        if (rybki[i].Rybka.Visible == true)
                        {
                            rybki[i].animacjaRybek();
                        }
                    }
                }

            }


        }

        private void rozpocznijGre()
        {
            t.Start();
            pokazRybki();
        }

        private void zatrzymajGre()
        {
            schowajRybki();
            t.Stop();
        }

        private void restartGry()
        {
            s.poziomAktualny = 1;
            rozpocznijGre();
        }

        private void przegranaGracza()
        {
            
        }

        private void start_Click(object sender, EventArgs e)
        {
            startprzycisk.Visible = false;
            menugry.widoczne = true;
            tytul.Visible = false;

            for (int i = 0; i < maxiloscRybek; i++)
            {
                rybki[i].Rownanie.Visible = true;
            }

            t.Start();
            gameover = false;
        }

        // mechanika gry
        private void Gra_MouseDown(object sender, MouseEventArgs e)
        {
            // menu
            if (e.X > menugry.pmenu.Location.X && e.X < menugry.pmenu.Location.X + menugry.pmenu.Width && e.Y > menugry.pmenu.Location.Y && e.Y < menugry.pmenu.Location.Y + menugry.pmenu.Height && menugry.widoczne)
            {
                pokazPrzyciskiMenu();
                zatrzymajGre();

            }
            else if (e.X > menugry.psklep.Location.X && e.X < menugry.psklep.Location.X + menugry.psklep.Width && e.Y > menugry.psklep.Location.Y && e.Y < menugry.psklep.Location.Y + menugry.psklep.Height && menugry.widoczne)
            {
                zatrzymajGre();
            }
            // sklep
            else if (t.Enabled) {
                ruchGracza(e.X, e.Y);
            }

        }

        private void kontynuuj_Click(object sender, EventArgs e)
        {
            schowajPrzyciskiMenu();
            rozpocznijGre();
        }

        private void wyjdzzgry_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rozpocznijodnowa_Click(object sender, EventArgs e)
        {
            schowajPrzyciskiMenu();
            restartGry();
        }

        private void pokazPrzyciskiMenu()
        {
            wyjdzzgry.Visible = true;
            rozpocznijodnowa.Visible = true;
            kontynuuj.Visible = true;
            tytul.Visible = true;
            menugry.widoczne = false;
        }

        private void schowajPrzyciskiMenu()
        {
            wyjdzzgry.Visible = false;
            rozpocznijodnowa.Visible = false;
            kontynuuj.Visible = false;
            tytul.Visible = false;
            menugry.widoczne = true;
        }












        private void schowajRybki()
        {
            for (int i = 0; i < maxiloscRybek; i++)
            {
                rybki[i].Rybka.Visible = false;
                rybki[i].Rownanie.Visible = false;
            }
            Invalidate();
        }

        private void pokazRybki()
        {
            for (int i = 0; i < maxiloscRybek; i++)
            {
                rybki[i].Rybka.Visible = true;
                rybki[i].Rownanie.Visible = true;
            }
            Invalidate();
        }

        private void ruchGracza(int myszkaX, int myszkaY)
        {
            rybki[0].x = myszkaX - rybki[0].Rybka.Size.Width / 2;
            rybki[0].y = myszkaY - rybki[0].Rybka.Size.Height / 2;


            for (int i = 1; i < maxiloscRybek; i++)
            {

                if (myszkaX < rybki[i].Rybka.Location.X + rybki[i].Rybka.Size.Width
                    && myszkaX > rybki[i].Rybka.Location.X
                    && myszkaY < rybki[i].Rybka.Location.Y + rybki[i].Rybka.Size.Height
                    && myszkaY > rybki[i].Rybka.Location.Y)
                {
                    if (rybki[0].liczbaRybki >= rybki[i].liczbaRybki)
                    {
                        rybki[0].liczbaRybki = rybki[i].liczbaRybki;
                        rybki[0].Rownanie.Text = rybki[0].liczbaRybki.ToString();

                        resetRybki(i);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Przegrales!");
                        restartGry();
                    }

                }

            }
        }


        private void resetRybki(int i)
        {
            rybki[i].x = losowaLiczba(border, rozmiaroknaX - border);
            rybki[i].y = losowaLiczba(border, rozmiaroknaY - border);
            rybki[i].liczbaRybki = losowaLiczba(1, 100);
            rybki[i].Rownanie.Text = rybki[i].liczbaRybki.ToString();
            rybki[i].Rybka.Image = Image.FromFile("../../../Zasoby/Rybki/" + losowyObrazekRybki().ToString() + ".png");
        }




        private int losowyObrazekRybki()
        {
            bool czyRybkaGracza = true;
            int rybka = losowaLiczba(1, 17);
            while (czyRybkaGracza)
            {
                if (rybka != s.rybkaGracza)
                    czyRybkaGracza = false;
                else
                    rybka = losowaLiczba(1, 17);
            }
            return rybka;
        }

        private int losowaLiczba(int min, int max)
        {
            Random rnd = new Random();
            int liczba = rnd.Next(min, max);
            return liczba;
        }

        /// element potrzebny do petli gry
        /// �r�d�o: https://learn.microsoft.com/pl-pl/archive/blogs/tmiller/my-last-post-on-render-loops-hopefully
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);
        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }
        /// koniec elementu potrzebnego do petli gry

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Gra_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
