using System;
using System.Threading;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            int etage, parkplaetzeproetage, zahl;
            string kennzeichnen;
            bool check;
            bool check2 = false;
            bool menu = true;

            Console.WriteLine("Willkommen im Parkhaus System!");
            Console.Write("Bitte, Etagen eingeben: ");
            etage = Int32.Parse(Console.ReadLine());
            Console.Write("\nBitte, Parkplaetze pro Etage eingeben: ");
            parkplaetzeproetage = Int32.Parse(Console.ReadLine());

            Fahrzeug[,] SimpleArray = new Fahrzeug[etage, parkplaetzeproetage];

            Autohaus Parkhaus = new Autohaus(SimpleArray, etage, parkplaetzeproetage);

            Console.Clear();

            while (menu)
            {
                Console.WriteLine("\n        [Menu] \n - Fahrzeug hinzufuegen (1) \n - Fahrzeug suchen (2) \n - Fahrzeug entfernen(3) \n - Alle Fahrzeuge im Parkhaus (4) \n - Auslogen (5)");
                check = int.TryParse(Console.ReadLine(), out zahl);
                if (check)
                {
                    switch (zahl)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("[Fahrzeug hinzufugen]:");

                            do
                            {
                                Console.WriteLine("Auto (1) / Motorrad (2)");
                                check = Int32.TryParse(Console.ReadLine(), out zahl);

                                if (zahl == 1 || zahl == 2)
                                {
                                    check2 = true;
                                }


                            } while (!check2);


                            do
                            {
                                Console.Write("Kennzeichnen: ");
                                kennzeichnen = Console.ReadLine();
                            } while (kennzeichnen.Length < 3 || kennzeichnen.Length > 8);

                            if (zahl == 1)
                            {
                                Parkhaus.NeuesFahrzeug(new Auto(kennzeichnen));
                            }
                            else if (zahl == 2)
                            {
                                Parkhaus.NeuesFahrzeug(new Motorrad(kennzeichnen));

                            }

                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("[Fahrzeug suchen]\n");
                            Console.Write("Fahrzeug Kennzeichnen: ");
                            kennzeichnen = Console.ReadLine();
                            Parkhaus.FahrzeugFinden(kennzeichnen);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("[Fahrzeug entfernen]\n");
                            Console.Write("Fahrzeug Kennzeichnen: ");
                            kennzeichnen = Console.ReadLine();

                            Parkhaus.FahrzeugEntfernen(kennzeichnen);
                            break;
                        case 4:
                            Parkhaus.AlleFahrzeuge();
                            break;
                        case 5:
                            menu = false;
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nBitte, eine Zahl eingeben!");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }


        }
    }
}
