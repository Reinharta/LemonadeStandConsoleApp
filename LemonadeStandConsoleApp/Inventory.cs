using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Inventory
    {
        private int lemonsInventory;
        private int sugarInventory;
        private int iceInventory;
        private int cupsInventory;

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
        public int IceInventory
        {
            get
            {
                return iceInventory;
            }
            set
            {
                iceInventory = value;
            }
        }
        public int CupsInventory
        {
            get
            {
                return cupsInventory;
            }
            set
            {
                cupsInventory = value;
            }
        }

        public Dictionary<string, int> currentInventory = new Dictionary<string, int>(){
            {"Lemons", 0 },
            {"Sugar", 0 },
            {"Ice", 0 }
        };

        // add to inventory
        // deduct from inventory
    }
}
