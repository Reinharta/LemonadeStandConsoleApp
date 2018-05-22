using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Store
    {

        private double purchaseTotal;

        Dictionary<string, double> cupsForSale = new Dictionary<string, double>() {
            {"25", 0.82 },
            {"50", 1.71 },
            {"100", 3.03 }
        };
        Dictionary<string, double> lemonsForSale = new Dictionary<string, double>() {
            {"10", 0.57 },
            {"30", 2.11 },
            {"75", 4.41 }
        };
        Dictionary<string, double> sugarForSale = new Dictionary<string, double>() {
            {"8 cups", 0.61 },
            {"20 cups", 1.71 },
            {"48 cups", 3.36 }
        };
        Dictionary<string, double> iceForSale = new Dictionary<string, double>() {
            {"100 cubes", 0.96 },
            {"250 cubes", 2.03 },
            {"500 cubes", 3.72 }
        };

        public double PurchaseTotal
        {
            get
            {
                return purchaseTotal;
            }
        }
        public Dictionary<string, double> CupsForSale
        {
            get
            {
                return cupsForSale;
            }
        }
        public Dictionary<string, double> LemonsForSale
        {
            get
            {
                return lemonsForSale;
            }
        }
        public Dictionary<string, double> SugarForSale
        {
            get
            {
                return sugarForSale;
            }
        }
        public Dictionary<string, double> IceForSale
        {
            get
            {
                return iceForSale;
            }
        }

        // var total money spent that day, passed to Player to add to expenses and calculate total profit
        // 

    }
}
