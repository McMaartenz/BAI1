using System;
using System.Collections.Generic;

namespace BAI
{
    public partial class BAI_Afteken2
    {
        public static bool Vooruit(uint b)
        {
            // *** IMPLEMENTATION HERE *** //

            return (b & 0b1000_0000) > 0;
        }

        public static uint Vermogen(uint b)
        {
            // *** IMPLEMENTATION HERE *** //

            b = (b & 0b0110_0000) >> 5;
            switch (b)
            {
                case 0b00:
                    return 0;
                case 0b01: 
                    return 33;
                case 0b10:
                    return 67;
                case 0b11:
                    return 100;
            }
            return 0;
        }

        public static bool Wagon(uint b)
        {
            // *** IMPLEMENTATION HERE *** //

            return (b & 0b0001_0000) > 0;
        }

        public static bool Licht(uint b)
        {
            // *** IMPLEMENTATION HERE *** //
            return (b & 0b0000_1000) > 0;
        }

        public static uint ID(uint b)
        {
            // *** IMPLEMENTATION HERE *** //

            return b & 0b0000_0111;
        }

        public static HashSet<uint> Alle(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //

            foreach (uint b in inputStroom)
            {
                set.Add(b);
            }

            return set;
        }

        public static HashSet<uint> ZonderLicht(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //

            foreach(uint b in inputStroom)
            {
                if (!Licht(b))
                {
                    set.Add(b);
                }
            }

            return set;
        }

        public static HashSet<uint> MetWagon(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //

            foreach (uint b in inputStroom)
            {
                if (Wagon(b))
                {
                    set.Add(b);
                }
            }

            return set;
        }

        public static HashSet<uint> SelecteerID(List<uint> inputStroom, uint lower, uint upper)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            
            foreach (uint b in inputStroom)
            {
                uint id = ID(b);

                if ((id >= lower) && (id <= upper))
                {
                    set.Add(b);
                }
            }
            return set;
        }

        public static HashSet<uint> Opdr3a(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            
            set = SelecteerID(inputStroom, 0, 2);
            set.IntersectWith(ZonderLicht(inputStroom));

            return set;
        }

        public static HashSet<uint> Opdr3b(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //

            var opdr3a = Opdr3a(inputStroom);
            var alles = Alle(inputStroom);

            set = Alle(inputStroom);

            set.ExceptWith(opdr3a);

            var zonderLicht = ZonderLicht(inputStroom);
            alles.ExceptWith(zonderLicht);

            set.UnionWith(alles);


            return set;
        }

        public static void ToonInfo(uint b)
        {
            Console.WriteLine($"ID {ID(b)}, Licht {Licht(b)}, Wagon {Wagon(b)}, Vermogen {Vermogen(b)}, Vooruit {Vooruit(b)}");
        }

        public static List<uint> GetInputStroom()
        {
            List<uint> inputStream = new List<uint>();
            for (uint i = 0; i < 256; i++)
            {
                inputStream.Add(i);
            }
            return inputStream;
        }

        public static void PrintSet(HashSet<uint> x)
        {
            Console.Write("{");
            foreach (uint i in x)
                Console.Write($" {i}");
            Console.WriteLine($" }} ({x.Count} elementen)");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Opgave 1 ===");
            ToonInfo(210);
            Console.WriteLine();

            List<uint> inputStroom = GetInputStroom();

            Console.WriteLine("=== Opgave 2 ===");
            HashSet<uint> alle = Alle(inputStroom);
            PrintSet(alle);
            HashSet<uint> zonderLicht = ZonderLicht(inputStroom);
            PrintSet(zonderLicht);
            HashSet<uint> metWagon = MetWagon(inputStroom);
            PrintSet(metWagon);
            HashSet<uint> groter6 = SelecteerID(inputStroom, 6, 7);
            PrintSet(groter6);
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3a ===");
            HashSet<uint> opg3a = Opdr3a(inputStroom);
            PrintSet(opg3a);
            foreach (uint b in opg3a)
            {
                ToonInfo(b);
            }
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3b ===");
            HashSet<uint> opg3b = Opdr3b(inputStroom);
            PrintSet(opg3b);
            foreach (uint b in opg3b)
            {
                ToonInfo(b);
            }
            Console.WriteLine();
        }
    }
}
