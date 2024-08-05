using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Models
{
    public class NaftosKuroAutomobilis : Automobilis
    {
        public double DegaluSanaudos { get; set; }


        public NaftosKuroAutomobilis(int id, string marke, string modelis, decimal nuomosKaina, double degalusanaudos )
                 : base(id, marke, modelis, nuomosKaina)
        {
            DegaluSanaudos = degalusanaudos;

        }
        public NaftosKuroAutomobilis( string marke, string modelis, decimal nuomosKaina, double degalusanaudos)
              : base( marke, modelis, nuomosKaina)
        {
            DegaluSanaudos = degalusanaudos;

        }
        public NaftosKuroAutomobilis()
        {

        }
        public override string ToString()
        {
            return $"{Id} {Marke} {Modelis} {NuomosKaina} {DegaluSanaudos.ToString("F1")}L/100km";
        }
    }

}
 

