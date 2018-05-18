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
        private int startingMoney = 20;
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
                playerName = value;
            }
        }
        public int StartingMoney {
            get
            {
                return startingMoney;
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
            UserInterface userInterface = new UserInterface();
            userInterface.AskName();
            GetName();
        }

        public string GetName()
        {
            playerName = Console.ReadLine();
            return playerName;
        }



    }
}
