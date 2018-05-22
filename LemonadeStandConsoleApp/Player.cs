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
        private int earnedMoney;
        private int totalMoney;
        private int profit;

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
        public int EarnedMoney
        {
            get
            {
                return earnedMoney;
            }
            set
            {
                earnedMoney = value;
            }
        }
        public int TotalMoney
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
        public int Profit
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

        public void CalculateTotalMoney()
        {

        }

        //separate methods for deducting and adding to total money. 
        //variable to track money spent in store 
        //method to calculate profit ( total money - (starting money + $spent in store) )


        // change types of money variables to double
    }
}
