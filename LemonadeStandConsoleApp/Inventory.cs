using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public static class Inventory
    {
        private static int cupsInventory;
        private static int lemonsInventory;
        private static int sugarInventory;
        private static int iceInventory;



        public static int LemonsInventory
        {
            get
            {
                return lemonsInventory;
            }
            set
            {
                lemonsInventory = value;
            }
        }
        public static int SugarInventory
        {
            get
            {
                return sugarInventory;
            }
            set
            {
                sugarInventory = value;
            }
        }
        public static int IceInventory {
            get { return iceInventory; }
            set { iceInventory = value; }
        }
        public static int CupsInventory {
            get { return cupsInventory; }
            set { cupsInventory = value; }
        }

        public static Dictionary<string, int> currentInventory = new Dictionary<string, int>(){
            {"Cups", CupsInventory },
            { "Lemons", LemonsInventory},
            {"Sugar", SugarInventory },
            {"Ice", IceInventory }
        };

        public static void AddInventory(string product, int quantity)
        {
            product = UserInterface.UpperFirstLetter(product);
            if(currentInventory.ContainsKey(product))
            {
                currentInventory[product] = currentInventory[product] + quantity;
            }
            else
            {
                UserInterface.DisplayMessage("ERROR: product given does not match any product keys.");
            }
        }
        public static void ReduceInventory(string product, int quantity)
        {
            product = UserInterface.UpperFirstLetter(product);
            if (currentInventory.ContainsKey(product))
            {
                currentInventory[product] = currentInventory[product] - quantity;
            }
            else
            {
                UserInterface.DisplayMessage("ERROR: product given does not match any product keys.");
            }

        }

    }
}
