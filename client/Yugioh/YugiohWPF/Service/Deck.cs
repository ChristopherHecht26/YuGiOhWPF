using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohWPF.Service
{
    public class Deck
    {
        int limitiert, verboten;
        
        public Deck()
        {
            Limitiert = 0;
            Verboten = 0;
        }

        public int Limitiert { get => limitiert; set => limitiert = value; }
        public int Verboten { get => verboten; set => verboten = value; }
    }

    public class Main : Deck
    {
        int anzahlMonster, anzahlFallen, anzahlZauber, mainMin, mainMax;

        public Main()
        {
            anzahlMonster = 0;
            anzahlFallen = 0;
            anzahlZauber = 0;
            mainMin = 40;
            mainMax = 60;
        }
    }

    public class Side : Deck
    {
        int sideMin, sideMax;

        public Side()
        {
            sideMin = 0;
            sideMax = 15;
        }
    }
}
