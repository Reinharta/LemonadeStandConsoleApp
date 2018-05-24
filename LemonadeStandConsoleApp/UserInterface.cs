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
            Console.WriteLine("\n");
            Console.WriteLine(message);
        }

        public static void DisplayList<T>(List <T> list)
        {
            list.ForEach(i => Console.WriteLine("{0}\t, i"));
        }

        public static void DisplayDictionary<T>(Dictionary<string, T> dictionary)
        {
            Console.WriteLine("\n");
            foreach (KeyValuePair<string, T> pair in dictionary)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
        //public static void DisplayDictionaryEntry(Dictionary<string, double> dictionary)
        //{
        //    foreach (KeyValuePair<string, double> pair in dictionary){
        //        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        //    }
        //}


        public static void MainMenu()
        {
            DisplayMessage("Main Menu:\nEnter Selection Number\n(1) View Current Stats\n(2) Store\n(3) Change Recipe\n(4) View Forecast\n(5) Play");
            string input = GetUserInput();
            if(input == "1")
            {
                DisplayCurrentStatus();
                MainMenu();
            }
            if(input == "2")
            {
                Store.StoreMenu();
            }
            if(input == "3")
            {
                Game.recipe.ChangeRecipeMenu();
            }
            if(input == "4")
            {
                //add forecast disp
            }
            if(input == "5")
            {
                //add start day
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

        //DISPLAYS


        public static void DisplayCurrentStatus()
        {
            DisplayTotalMoney();
            DisplayInventory();
            DisplayRecipe();
        }
        public static void DisplayInventory()
        {
            UserInterface.DisplayMessage("Your current Inventory is:");
            UserInterface.DisplayDictionary(Inventory.currentInventory);
        }
        public static void DisplayTotalMoney()
        {
            UserInterface.DisplayMessage("Your current account balance is: $" + Game.player.TotalMoney);
        }
        public static void DisplayRecipe()
        {
            UserInterface.DisplayMessage("Your current Lemonade Recipe is:");
            UserInterface.DisplayDictionary(Game.recipe.currentRecipe);
        }
        public static void DisplayRemainingDays()
        {
            //disp remaining days count
        }

    }
}
