using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematyczne_Rybki
{
    class Statystyki
    {
        public int wynikAktualny, rekord;
        public int czasUstawiony, czasAktualny;
        public int poziomAktualny, poziomRekord;
        public int pieniadze;
        public int rybkaGracza;
        private string[] informacjeograczu = System.IO.File.ReadAllLines("../../../Zasoby/gracz.txt");

        public Statystyki()
        {
            czasUstawiony = 45;
            czasAktualny = czasUstawiony;
            wynikAktualny = 0;
            poziomAktualny = 1;
            pieniadze = 0;
            rybkaGracza = 1;
        }

    }
}
