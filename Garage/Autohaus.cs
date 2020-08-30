using System;
using System.Threading;


namespace Garage
{
    class Autohaus
    {
        public int Etage { get; private set; }
        public int Parkplaetzeproetage { get; private set; }
        public static Fahrzeug[,] ArrayFahrzeuge;

        public Autohaus(Fahrzeug[,] myArray, int etage, int parkplaetzeproetage)
        {
            ArrayFahrzeuge = myArray;
            Etage = etage;
            Parkplaetzeproetage = parkplaetzeproetage;
        }


        public void NeuesFahrzeug(Fahrzeug obj)
        {
            if (!CheckFahrzeug(obj))
            {
                for (int column = 0; column < Etage; column++)
                {
                    for (int row = 0; row < Parkplaetzeproetage; row++)
                    {
                        if ((ArrayFahrzeuge[column, row] == null))
                        {
                            ArrayFahrzeuge[column, row] = obj;
                            column = Etage;
                            Console.WriteLine("Fahrzeug gespeichert!");
                            break;
                        }
                        if (((column + 1) * (row + 1) == (Etage * Parkplaetzeproetage)))
                        {                                                    
                            Console.WriteLine("Parkhaus ist voll!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Dieses Fahrzeug existiert bereits!");
            }
        }

        public void AlleFahrzeuge()
        {
            int counter = 0;
            Console.Clear();
            for (int column = 0; column < Etage; column++)
            {
                for (int row = 0; row < Parkplaetzeproetage; row++)
                {
                    if (ArrayFahrzeuge[column, row] != null)
                    {
                        Console.WriteLine($"Etage: {column} Parkplatz: {row + 1}  - Fahrzeug-Kennzeichnen: {ArrayFahrzeuge[column, row]} - Typ: {ArrayFahrzeuge[column, row].GetType().Name}");
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($"Etage: {column} Parkplatz: {row + 1} - Leerer Parkplatz");
                    }
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine($"\nParkplaetze Gesamt: {ArrayFahrzeuge.Length}, Freie Parkplaetze: {ArrayFahrzeuge.Length - counter}, Besetzte Parkplaetze: {counter}");
            Console.WriteLine("\nZurueck  ins Menu -> [ENTER]");
            Console.Read();
            Console.Clear();
        }


        public void FahrzeugEntfernen(string kennzeichnen)
        {
            for (int column = 0; column < Etage; column++)
            {
                for (int row = 0; row < Parkplaetzeproetage; row++)
                {
                    if (ArrayFahrzeuge[column, row] != null)
                    {
                        if (ArrayFahrzeuge[column, row].ToString() == kennzeichnen.ToString())
                        {
                            ArrayFahrzeuge[column, row] = null;
                            column = Etage;
                            Console.WriteLine($"Fahrzeug {kennzeichnen} ist geloescht!");
                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        if (((column + 1) * (row + 1) != (Etage * Parkplaetzeproetage)))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Fahrzeug suchen...");
                            Thread.Sleep(300);
                            Console.Clear();

                        }
                        else
                        {
                            Console.WriteLine("Fahrzeug nicht gefunden.");
                            Thread.Sleep(1500);
                            Console.Clear();
                        }

                    }
                }
            }
        }


        private bool CheckFahrzeug(Fahrzeug obj)
        {
            bool check = false;
            for (int column = 0; column < Etage; column++)
            {
                for (int row = 0; row < Parkplaetzeproetage; row++)
                {
                    if (ArrayFahrzeuge[column, row] != null)
                    {
                        if (ArrayFahrzeuge[column, row].ToString() == obj.Kennzeichnen.ToString())
                        {
                            check = true;

                        }
                    }
                }
            }
            return check;
        }


        public void FahrzeugFinden(string kennzeichnen)
        {
            Console.Clear();
            for (int column = 0; column < Etage; column++)
            {
                for (int row = 0; row < Parkplaetzeproetage; row++)
                {
                    if (ArrayFahrzeuge[column, row] != null)
                    {
                        if (ArrayFahrzeuge[column, row].ToString() == kennzeichnen.ToString())
                        {
                            Console.WriteLine($"Etage: {column} Parkplatz: {row + 1} - Fahrzeug: {ArrayFahrzeuge[column, row]} - Typ: {ArrayFahrzeuge[column, row].GetType().Name}");
                            column = Etage;
                            break;
                        }
                    }
                    else
                    {
                        if (((column + 1) * (row + 1) != (Etage * Parkplaetzeproetage)))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Fahrzeug suchen...");
                            Thread.Sleep(300);
                            Console.Clear();

                        }
                        else
                        {
                            Console.WriteLine("Fahrzeug nicht gefunden.");
                            Thread.Sleep(1500);
                            Console.Clear();
                        }
                    }
                }
            }
            Console.WriteLine("\nZurueck  ins Menu -> [ENTER]");
            Console.Read();
            Console.Clear();

        }
    }
}
