using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public class Inventory
    {
        private int cupsInventory;
        private int lemonsInventory;
        private int sugarInventory;
        private int iceInventory;

        private Dictionary<string, int> currentInventory = new Dictionary<string, int>(){
            {"Cups", 0 },
            { "Lemons", 0},
            {"Sugar", 0 },
            {"Ice", 0 }
        };

        public int LemonsInventory
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
        public int SugarInventory
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
        public int IceInventory {
            get { return iceInventory; }
            set { iceInventory = value; }
        }
        public int CupsInventory {
            get { return cupsInventory; }
            set { cupsInventory = value; }
        }
        public Dictionary<string, int> CurrentInventory
        {
            get
            {
                return currentInventory;
            }
            set
            {
                currentInventory["Cups"] = CupsInventory;
                currentInventory["Lemons"] = LemonsInventory;
                currentInventory["Sugar"] = SugarInventory;
                currentInventory["Ice"] = IceInventory;
            }
        }


        public void AddInventory(string product, int quantity)
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
        public void ReduceInventory(string product, int quantity)
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
