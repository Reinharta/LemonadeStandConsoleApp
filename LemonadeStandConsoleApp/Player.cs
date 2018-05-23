using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Player
    {

        private string playerName;
        private double startingMoney = 20.00;
        private double salesProceeds;
        private double totalMoney;
        private double expensesTotal;
        private double profit;

        //Properties//
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                if (value.Length >= 1)
                {
                    playerName = value;
                }
                else if (value.Length < 1)
                {
                    SetName();
                }
            }
        }
        public double StartingMoney {
            get
            {
                return startingMoney;
            }
            set
            {
                startingMoney = value;
            }
        }
        public double SalesProceeds
        {
            get
            {
                return salesProceeds;
            }
            set
            {
                salesProceeds = value;
            }
        }
        public double TotalMoney
        {
            get
            {
                return totalMoney;
            }
            set
            {
                totalMoney = value;
            }
        }
        public double ExpensesTotal
        {
            get
            {
                return expensesTotal;
            }
        }
        public double Profit
        {
            get
            {
                return profit;
            }
            set
            {
                profit = value;
            }
        }

        public void SetName()
        {
            UserInterface.DisplayMessage("Please enter Player Name.");
            PlayerName = UserInterface.GetUserInput();
        }
        public void AddMoney(double moneyMade)
        {
            totalMoney = (totalMoney + moneyMade);
        }
        public void DeductMoney(double moneySpent)
        {
            totalMoney = (totalMoney - moneySpent);
        }
        public void AddToExpensesTotal(double moneySpent)
        {
            expensesTotal = (expensesTotal + moneySpent);
        }



        //method to calculate profit ( total money - (starting money + $spent in store) )


        
    }
}
