using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Contracts
{
    public interface IKlientaiService
    {

        List<Klientas> GautiVisusKlientus();
        Klientas PaieskaPagalVardaPavarde(string vardas, string pavarde);

    }
}
