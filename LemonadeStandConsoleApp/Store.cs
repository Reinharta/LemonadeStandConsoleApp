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

        private static Dictionary<string, double> cupsForSale = new Dictionary<string, double>() {
            {"25", 0.82 },
            {"50", 1.71 },
            {"100", 3.03 }
        };
        private static Dictionary<string, double> lemonsForSale = new Dictionary<string, double>() {
            {"10", 0.57 },
            {"30", 2.11 },
            {"75", 4.41 }
        };
        private static Dictionary<string, double> sugarForSale = new Dictionary<string, double>() {
            {"8", 0.61 },
            {"20", 1.71 },
            {"48", 3.36 }
        };
        private static Dictionary<string, double> iceForSale = new Dictionary<string, double>() {
            {"100", 0.96 },
            {"250", 2.03 },
            {"500", 3.72 }
        };
        private static Dictionary<string, Dictionary<string, double>> storeOfferings = new Dictionary<string, Dictionary<string, double>>() {
            {"Cups", CupsForSale },
            {"Lemons", LemonsForSale },
            {"Sugar", SugarForSale },
            {"Ice", IceForSale }
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
        public static Dictionary<string, Dictionary<string, double>> StoreOfferings
        {
            get
            {
                return storeOfferings;
            }
        }

        //RunStore method to chain methods below?


        public static void StoreMenu()
        {
            UserInterface.StoreMenu();
            string input = UserInterface.UpperFirstLetter(UserInterface.GetUserInput());
            AssessMenuInput(input);
        }

        public static void AssessMenuInput (string input) {

            if (input == "Exit" || input == "5")
            {
                return;
            }
            if (StoreOfferings.ContainsKey(input))
            {
                PurchaseProduct(input);
            }
            else
            {
                Int32.TryParse(input, out int parsedInput);
                if (parsedInput == 1) { input = "Cups"; }
                if (parsedInput == 2) { input = "Lemons"; }
                if (parsedInput == 3) { input = "Sugar"; }
                if (parsedInput == 4) { input = "Ice"; }
                PurchaseProduct(input);
            }
        }

        public static void PurchaseProduct(string productKey)
        {
            UserInterface.DisplayMessage("Please enter the quantity of " + productKey + " you would like to purchase.\nNOTE: Sugar quantity is in cups, Ice quantity is in cubes.");
            UserInterface.DisplayDictionary(StoreOfferings[productKey]);
            string quantityInput = UserInterface.GetUserInput();
            double cost = 0;
            if (StoreOfferings[productKey].ContainsKey(quantityInput))
            {
                cost = StoreOfferings[productKey][quantityInput];
            }
            else
            {
                UserInterface.DisplayMessage("Invalid input. Please try again.");
                PurchaseProduct(productKey);
            }

            CheckOut(productKey, quantityInput, cost);
        }

        public static void CheckOut(string productName, string strQuantity, double cost)
        {
            bool canPurchase = VerifyFunds(cost);
            Int32.TryParse(strQuantity, out int intQty);
            if (canPurchase is true)
            {
                Inventory.AddInventory(productName, intQty);
                Game.player.DeductMoney(cost);
                Game.player.AddToExpensesTotal(cost);
            }
            if(canPurchase is false)
            {
                UserInterface.DisplayMessage("You do not have enough money to make this purchase.");
                PurchaseProduct(productName);
            }


        }
       
        public static bool VerifyFunds(double productCost)
        {
            if(Game.player.TotalMoney >= productCost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // compare totalmoney to cost of product and deny purchase if not enough funds.
        

    }
}
