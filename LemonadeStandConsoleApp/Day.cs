using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public class Day
    {
        public Day(Player player)
        {
            this.player = player;
        }

        public Weather weather = new Weather();

        Player player;
        private double salesMadeNum;
        private double salesProceeds;
        private double pricePerCup = 0.25;
        private int maxPotentialCustomers;
        private int customersPassed = 0;
        private int custSatisfactionPercent;
        private int todaysTemperature;
        private string todaysForecast;

        List<double> satisfactionList = new List<double>();
        List<object> todaysWeather = new List<object>();

        public double SalesMadeNum { get => salesMadeNum; set => salesMadeNum = value; }
        public double SalesProceeds { get => salesProceeds; set => salesProceeds = value; }
        public double PricePerCup { get => pricePerCup; set => pricePerCup = value; }
        public int MaxPotentialCustomers { get => maxPotentialCustomers; set => maxPotentialCustomers = value; }
        public int CustSatisfactionPercent { get => custSatisfactionPercent; set => custSatisfactionPercent = value; }
        public int TodaysTemperature { get => todaysTemperature; set => todaysTemperature = value; }
        public string TodaysForecast { get => todaysForecast; set => todaysForecast = value; }

        //Create new days
        public void CreateFirstDay(Player player, int gameLength, int dayCount)
        {
            weather.CreateSevenDayPrediction();
            CreateTodaysWeather(gameLength);
            weather.DisplayWeatherPrediction();
            UserInterface.DisplayTodaysWeather(todaysWeather);
            UserInterface.DisplayRecipe(player);
            UserInterface.DisplayCurrentPrice(PricePerCup);
            UserInterface.DisplayInventory(player);
            UserInterface.DisplayMessage("Day " + dayCount);
            RunNewDay(this, player);
        }
        public void CreateDay(Player player, int gameLength, int dayCount)
        {
            weather.CreateSevenDayPrediction();
            CreateTodaysWeather(gameLength);
            weather.UpdateSevenDayPrediction(gameLength);
            UserInterface.DisplayTodaysWeather(todaysWeather);
            UserInterface.DisplayRecipe(player);
            UserInterface.DisplayCurrentPrice(PricePerCup);
            UserInterface.DisplayInventory(player);
            UserInterface.DisplayMessage("Day " + dayCount);
            RunNewDay(this, player);

        }
        private void CreateTodaysWeather(int gameLength)
        {
            weather.CreateTodaysWeather(gameLength);
            TodaysTemperature = weather.TodayActualTemperature;
            TodaysForecast = weather.TodayActualForecast;
            todaysWeather.Add(weather.TodayActualTemperature);
            todaysWeather.Add(weather.TodayActualForecast);
        }
        private void SetPrice()
        {
            UserInterface.DisplayMessage("Please enter new price. EX: 0.25");
            PricePerCup = Convert.ToDouble(UserInterface.GetUserInput());
        }

        //Run Day of Play
        public void RunNewDay(Day today, Player player)
        {
            GetMaxCustomers(TodaysTemperature, TodaysForecast);
            if(customersPassed < MaxPotentialCustomers)
            {
                customersPassed = customersPassed + 1;
                new Customer(today, player).PurchaseCup(today);
            }
            if(customersPassed == MaxPotentialCustomers)
            {
                EndDay();
            }
        }
        private void GetMaxCustomers(int highTemperature, string forecast)
        {
            if(forecast == "Sunny") { MaxPotentialCustomers = MaxPotentialCustomers + 50; }
            if(forecast == "Cloudy") { MaxPotentialCustomers = MaxPotentialCustomers + 30; }
            if(forecast == "Rain" || forecast == "Thunderstorms") { MaxPotentialCustomers = MaxPotentialCustomers + 15; }
            if(highTemperature >= 80) { MaxPotentialCustomers = MaxPotentialCustomers + 50; }
            if(highTemperature <80 & highTemperature > 69) { maxPotentialCustomers = maxPotentialCustomers + 30; }
            if(highTemperature < 70) { maxPotentialCustomers = maxPotentialCustomers + 15; }
        }

        public void MakeSale(Customer customer)
        {
            SalesMadeNum = SalesMadeNum + 1;
            SalesProceeds = SalesProceeds + PricePerCup;
            satisfactionList.Add(customer.Satisfaciton);
            player.inventory.SellCup(player.recipe, this);

            if(player.inventory.PreparedCups == 0 || customersPassed == MaxPotentialCustomers)
            {
                EndDay();
            }
            else { RunNewDay(this, player); }

        }

        //End and finish day
        public void EndDay()
        {
            player.CalculateProfit();
            UserInterface.DisplayCurrentStatus(player, this);
            DisplayCustomersServed();
            player.inventory.InventoryLoss();
        }

        public void DisplayCustomersServed()
        {
            UserInterface.DisplayMessage("Out of " + MaxPotentialCustomers + " potential customers, " + SalesMadeNum + " purchased from you today!");
        }
        private int GetTotalSatisfaction()
        {
            //store each customer satisfaction percentage in list and find mean. Add daily percentage to list in Player

            return CustSatisfactionPercent;
        }
    }
}
