
using AutomobiliuNuoma.Core.Repositories;
using Interfeisai_CSV.Contracts;
using Interfeisai_CSV.Models;
using Interfeisai_CSV.Repositories;
using Interfeisai_CSV.Services;
using System;
namespace AutomobiliuNuomaConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        IAutonuomaServiece autonuomaService = SetupDependencies();
        while (true)
        {
            Console.WriteLine("1. Rodyti visus automobilius");
            Console.WriteLine("2. Rodyti visus klientus");
            Console.WriteLine("3. Rodyti visus elektromobilius");
            Console.WriteLine("4. Rodyti visus Naftos Kuro Automobilius");
            Console.WriteLine("5. Formuoti nuomos uzsakyma");
            Console.WriteLine("6. Prideti automobili");

            string pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    List<Automobilis> auto = autonuomaService.GautiVisusAutomobilius();
                    foreach (Automobilis a in auto)
                    {
                        Console.WriteLine(a);
                    }
                    break;
                case "2":
                    List<Klientas> klientai = autonuomaService.GautiVisusKlientus();
                    foreach (Klientas k in klientai)
                    {
                        Console.WriteLine(k);
                    }
                    break;
                case "3":
                    List<Elektromobilis> elektromobiliai = autonuomaService.GautiVisusElektromobilius();
                    foreach (Elektromobilis ev in elektromobiliai)
                    {
                        Console.WriteLine(ev);
                    }
                    break;
                case "4":
                    List<NaftosKuroAutomobilis> naftosKuroAutomobiliai = autonuomaService.GautiVisusNaftosKuroAuto();
                    foreach (NaftosKuroAutomobilis v in naftosKuroAutomobiliai)
                    {
                        Console.WriteLine(v);
                    }
                    break;
                case "5":
                    Console.WriteLine("Nuomos uzsakymas: ");
                    foreach (Klientas k in autonuomaService.GautiVisusKlientus())
                    {
                        Console.WriteLine(k);
                    }

                    Console.WriteLine("Iveskite norimo kliento varda");
                    string vardas = Console.ReadLine();
                    Console.WriteLine("Iveskite norimo kliento pavarde");
                    string pavarde = Console.ReadLine();

                    foreach (Automobilis a in autonuomaService.GautiVisusAutomobilius())
                    {
                        Console.WriteLine(a);
                    }

                    Console.WriteLine("Pasirinkite automobili pagal Id sarase: ");
                    int autoId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Iveskite kiek dienu autommobilis yra isnuomojamas: ");
                    int dienos = int.Parse(Console.ReadLine());

                    autonuomaService.SukurtiNuoma(vardas, pavarde, autoId, DateTime.Now, dienos);

                    break;
                case "6":
                    Automobilis naujasAuto = new Automobilis();
                    int ikrovimoLaikas = 0;
                    int baterijosTalpa = 0;
                    double degalusanaudos = 0;
                    Console.WriteLine("Elektromobilis - 1  Naftos Kuro Auto - 2: ");
                    string tipas = Console.ReadLine();
                    switch (tipas)
                    {
                        case "1":
                            Console.WriteLine("Iveskite Ikrovimo laika");
                            ikrovimoLaikas = int.Parse(Console.ReadLine());
                            Console.WriteLine("Iveskite Baterijos talpa");
                            baterijosTalpa = int.Parse(Console.ReadLine());
                            break;
                        case "2":
                            Console.WriteLine("Iveskte kurosanaudos");
                            degalusanaudos = double.Parse(Console.ReadLine());
                            break;
                    }
                    Console.WriteLine("Iveskite marke");
                    string marke = Console.ReadLine();
                    Console.WriteLine("Iveskite modeli");
                    string modelis = Console.ReadLine();
                    Console.WriteLine("Iveskite nuomos kaina");
                    decimal nuomosKaina = decimal.Parse(Console.ReadLine());
                    switch (tipas)
                    {
                        case "1":
                            naujasAuto = new Elektromobilis(marke, modelis, nuomosKaina, baterijosTalpa, ikrovimoLaikas);
                            break;
                        case "2":
                            naujasAuto = new NaftosKuroAutomobilis (marke, modelis, nuomosKaina, degalusanaudos);
                            break;
                    }
                    autonuomaService.PridetiNaujaAutomobili(naujasAuto);

                    break;
            }


        }
    }
    public static IAutonuomaServiece SetupDependencies()
    {
        IKlientaiRepository klientaiRepository = new KlientaiFileRepository("Server=localhost;Database=automobiliai;Trusted_Connection=True;");
        //IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiFileRepository("Auto.csv");
        IAutomobiliaiRepository automobiliaiRepository = new AutomobiliaiDbRepository("Server=localhost;Database=automobiliai;Trusted_Connection=True;");
        IKlientaiService klientaiService = new KlientaiService(klientaiRepository);
        IAutomobiliaiService automobiliaiService = new AutomobiliaiService(automobiliaiRepository);
        return new AutonuomosService(klientaiService, automobiliaiService);
    }
}