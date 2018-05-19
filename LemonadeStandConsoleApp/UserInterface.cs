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

        public static void DisplayList(List <int> list)
        {
            list.ForEach(Console.WriteLine);
        }

        public static string GetUserInput()
        {
            string input = Console.ReadLine();
            return input;
        }
        


    }
}
