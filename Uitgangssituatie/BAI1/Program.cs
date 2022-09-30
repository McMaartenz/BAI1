using System;
using System.Collections.Generic;
using System.Linq;

namespace BAI
{
    public class BAI_Afteken1
    {
        /// ------------------------------------------------------------
        /// <summary>
        /// Filtert een lijst. Hierbij worden alle elementen die maar
        /// 1x voorkomen verwijderd
        /// </summary>
        /// <param name="lijst">De lijst die wordt doorlopen
        /// (wordt in functie veranderd)</param>
        /// ------------------------------------------------------------
        public static void Opdr1FilterList(List<int> lijst)
        {
            // *** IMPLEMENTATION HERE *** //
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            foreach (int number in lijst){
                if(numbers.ContainsKey(number)){ 
                    numbers[number]++;
                }
                else{
                    numbers.Add(number, 1);;
                }                
            }

            foreach (KeyValuePair<int, int> kv in numbers)
            {
                if (kv.Value != 1)
                {
                    continue;
                }

                lijst.Remove(kv.Key);
            }
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een queue van de getallen 1 t/m 50 (in die volgorde
        /// toegevoegd)
        /// </summary>
        /// <returns>Een queue met hierin 1, 2, 3, .., 50</returns>
        /// ------------------------------------------------------------
        public static Queue<int> Opdr2aQueue50()
        {
            Queue<int> q = new Queue<int>();

            // *** IMPLEMENTATION HERE *** //
            for (int i = 1; i <= 50; i++)
            {
                q.Enqueue(i);
            }

            return q;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Haalt alle elementen uit een queue. Voegt elk element dat
        /// deelbaar is door 4 toe aan een stack
        /// </summary>
        /// <param name="queue">De queue die uitgelezen wordt</param>
        /// <returns>De stack met hierin de elementen die deelbaar zijn
        /// door 4</returns>
        /// ------------------------------------------------------------
        public static Stack<int> Opdr2bStackFromQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();

            // *** IMPLEMENTATION HERE *** //

            while (queue.Count > 0)
            {
                int val = queue.Dequeue();
                if (val % 4 == 0)
                {
                    stack.Push(val);
                }
            }

            return stack;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een stack met hierin unieke random getallen</summary>
        /// <param name="lower">De ondergrens voor elk getal (inclusief)</param>
        /// <param name="upper">De bovengrens voor elk getal (inclusief)</param>
        /// <param name="count">Het aantal getallen</param>
        /// <returns>De stack met unieke random getallen</returns>
        /// ------------------------------------------------------------
        public static Stack<int> Opdr3RandomNumbers(int lower, int upper, int count)
        {
#nullable enable
            Dictionary<int, object?> dict = new Dictionary<int, object?>();
        
            // *** IMPLEMENTATION HERE *** //

            Random random = new Random();
            while(dict.Count < count)
            {
                int value = random.Next(lower, upper + 1);

                if (dict.ContainsKey(value)) continue;
                dict.TryAdd(value, null);

                /*if (dict.Contains(value)) continue;
                dict.Add(value, null);*/
            }

            return new Stack<int>(dict.Keys);
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Drukt een IEnumerable (List, Stack, Queue, ..) van getallen
        /// af naar de Console
        /// <param name="enu">De IEnumerable om af te drukken</param>
        /// ------------------------------------------------------------
        static void PrintEnumerable(IEnumerable<int> enu)
        {
            foreach (int i in enu)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            List<int> list;
            Queue<int> queue;
            Stack<int> stack;

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1 : FilterList ===");
            list = new List<int>() { 1, 3, 5, 7, 3, 8, 9, 5 };
            PrintEnumerable(list);
            Opdr1FilterList(list);
            PrintEnumerable(list);

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 2 : Stack / Queue ===");
            queue = Opdr2aQueue50();
            PrintEnumerable(queue);
            stack = Opdr2bStackFromQueue(queue);
            PrintEnumerable(stack);

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 3 : Random number ===");
            stack = Opdr3RandomNumbers(100, 150, 10);
            PrintEnumerable(stack);
            stack = Opdr3RandomNumbers(10, 15, 6);
            PrintEnumerable(stack);
            stack = Opdr3RandomNumbers(10_000, 50_000, 40_001);

            Console.WriteLine();
        }
    }
}
