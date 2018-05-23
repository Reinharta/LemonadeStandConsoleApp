using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public static class UserInterface
    {

        public static string UpperFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            str = str.ToLower();
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayIntList(List <int> list)
        {
            list.ForEach(Console.WriteLine);
        }

        public static void DisplayDictionary<T>(Dictionary<string, T> dictionary)
        {

            foreach (KeyValuePair<string, T> pair in dictionary)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }

        public static void StoreMenu()
        {
            Console.WriteLine("Please enter what you would like to buy: \n1 - Cups \n2 - Lemons \n3 - Sugar \n4 - Ice \n5 - Exit");
        }

        public static string GetUserInput()
        {
            string input = Console.ReadLine();
            return input;
        }
        


    }
}
