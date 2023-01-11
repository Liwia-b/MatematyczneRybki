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

        //rozmiar okna
        public static int rozmiaroknaX = 1024;
        public static int rozmiaroknaY = 768;
        private int border = 150;

        //menu
        menu menugry;
        private int wybranaRybka = 1;
        private bool sklep = false;

        //rybki
        private Rybki[] rybki;
        private static int maxiloscRybek = 20;
        private int iloscRybek = 3;
        
        // dane
        private Dane d;

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
            d = new Dane();

            // wczytuje wzory poziomow
            d.wczytajPoziomy();

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
            rybki[0] = new Rybki(this, ("../../../Zasoby/Rybki/" + d.rybkaGracza + ".png"), losowaLiczba(border, (rozmiaroknaX - border)), losowaLiczba(border, (rozmiaroknaY - border)));
            rybki[0].Rownanie.ForeColor = Color.Red;
            
            // tworzy wszystkie rybki
            for (int i = 1; i < maxiloscRybek; i++)
            {
                rybki[i] = new Rybki(this, ("../../../Zasoby/Rybki/" + losowaLiczba(1,17).ToString() + ".png"), losowaLiczba(border, (rozmiaroknaX - border)), losowaLiczba(border, (rozmiaroknaY - border)));
                rybki[i].Rownanie.Visible = false;
            }
        }

        private void zegar(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                d.czasAktualny--;

                if (d.czasAktualny < 0)
                {
                    d.czasAktualny = 0;

                    if (d.poziomAktualny == 4)
                    {
                        t.Stop();
                        MessageBox.Show("Gra nie ma wiecej poziomów trudności, jednak możesz grać dalej aby uzyskiwać co raz lepszy wynik oraz zbierać pieniądze na nową rybkę!");
                        t.Start();
                    }

                    // warunek punktowy
                    if (d.poziomAktualny < 4)
                    {
                        if (rybki[0].liczbaRybki > d.poziomPunkty[d.poziomAktualny - 1])
                        {
                            d.poziomAktualny += 1;
                            resetGry(d.poziomAktualny);
                        }
                        else
                            przegrales(1);
                    }
                    else
                    {
                        if (rybki[0].liczbaRybki > d.poziomPunkty[3])
                        {
                            d.poziomAktualny += 1;
                            resetGry(d.poziomAktualny);
                        }
                        else
                            przegrales(1);
                    }

                }

                menugry.zaktualizujCzas(d.czasAktualny, d.czasUstawiony);
            }));
        }

        private void petlaGry(object sender, EventArgs e)
        {
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

        private void przegrales(int i)
        {
            zatrzymajGre();
            if (i == 1)
                MessageBox.Show("Uzyskany wynik jest za niski.. Gra rozpocznie się od pierwszego poziomu, tym razem musisz szybciej liczyć!");
            else
                MessageBox.Show("Większa rybka Cię zjadła.. Gra rozpocznie sie od pierwszego poziomu!");
            rozpocznijGre();
            resetGry(1);
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

        private void resetGry(int poziom)
        {
            ustawPoziom(poziom);
            aktualizujmenu();
            menugry.zaktualizujCzas(d.czasAktualny, d.czasUstawiony);
            rybki[0].liczbaRybki = losowaLiczba(15, 25);
            rybki[0].Rownanie.Text = rybki[0].liczbaRybki.ToString();
            for (int i = 1; i < maxiloscRybek; i++)
            {
                resetRybki(i);
            }
            rozpocznijGre();
        }

        private void ustawPoziom(int i)
        {
            if (i == 1)
            {
                d.poziomAktualny = 1;
                d.czasUstawiony = d.poziomCzas[0];
                d.czasAktualny = d.poziomCzas[0];
            }
            else if (i == 2)
            {
                d.czasUstawiony = d.poziomCzas[1];
                d.czasAktualny = d.poziomCzas[1];
            }
            else if (i == 3)
            {
                d.czasUstawiony = d.poziomCzas[2];
                d.czasAktualny = d.poziomCzas[2];
            }
            else if (i == 4)
            {
                d.czasUstawiony = d.poziomCzas[3];
                d.czasAktualny = d.poziomCzas[3];
            }
            else
            {
                d.czasUstawiony = d.poziomCzas[3];
                d.czasAktualny = d.poziomCzas[3];
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            startprzycisk.Visible = false;
            menugry.widoczne = true;
            nazwagracza.Visible = false;
            tytul.Visible = false;

            if (nazwagracza.Text == "Podaj nazwe gracza!")
            {
                nazwagracza.Text = "Gracz";
            }

            // Ustawianie statystyk gracza
            d.nazwagracza = nazwagracza.Text;
            ustawGracza();

            for (int i = 0; i < maxiloscRybek; i++)
            {
                rybki[i].Rownanie.Visible = true;
            }

            resetGry(1);
        }

        private void ustawGracza()
        {
            d.szukajDanychGracza();
            aktualizujmenu();
            menugry.zaktualizujCzas(d.czasAktualny, d.czasUstawiony);
            rybki[0].Rybka.Image = Image.FromFile("../../../Zasoby/Rybki/" + d.rybkaGracza.ToString() + ".png");

        }

        // mechanika gry
        private void Gra_MouseDown(object sender, MouseEventArgs e)
        {
            // menu
            if (e.X > menugry.pmenu.Location.X && e.X < menugry.pmenu.Location.X + menugry.pmenu.Width && e.Y > menugry.pmenu.Location.Y && e.Y < menugry.pmenu.Location.Y + menugry.pmenu.Height && menugry.widoczne && !sklep)
            {
                pokazPrzyciskiMenu();
                zatrzymajGre();

            }
            else if (e.X > menugry.psklep.Location.X && e.X < menugry.psklep.Location.X + menugry.psklep.Width && e.Y > menugry.psklep.Location.Y && e.Y < menugry.psklep.Location.Y + menugry.psklep.Height && menugry.widoczne)
            {
                if (t.Enabled)
                {
                    zatrzymajGre();
                    pokazSklep();
                }
                else
                {
                    ukryjSklep();
                    rozpocznijGre();
                }

            }
            // sklep
            else if (t.Enabled) {
                ruchGracza(e.X, e.Y);
            }

        }

        private void pokazSklep()
        {
            sklep = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            pictureBox1.Image = Image.FromFile("../../../Zasoby/Rybki/" + wybranaRybka.ToString() + ".png");
            pictureBox1.Visible = true;
            button1.Text = "kup rybke za " + Dane.cennikRybek[wybranaRybka - 1];

        }

        private void ukryjSklep()
        {
            sklep = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            pictureBox1.Visible = false;
        }

        private void kontynuuj_Click(object sender, EventArgs e)
        {
            schowajPrzyciskiMenu();
            rozpocznijGre();
        }

        private void wyjdzzgry_Click(object sender, EventArgs e)
        {
            d.zapiszDaneGracza();
            Application.Exit();
        }

        private void rozpocznijodnowa_Click(object sender, EventArgs e)
        {
            schowajPrzyciskiMenu();
            resetGry(1);
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

        private void aktualizujmenu()
        {
            menugry.pieniadze.Text = d.pieniadze.ToString();
            menugry.poziom.Text = "POZIOM: " + d.poziomAktualny.ToString();
            menugry.nazwagracza.Text = d.nazwagracza;
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
                        rybki[0].liczbaRybki += rybki[i].liczbaRybki;
                        rybki[0].Rownanie.Text = rybki[0].liczbaRybki.ToString();
                        d.pieniadze += 10;
                        aktualizujmenu();
                        resetRybki(i);
                        break;
                    }
                    else
                    {
                        przegrales(0);
                        break;
                    }

                }

            }
        }


        private void resetRybki(int i)
        {
            resetPozycjiRybki(i);
            resetObrazkaRybki(i);
            bool jestMniejszaRybka = false;
            if (d.poziomAktualny == 1)
            {
                int nowaCyfraRybki = 0;
                while (!jestMniejszaRybka)
                {
                    nowaCyfraRybki = losowaLiczba(-10, 150);
                    if (nowaCyfraRybki > rybki[0].liczbaRybki)
                    {
                        for (int j = 1; j < maxiloscRybek; j++)
                        {
                            if (rybki[j].liczbaRybki < rybki[0].liczbaRybki)
                                jestMniejszaRybka = true;
                        }
                    }
                    else
                            jestMniejszaRybka = true;
                }
                rybki[i].liczbaRybki = nowaCyfraRybki;
                rybki[i].Rownanie.Text = rybki[i].liczbaRybki.ToString();
            }
            else if (d.poziomAktualny == 2)
            {
                int iloscWzorow = d.poziom2.Length;
                int nowyWzorRybki = 0;
                int wynikWzoru = 0;
                string wzor = "";

                while (!jestMniejszaRybka)
                {
                    nowyWzorRybki = losowaLiczba(0, iloscWzorow);
                    string[] wzoriwynik = d.poziom2[nowyWzorRybki].Split('=');
                    wynikWzoru = Int32.Parse(wzoriwynik[1]);
                    wzor = wzoriwynik[0];

                    if (wynikWzoru > rybki[0].liczbaRybki)
                    {
                        for (int j = 1; j < maxiloscRybek; j++)
                        {
                            if (rybki[j].liczbaRybki < rybki[0].liczbaRybki)
                                jestMniejszaRybka = true;
                        }
                    }
                    else
                        jestMniejszaRybka = true;
                }
                rybki[i].liczbaRybki = wynikWzoru;
                rybki[i].Rownanie.Text = wzor;
            }
            else if (d.poziomAktualny == 3)
            {
                int iloscWzorow = d.poziom3.Length;
                int nowyWzorRybki = 0;
                int wynikWzoru = 0;
                string wzor = "";

                while (!jestMniejszaRybka)
                {
                    nowyWzorRybki = losowaLiczba(0, iloscWzorow);
                    string[] wzoriwynik = d.poziom3[nowyWzorRybki].Split('=');
                    wynikWzoru = Int32.Parse(wzoriwynik[1]);
                    wzor = wzoriwynik[0];

                    if (wynikWzoru > rybki[0].liczbaRybki)
                    {
                        for (int j = 1; j < maxiloscRybek; j++)
                        {
                            if (rybki[j].liczbaRybki < rybki[0].liczbaRybki)
                                jestMniejszaRybka = true;
                        }
                    }
                    else
                        jestMniejszaRybka = true;
                }
                rybki[i].liczbaRybki = wynikWzoru;
                rybki[i].Rownanie.Text = wzor;
            }
            else if (d.poziomAktualny >= 4)
            {
                int iloscWzorow = d.poziom4.Length;
                int nowyWzorRybki = 0;
                int wynikWzoru = 0;
                string wzor = "";

                while (!jestMniejszaRybka)
                {
                    nowyWzorRybki = losowaLiczba(0, iloscWzorow);
                    string[] wzoriwynik = d.poziom4[nowyWzorRybki].Split('=');
                    wynikWzoru = Int32.Parse(wzoriwynik[1]);
                    wzor = wzoriwynik[0];

                    if (wynikWzoru > rybki[0].liczbaRybki)
                    {
                        for (int j = 1; j < maxiloscRybek; j++)
                        {
                            if (rybki[j].liczbaRybki < rybki[0].liczbaRybki)
                                jestMniejszaRybka = true;
                        }
                    }
                    else
                        jestMniejszaRybka = true;
                }
                rybki[i].liczbaRybki = wynikWzoru;
                rybki[i].Rownanie.Text = wzor;
            }
        }

        private void resetPozycjiRybki(int i)
        {
            rybki[i].x = losowaLiczba(border, rozmiaroknaX - border);
            rybki[i].y = losowaLiczba(border, rozmiaroknaY - border);
        }

        private void resetObrazkaRybki(int i)
        {
            if (rybki[i].prawo == true)
            {
                rybki[i].Rybka.Image = Image.FromFile("../../../Zasoby/Rybki/" + losowyObrazekRybki().ToString() + ".png");
                Image nowaRybka = rybki[i].Rybka.Image;
                nowaRybka.RotateFlip(RotateFlipType.RotateNoneFlipX);
                rybki[i].Rybka.Image = nowaRybka;
            }
            else
                rybki[i].Rybka.Image = Image.FromFile("../../../Zasoby/Rybki/" + losowyObrazekRybki().ToString() + ".png");
        }

        private int losowyObrazekRybki()
        {
            bool czyRybkaGracza = true;
            int rybka = losowaLiczba(1, 17);
            while (czyRybkaGracza)
            {
                if (rybka != d.rybkaGracza)
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

        private void nazwagracza_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            wybranaRybka++;
            if (wybranaRybka == 17)
                wybranaRybka = 1;
            pictureBox1.Image = Image.FromFile("../../../Zasoby/Rybki/" + wybranaRybka.ToString() + ".png");
            button1.Text = "kup rybke za " + Dane.cennikRybek[wybranaRybka - 1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wybranaRybka--;
            if (wybranaRybka == 0)
                wybranaRybka = 16;
            pictureBox1.Image = Image.FromFile("../../../Zasoby/Rybki/" + wybranaRybka.ToString() + ".png");
            button1.Text = "kup rybke za " + Dane.cennikRybek[wybranaRybka-1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (d.pieniadze > Dane.cennikRybek[wybranaRybka - 1])
            {
                d.pieniadze -= Dane.cennikRybek[wybranaRybka - 1];
                d.rybkaGracza = wybranaRybka;
                aktualizujmenu();
                rybki[0].Rybka.Image = Image.FromFile("../../../Zasoby/Rybki/" + d.rybkaGracza.ToString() + ".png");
                MessageBox.Show("Zakup pomyślny!, nowa rybka została ustawiona");
            }
            else
            {
                MessageBox.Show("Zakup nieudany.. uzbieraj więcej pieniędzy aby zakupić tę rybkę!");
            }
        }
    }
}
