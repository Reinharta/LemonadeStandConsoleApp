using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Day
    {
        Weather weather = new Weather();

        private double salesMadeNum;
        private double salesProceeds;
        private double pricePerCup = 0.25;
        private int maxPotentialCustomers;
        private int custSatisfactionPercent;
        private int todaysTemperature;

        List<object> todaysWeather = new List<object>();

        public void CreateDay(Player player)
        {
            CreateTodaysWeather();
            UserInterface.DisplayTodaysWeather(todaysWeather);
            UserInterface.DisplayRecipe(player);
            UserInterface.DisplayCurrentPrice(pricePerCup);
            UserInterface.DisplayInventory(player);


        }

        private void CreateTodaysWeather()
        {
            todaysWeather.Add(weather.TodayActualTemperature);
            todaysWeather.Add(weather.TodayActualForecast);
        }
        private void SetPrice()
        {
            UserInterface.DisplayMessage("");
        }
        private int GetMaxCustomers(int highTemperature, string forecast, int custSatisfactionPercent)
        {

            return maxPotentialCustomers;
        }

        private int GetTotalSatisfaction()
        {
            //store each customer satisfaction percentage in list and find mean. Add daily percentage to list in Player

            return custSatisfactionPercent;
        }


        

        // display total profit (from player) at end of each day?
        // at end of each day - display # sales made, sales earnings, profit margin to date, total money (account balance?)
        // methods for inventory reductions (ice melting, bugs in sugar, rotten lemons)
    }
}
