using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Contracts
{
    public interface IAutonuomaServiece
    {

       void PridetiNaujaAutomobili(Automobilis automobilis);
        List<Automobilis> GautiVisusAutomobilius();
        List<Klientas> GautiVisusKlientus();
        void SukurtiNuoma(string klientoVardas, string klientoPavarde, int autoId, DateTime nuomosPradzia, int dienos);
        List<Elektromobilis> GautiVisusElektromobilius();
        List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAuto();

    }
}
