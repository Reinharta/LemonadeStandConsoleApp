using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public static class UserInterface
    {

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayIntList(List <int> list)
        {
            list.ForEach(Console.WriteLine);
        }

        public static void DisplayStIntDictionary(Dictionary<string, int> dictionary)
        {

            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }

        public static string GetUserInput()
        {
            string input = Console.ReadLine();
            return input;
        }
        


    }
}
