using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _241007_dolgokat_Katona_Roland
{
    internal class versenyzo
    {
        public string nev {get; set;}
        public int szul_ev { get; set; }
        public int rajtszam { get; set; }
        public bool nem { get; set; }
        public string kategoria { get; set; }

        public Dictionary<string, TimeSpan> idok = new Dictionary<string, TimeSpan>();

        public versenyzo(string sor)
        {
            var pieces = sor.Split(";");
            nev = pieces[0];
            szul_ev = Convert.ToInt32(pieces[1]);
            rajtszam = Convert.ToInt32(pieces[2]);
            nem = pieces[3] == "n";
            kategoria = pieces[4];
            idok.Add("uszas", TimeSpan.Parse(pieces[5]));
            idok.Add("elsodepo", TimeSpan.Parse(pieces[6]));
            idok.Add("kerekpar", TimeSpan.Parse(pieces[7]));
            idok.Add("masodikdepo", TimeSpan.Parse(pieces[8]));
            idok.Add("futas", TimeSpan.Parse(pieces[9]));

        }

        public override string ToString()
        {
            return $"Versenyző neve: {nev}" +
                $"\tNeme: {(nem ? "Nő" : "Férfi")}" +
                $"\tRajtszáma: {rajtszam}," +
                $"\tSzületési éve: {szul_ev} " +
                $"\nIdejei: " +
                $"\n\tÚszás: {idok["uszas"]} " +
                $"\n\tElső depo: {idok["elsodepo"]}" +
                $"\n\tKerékpár: {idok["kerekpar"]}" +
                $"\n\tMásodik depo: {idok["masodikdepo"]}" +
                $"\n\tFutás: {idok["futas"]}";
        }
    }
}
