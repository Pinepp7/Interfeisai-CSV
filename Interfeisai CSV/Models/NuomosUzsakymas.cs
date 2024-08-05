using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Models
{
    public class NuomosUzsakymas
    {
        public int Id { get; set; }
        public int AutomobilisId { get; set; }
        public int KlientasId { get; set; }
        public DateTime NuomosPradzia { get; set; }
        public DateTime NuomosPabaiga { get; set; }
        public int DarbuotojoId { get; set; } 

        public decimal UzsakytasAutoNuomosKaina { get; set; } 

        public decimal SkaiciuotiNuomosKaina()
        {
            TimeSpan nuomosTrukme = NuomosPabaiga - NuomosPradzia;
            return UzsakytasAutoNuomosKaina * (decimal)nuomosTrukme.TotalDays;
        }

        public DateTime GautiPabaigosData(int nuomosTrukmeDienomis)
        {
            return NuomosPradzia.AddDays(nuomosTrukmeDienomis);
        }
     
    }
}
    









