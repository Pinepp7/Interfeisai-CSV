using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Models
{
    public class Elektromobilis : Automobilis
    {
        public int BaterijosTalpa {  get; set; }
        public int Ikrovimolaikas { get; set; }

        public Elektromobilis()
        {


        }

        
        public Elektromobilis(int id, string marke, string modelis, decimal nuomosKaina, int baterijosTalpa, int ikrovimoLaikas)
          :base (id, marke, modelis, nuomosKaina)
        {

            BaterijosTalpa = baterijosTalpa;
            Ikrovimolaikas = ikrovimoLaikas;

        }

        public Elektromobilis(string marke,string modelis,decimal nuomosKaina, int baterijosTalpa,int ikrovimoLaikas)
            : base (marke, modelis, nuomosKaina)
        {
            BaterijosTalpa = baterijosTalpa;
            Ikrovimolaikas = ikrovimoLaikas;

        }
        public override string ToString()
        {
            return $"{Id} {Marke} {Modelis} {NuomosKaina} {BaterijosTalpa}kwh{Ikrovimolaikas} val";
        }
    }

}
