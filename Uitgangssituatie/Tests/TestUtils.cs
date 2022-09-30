using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAI
{
    public class TestUtils
    {
        // ------------------------------------------------------------
        // Maakt een lijst van een string. Getallen zijn ints,
        // gescheiden door een spatie
        // ------------------------------------------------------------
        public static List<int> IntListFromString(string str)
        {
            List<int> list = new List<int>();

            if (str.Length > 0)
                list = str.Split(" ").Select(Int32.Parse).ToList();
            return list;
        }

        // ------------------------------------------------------------
        // Maakt een string van een Enumerable.
        // De enumerable kan eventueel gesorteerd worden (handig voor
        // sets).
        // ------------------------------------------------------------
        public static string EnumToString<T>(IEnumerable<T> lst, bool sort = false)
        {
            List<T> lst2 = new List<T>(lst);
            if (sort)
                lst2.Sort();
            return String.Join(" ", lst2);
        }

        // ------------------------------------------------------------
        // Maakt een string van een Enumerable.
        // Lijst wordt gesorteerd (handig voor vergelijken van sets).
        // ------------------------------------------------------------
        public static string EnumSortedToString<T>(IEnumerable<T> lst)
        {
            return EnumToString(lst, true);
        }
    }
}