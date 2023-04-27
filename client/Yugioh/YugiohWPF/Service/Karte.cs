using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohWPF.Service
{
    internal class Karte
    {
        string name, beschreibung, cardType ,type, category, attribute;
        int level, attack, defense, passcode;

        public Karte(string name, string beschreibung, string cardType, string type, string category, string attribute, int level, int attack, int passcode, int defense)
        {
            Name = name;
            Beschreibung = beschreibung;
            Type = type;
            Category = category;
            Attribute = attribute;
            Level = level;
            Attack = attack;
            Passcode = passcode;
            Defense = defense;
        }

        public string Name { get => name; set => name = value; }
        public string Beschreibung { get => beschreibung; set => beschreibung = value; }
        public string CardType { get => cardType; set => cardType = value; }
        public string Type { get => type; set => type = value; }
        public string Category { get => category; set => category = value; }
        public string Attribute { get => attribute; set => attribute = value; }
        public int Level { get => level; set => level = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Passcode { get => passcode; set => passcode = value; }
    }
}
