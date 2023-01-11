using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematyczne_Rybki
{
    class Dane
    {

        public static int[] cennikRybek = {10000, 5000, 2000, 1000, -1, 20000, 50000, 2, 0, -1000, 7000, 3000, 9000, 3000, 15000, 9999999};

        public int wynikAktualny, rekord;
        public int czasUstawiony, czasAktualny;
        public int poziomAktualny, poziomRekord;
        public int pieniadze;
        public int rybkaGracza;
        public string nazwagracza;
        private string[] informacjeograczu;

        public int[] poziomCzas;
        public int[] poziomPunkty;
        public string[] poziom2, poziom3, poziom4;

        public Dane()
        {
            nazwagracza = "Gracz";
            
            czasUstawiony = 30;
            czasAktualny = czasUstawiony;

            rekord = 0;
            wynikAktualny = 0;

            poziomAktualny = 1;
            
            pieniadze = 0;
            rybkaGracza = 5;

            poziomCzas = new int[] { 30, 60, 60, 90 };
            poziomPunkty = new int[] { 200, 250, 250, 300 };
        }

        public void szukajDanychGracza()
        {
            string sciezka = "../../../Zasoby/Profile/" + nazwagracza + ".txt";
            if (File.Exists(sciezka))
            {
                informacjeograczu = System.IO.File.ReadAllLines(sciezka);

                // budowa pliku statystyk
                // 1: rybkaGracza
                // 2: pieniadze
                // 3: rekord punktowy
                // 4: rekord poziomu

                rybkaGracza = Int32.Parse(informacjeograczu[0]);
                pieniadze = Int32.Parse(informacjeograczu[1]);
                rekord = Int32.Parse(informacjeograczu[2]);

            }
            else
            {
                string[] danegracza = {rybkaGracza.ToString(), pieniadze.ToString(), rekord.ToString()};
                this.informacjeograczu = danegracza;
            }
        }

        public void wczytajPoziomy()
        {
            for (int i = 2; i < 5; i++)
            {
                string sciezka = "../../../Zasoby/Inne/poziom" + i.ToString() + ".txt";
                if (File.Exists(sciezka))
                {
                    switch (i)
                    {
                        case 2:
                            poziom2 = System.IO.File.ReadAllLines(sciezka);
                            break;
                        case 3:
                            poziom3 = System.IO.File.ReadAllLines(sciezka);
                            break;
                        case 4:
                            poziom4 = System.IO.File.ReadAllLines(sciezka);
                            break;
                    }
                }
            }
        }

        public void zapiszDaneGracza()
        {
            string sciezka = "../../../Zasoby/Profile/" + nazwagracza + ".txt";
            string[] danegracza = { rybkaGracza.ToString(), pieniadze.ToString(), rekord.ToString() };
            File.WriteAllLines(sciezka, danegracza);
        }

    }
}
