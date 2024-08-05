using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Services
{
    public class NuomosService
    {
        private readonly NuomaDbRepository _nuomaRepository;

        public NuomosService(NuomaDbRepository nuomaRepository)
        {
            _nuomaRepository = nuomaRepository;
        }

        public void PridetiNuomosUzsakyma(NuomosUzsakymas uzsakymas)
        {
            _nuomaRepository.PridetiNuoma(uzsakymas);
        }

        public void AtnaujintiNuomosUzsakyma(NuomosUzsakymas uzsakymas)
        {
            _nuomaRepository.AtnaujintiNuoma(uzsakymas);
        }

        public void IstrintiNuomosUzsakyma(int uzsakymasId)
        {
            _nuomaRepository.IstrintiNuoma(uzsakymasId);
        }
    }
}
