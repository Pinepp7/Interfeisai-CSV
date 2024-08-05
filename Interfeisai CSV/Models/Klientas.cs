using Interfeisai_CSV.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Models
{
    public class Klientas 
    {

        public string Vardas {  get; set; }
        public string Pavarde { get; set; }
        public DateOnly GimimoMetai { get; set; }

        public Klientas() 
        { 


        }  
        public Klientas(string vardas, string pavarde, DateOnly gimimometai)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoMetai= gimimometai;

        }

        public override string ToString()
        {
            return $"Vardas: {Vardas} Pavarde: {Pavarde} Gimimo Metai {GimimoMetai.ToString /*x*/ ("yyyy")} Menesis: {GimimoMetai.ToString("MM")}";
        }

    }
}
