using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public static class Store
    {

        private static double purchaseTotal;

        static Dictionary<string, double> cupsForSale = new Dictionary<string, double>() {
            {"25", 0.82 },
            {"50", 1.71 },
            {"100", 3.03 }
        };
        static Dictionary<string, double> lemonsForSale = new Dictionary<string, double>() {
            {"10", 0.57 },
            {"30", 2.11 },
            {"75", 4.41 }
        };
        static Dictionary<string, double> sugarForSale = new Dictionary<string, double>() {
            {"8 cups", 0.61 },
            {"20 cups", 1.71 },
            {"48 cups", 3.36 }
        };
        static Dictionary<string, double> iceForSale = new Dictionary<string, double>() {
            {"100 cubes", 0.96 },
            {"250 cubes", 2.03 },
            {"500 cubes", 3.72 }
        };

        public static double PurchaseTotal
        {
            get
            {
                return purchaseTotal;
            }
        }
        public static Dictionary<string, double> CupsForSale
        {
            get
            {
                return cupsForSale;
            }
        }
        public static Dictionary<string, double> LemonsForSale
        {
            get
            {
                return lemonsForSale;
            }
        }
        public static Dictionary<string, double> SugarForSale
        {
            get
            {
                return sugarForSale;
            }
        }
        public static Dictionary<string, double> IceForSale
        {
            get
            {
                return iceForSale;
            }
        }

        //dictionary containing each product dict -- not inserted, need to re-do StoreMenu, etc to use this
        public static Dictionary<string, Dictionary<string, double>> storeOfferings = new Dictionary<string, Dictionary<string, double>>() {
            {"Cups", CupsForSale },
            {"Lemons", LemonsForSale },
            {"Sugar", SugarForSale },
            {"Ice", IceForSale }
        };

        public static void StoreMenu()
        {
            UserInterface.StoreMenu();
            int parsedInput;
            string input = UserInterface.UpperFirstLetter(UserInterface.GetUserInput());
            Int32.TryParse(input, out parsedInput);
            if (parsedInput > 0)
            {
                //indexInput = parsedInput + 1;
            }

            //NEW METHOD - Assess menu choice(string choice)
            // TRANSITION TO USING STOREOFFERINGS DICT == compare input to key || compare indexInput to index length + assign to proper index.
            if(input == "cups")
            {
                PurchaseProduct("Cups", CupsForSale);
            }
            if(input == "lemons" || input == "2")
            {
                PurchaseProduct("Lemons", LemonsForSale);
            }
            if(input == "sugar" || input == "3")
            {
                PurchaseProduct("cups of Sugar", SugarForSale);
            }
            if(input == "ice" || input == "4")
            {
                PurchaseProduct("Ice Cubes", IceForSale);
            }
            if(input == "exit" || input == "5")
            {
                return;
            }
        }
        private string ConvertNumChoiceToKey(int choice)
        {
            string choiceString;

            return choiceString;
        }
        public static void PurchaseProduct(string product, Dictionary<string, double> productOptions)
        {
            UserInterface.DisplayMessage("How many " + product + " would you like to buy? Please enter the quantity.");
            UserInterface.DisplayDictionary(productOptions);
            string quantity = UserInterface.GetUserInput();
            double cost;
            if (productOptions.ContainsKey(quantity))
            {
                cost = productOptions[quantity];
            }
        }
        public static void AddProductToInventory()
        {

        }

        // var total money spent that day, passed to Player to add to expenses and calculate total profit
        // 

    }
}
