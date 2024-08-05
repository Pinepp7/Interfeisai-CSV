using Interfeisai_CSV.Contracts;
using Interfeisai_CSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeisai_CSV.Repositories
{
    public class AutomobiliaiFileRepository : IAutomobiliaiRepository
    {
        private readonly string _filePath;
        public AutomobiliaiFileRepository(string autoFilePath)
        {
            _filePath = autoFilePath;
        }

        public List<Elektromobilis> GautiVisusElektromobilius()
        {
            List < Elektromobilis > visiauto = new List<Elektromobilis>();
            using (StreamReader sr = new StreamReader(_filePath))
            {

                while (!sr.EndOfStream)
                {
                    string eilute = sr.ReadLine();
                    string[] vertes = eilute.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (vertes.Length == 6)
                        visiauto.Add(new Elektromobilis(int.Parse(vertes[0]), vertes[1], vertes[2], decimal.Parse(vertes[3]),
                            int.Parse(vertes[4]), int.Parse(vertes[5])));
                }

            }
            return visiauto;

        }
        
            
        
            

        public List<NaftosKuroAutomobilis> GautiVisusNaftosKuroAutomobilius()
        {
            throw new NotImplementedException();
        }

        public void IrasytiAutomobilius()
        {
            throw new NotImplementedException();
        }

        public void IrasytiElektromobili(Elektromobilis elektromobilis)
        {
            throw new NotImplementedException();
        }

        public void IrasytiNaftosKuroAutomobilis(NaftosKuroAutomobilis automobilis)
        {
            throw new NotImplementedException();
        }

        public List<Automobilis> NuskaitytiAutomobilius()
        {
            List<Automobilis> visiauto = new List<Automobilis>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string eilute = sr.ReadLine();
                    string[] vertes = eilute.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (vertes.Length == 6)
                        visiauto.Add(new Elektromobilis(int.Parse(vertes[0]), vertes[1], vertes[2], decimal.Parse(vertes[3]),
                            int.Parse(vertes[4]), int.Parse(vertes[5])));


                }
            }
            return visiauto;
        }
    }
}

    