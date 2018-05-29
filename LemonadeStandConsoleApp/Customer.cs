using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public class Customer
    {
        Random random = new Random();
        private int temperature;
        private string forecast;
        private double price;
        private double purchaseProbByTemperature;
        private double purchaseProbByForecast;
        private double purchaseProbByPrice;
        private double avgPurchaseProb;
        private Dictionary<string, int> recipe;
        private double satisfaction;

        public double Satisfaciton { get => satisfaction; }


        //constructor
        public Customer(Day today, Player player)
        {
            temperature = today.TodaysTemperature;
            forecast = today.TodaysForecast;
            price = today.PricePerCup;
            recipe = player.recipe.currentRecipe;
        }

        //Determine probability of purchase
        private void BuyChanceByTemperature()
        {
            if (temperature < 60)
            {
                purchaseProbByTemperature = random.Next(0, 16);
            }
            if (temperature > 59 & temperature < 70)
            {
                purchaseProbByTemperature = random.Next(16, 31);
            }
            if (temperature > 69 & temperature < 80)
            {
                purchaseProbByTemperature = random.Next(31, 41);
            }
            if (temperature > 79 & temperature < 90)
            {
                purchaseProbByTemperature = random.Next(41, 51);
            }
            if (temperature == 90)
            {
                purchaseProbByTemperature = random.Next(51, 71);
            }
        }
        private void BuyChanceByForecast()
        {
            if (forecast == "Sunny")
            {
                purchaseProbByForecast = random.Next(51, 71);
            }
            if (forecast == "Cloudy")
            {
                purchaseProbByForecast = random.Next(31, 41);
            }
            if (forecast == "Rain")
            {
                purchaseProbByForecast = random.Next(16, 31);
            }
            if (forecast == "Thunderstorms")
            {
                purchaseProbByForecast = random.Next(0, 16);
            }
        }
        private void BuyChanceByPrice()
        {
            if (temperature > 80)
            {
                purchaseProbByPrice = random.Next(51, 71);
            }
            if (temperature < 60)
            {
                if (price > .30)
                {
                    purchaseProbByPrice = random.Next(0, 16);
                }
                else
                {
                    purchaseProbByPrice = random.Next(16, 31);
                }
            }
            else
            {
                if (price < .40)
                {
                    purchaseProbByPrice = random.Next(51, 71);
                }
                if (price > .39)
                {
                    purchaseProbByPrice = random.Next(31, 41);
                }
            }
        }
        private void CalculateAvgPurchaseProb()
        {
            List<double> purchaseProbability = new List<double>();
            purchaseProbability.Add(purchaseProbByTemperature);
            purchaseProbability.Add(purchaseProbByForecast);
            purchaseProbability.Add(purchaseProbByPrice);
            avgPurchaseProb = purchaseProbability.Average();
        }

        //satisfaction based on recipe
        private void RecipeSatisfaction()
        {
            if (recipe["Lemons"] == 7 & recipe["Sugar"] == 4 & recipe["Ice"] == 5)
            {
                satisfaction = 100;
            }
            if (recipe["Lemons"] < 7 & recipe["Sugar"] < 4 & recipe["Ice"] < 5)
            {
                satisfaction = (recipe["Lemons"] * 4.7) + (recipe["Sugar"] * 8.25) + (recipe["Ice"] * 6.6);
            }
            else if (recipe["Lemons"] > 7 & recipe["Sugar"] > 4 & recipe["Ice"] > 5)
            {
                satisfaction = (30 - (recipe["Lemons"] * 1.5)) + (30 - (recipe["Sugar"] * 1.5)) + (30 - (recipe["Ice"] * 1.5));
            }
        }
        //make purchase
        public void PurchaseCup(Day today)
        {
            int willBuyNum = random.Next(0, 101);
            if (willBuyNum <= avgPurchaseProb)
            {
                RecipeSatisfaction();
                today.MakeSale(this);
            }
            else
            {
                return;
            }

        }

    }
}
