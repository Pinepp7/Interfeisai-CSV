using Interfeisai_CSV.Contracts;
using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Services
{
    public class AutonuomosService : IAutonuomaServiece
    {
        private readonly IKlientaiService _klientaiService;
        private readonly IAutomobiliaiService _automobiliaiService;

        private List<Automobilis> VisiAutomobiliai = new List<Automobilis>();

        public AutonuomosService(IKlientaiService klientaiService, IAutomobiliaiService automobiliaiService)
        {
            _automobiliaiService = automobiliaiService;
            _klientaiService = klientaiService;
        }

        public List<Automobilis> GautiVisusAutomobilius()
        {
            return _automobiliaiService.GautiVisusAutomobilius();
        }
            
        public List<Elektromobilis> GautiVisusElektromobilius()
        {
            return _automobiliaiService.GautiVisusElektromobilius();
        }

        public List<Klientas> GautiVisusKlientus()
        {
            return _klientaiService.GautiVisusKlientus();
        }

        public List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAuto()
        {
            return _automobiliaiService.GautiVisusNaftosKuroAuto();
        }

        public void PridetiNaujaAutomobili(Automobilis automobilis)
        {
            _automobiliaiService.PridetiAutomobili(automobilis);
        }

        public void SukurtiNuoma(string klientoVardas, string klientoPavarde, int autoId, DateTime nuomosPradzia, int dienos)
        {
            _automobiliaiService.GautiVisusAutomobilius();
        }
    }
}

    

    

