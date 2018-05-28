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

        //DISPLAYS

        public static void DisplayMessage(string message)
        {
            Console.WriteLine("\n");
            Console.WriteLine(message);
        }

        public static void DisplayIntList(List <int> list)
        {
            list.ForEach(Console.WriteLine);
        }
        public static void DisplayStrList(List<string> list)
        {
            list.ForEach(Console.WriteLine);
        }

        public static void DisplayDictionary<T>(Dictionary<string, T> dictionary)
        {
            //Console.WriteLine("\n");
            foreach (KeyValuePair<string, T> pair in dictionary)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
        public static void DisplayQtyPriceDictionary<T>(Dictionary<string, T> dictionary)
        {
            Console.WriteLine("\n");
            foreach (KeyValuePair<string, T> pair in dictionary)
            {
                Console.WriteLine("QTY {0}: ${1}", pair.Key, pair.Value);
            }
        }
        //public static void DisplayDictionaryEntry(Dictionary<string, double> dictionary)
        //{
        //    foreach (KeyValuePair<string, double> pair in dictionary){
        //        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        //    }
        //}
        public static void DisplayArray(Array array)
        {
            Console.WriteLine(string.Join("\n", array));
        }

            //MENUS

        public static string MainMenu()
        {
            DisplayMessage("Main Menu:\nEnter Selection Number\n(1) View Current Stats\n(2) Store\n(3) Change Recipe\n(4) View Forecast\n(5) Play");
            return GetUserInput();
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

        //DISPLAYS


        public static void DisplayCurrentStatus(Player player)
        {
            DisplayTotalMoney(player);
            DisplayInventory(player);
            DisplayRecipe(player);

        }
        public static void DisplayInventory(Player player)
        {
            DisplayMessage("Your current Inventory is:");
            DisplayDictionary(player.inventory.CurrentInventory);
        }
        public static void DisplayTotalMoney(Player player)
        {
            DisplayMessage("Your current account balance is: $" + player.TotalMoney);
        }
        public static void DisplayRecipe(Player player)
        {
            DisplayMessage("Your current Lemonade Recipe is:");
            DisplayDictionary(player.recipe.currentRecipe);
        }
        public static void DisplayRemainingDays()
        {
            //disp remaining days count
        }
        public static void DisplayCurrentPrice(double pricePerCup)
        {
            DisplayMessage("Price: $" + pricePerCup);
        }
        public static void DisplayTodaysWeather(List<object> todaysWeather)
        {
            DisplayMessage("Today's Weather: ");
            todaysWeather.ForEach(Console.WriteLine);
        }
    }
}
