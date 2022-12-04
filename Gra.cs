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
        private bool stop = true;
        private bool boot = true;
        
        //przegrana
        private bool przegrana = false;

        //rozmiar okna
        private int rozmiarX, rozmiarY;
        private int border = 150;

        
        //rybki
        private Rybki[] rybki;
        private int iloscRybek = 6;
       

        //statystyki
        private Statystyki s;

        public Gra()
        {
            InitializeComponent();
            
            rozmiarX = this.Width;
            rozmiarY = this.Height;

            s = new Statystyki();
            progressBar.Step = -1;
            restart();

            t = new System.Timers.Timer();
            t.Interval = 1000; // jedna sekunda
            t.Start();
            stop = false;
            
            t.Elapsed += zegar;
            Application.Idle += petlaGry;

            // tworzy nowe rybki
            int miejsceX = rozmiarX - 2 * border;
            int miejsceY = rozmiarY - 2 * border;
            int XnaRybke = miejsceX / iloscRybek;
            int YnaRybke = miejsceY / iloscRybek;
            
            rybki = new Rybki[iloscRybek];
            rybki[0] = new Rybki(this, ("../../../Zasoby/Rybki/" + s.rybkaGracza + ".png"), pozycjaX(0, XnaRybke), pozycjaY(0, YnaRybke));
            rybki[0].Rownanie.ForeColor = Color.Red;
            for (int i = 1; i < iloscRybek; i++)
            {
                Random rnd = new Random();
                rybki[i] = new Rybki(this, ("../../../Zasoby/Rybki/" + rnd.Next(1,17).ToString() + ".png"), pozycjaX(i, XnaRybke), pozycjaY(i, YnaRybke));
            }
            
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
                Application.ExitThread();
            }
            
            while (IsApplicationIdle() && !przegrana)
            {
                if (!stop)
                for (int i = 1; i < iloscRybek; i++)
                {
                    rybki[i].animacjaRybek();
                }
                rybki[0].animacjaGracza(rybki[1].x);
                if (boot)
                {
                    t.Stop();
                    for (int i = 0; i < iloscRybek; i++)
                    {
                        rybki[i].Rownanie.Visible = false;
                    }
                    stop = true;
                    start.Text = "start";
                    boot = false;
                }
            }


        }

        private void restart()
        {
            labelCzas.Text = "Czas: " + s.czas.ToString();
            progressBar.Maximum = s.czas;
            progressBar.Value = s.czas;
        }

        private int pozycjaX(int ktoraRybka, int XnaRybke)
        {
            Random rnd = new Random();
            int pozycja = rnd.Next(border, rozmiarX - border);
            return pozycja;
        }

        private int pozycjaY(int ktoraRybka, int YnaRybke)
        {
            Random rnd = new Random();
            int pozycja = rnd.Next(border, (rozmiarY - border));
            return pozycja;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (stop)
            {
                t.Start();
                stop = false;
                for (int i = 0; i < iloscRybek; i++)
                {
                    rybki[i].Rownanie.Visible = true;
                }
                start.Text = "stop";
            }
            else
            {
                t.Stop();
                for (int i = 0; i < iloscRybek; i++)
                {
                    rybki[i].Rownanie.Visible = false;
                }
                stop = true;
                start.Text = "start";
            }
        }


        /// element potrzebny do pêtli gry
        /// Ÿród³o: https://learn.microsoft.com/pl-pl/archive/blogs/tmiller/my-last-post-on-render-loops-hopefully
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
        /// koniec elementu potrzebnego do pêtli gry

        private void labelCzas_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Gra_MouseDown(object sender, MouseEventArgs e)
        {
            rybki[0].x = Cursor.Position.X-rozmiarX/2;
            rybki[0].y = Cursor.Position.Y-125;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}