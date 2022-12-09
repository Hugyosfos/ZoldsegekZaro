using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoldsegekZaro
{
    internal class Zoldsegek
    {
        int id;
        string nev;
        double Egyseg;
        double Mennyiseg;

     

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }
        public double Egyseg1 { get => Egyseg; set => Egyseg = value; }
        public double Mennyiseg1 { get => Mennyiseg; set => Mennyiseg = value; }

        public Zoldsegek(int id, string nev, double egyseg1, double meret1)
        {
            Id = id;
            Nev = nev;
            Egyseg1 = egyseg1;
            Mennyiseg1 = Mennyiseg;
        }
        public override string ToString()
        {
            return "Név:"+ nev + " Egységár:" + Egyseg+" Mennyiség:"+ Mennyiseg;
        }
    }
}