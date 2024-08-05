using Interfeisai_CSV.Contracts;
using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Services
{
    public class KlientaiService : IKlientaiService
    {
        private readonly IKlientaiRepository _klientaiRepository;
        public KlientaiService(IKlientaiRepository klientaiRepository)
        {
            _klientaiRepository = klientaiRepository;
        }

        public List<Klientas> GautiVisusKlientus()
        {
            return _klientaiRepository.GautiVisusKlientus();
        }

        public Klientas PaieskaPagalVardaPavarde(string vardas, string pavarde)
        {
            throw new NotImplementedException();
        }
    } 
}
