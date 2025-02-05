﻿using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Contracts
{
    public interface IAutomobiliaiRepository
    {
        List<Automobilis> NuskaitytiAutomobilius();
        void IrasytiAutomobilius();
        void IrasytiElektromobili(Elektromobilis elektromobilis);
        void IrasytiNaftosKuroAutomobilis(NaftosKuroAutomobilis automobilis);


        List<Elektromobilis> GautiVisusElektromobilius();
        List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAutomobilius();



    }
}
