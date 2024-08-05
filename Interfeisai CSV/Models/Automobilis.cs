using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Models
{
    public class Automobilis
    {

        public int Id {  get; set; }
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public decimal NuomosKaina { get; set; }

        public Automobilis()
        {

        }
        public Automobilis(int id, string marke, string modelis, decimal nuomosKaina)
        {

            Id = id;  
            Marke = marke;
            Modelis = modelis;
            NuomosKaina = nuomosKaina;

        }
        public Automobilis( string marke, string modelis, decimal nuomosKaina)
        {

            
            Marke = marke;
            Modelis = modelis;
            NuomosKaina = nuomosKaina;

        }
    }
}
