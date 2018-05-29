using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public class Weather
    {
        Random random = new Random();

        private string todayActualForecast;
        private int todayActualTemperature;
        private int maxTemperature = 90;
        private int minTemperature = 50;
        private List<string> forecastList = new List<string>() {
            "Sunny",
            "Cloudy",
            "Rain",
            "Thunderstorms"
        };
        private List <int> sevenDayTemperatureList = new List<int>();
        private List <string> sevenDayForecastList = new List<string>();


        //PROPERTIES
        public string TodayActualForecast
        {
            get
            {
                return todayActualForecast;
            }
        }
        public int TodayActualTemperature
        {
            get
            {
                return todayActualTemperature;
            }
        }
        public List<string> SevenDayForecastList
        {
            get { return sevenDayForecastList; }
        }
        public List<int> SevenDayTemperatureList
        {
            get
            {
                return sevenDayTemperatureList;
            }
        }

        //7 day prediction
        public void CreateSevenDayPrediction()
        {
            CreateSevenDayForecast();
            CreateSevenDayTemperatures();

        }
        public void CreateSevenDayForecast()
        {
            for (int i = 0; i < 7; i++) 
            {
                string condition = CreateForecastInstance();
                sevenDayForecastList.Add(condition);
            }
        }
        public void CreateSevenDayTemperatures()
        {
            for (int i = 0; i < 7; i++)
            {
                int degrees = CreateTemperatureInstance();
                sevenDayTemperatureList.Add(degrees);
            }
        }

        //Today
        public void CreateTodaysWeather(int gameLength)
        {
            int forecastSelecter = random.Next(0, 9);
            if (forecastSelecter == 0 || forecastSelecter > forecastList.Count)
            {
                todayActualForecast = SevenDayForecastList[0];
            }
            else
            {
                todayActualForecast = forecastList.ElementAt(forecastSelecter - 1);
            }

            todayActualTemperature = (random.Next(-5, 6) + SevenDayTemperatureList[0]);
            UpdateSevenDayPrediction(gameLength);
        }

        //instances
        public string CreateForecastInstance()
        {
            int conditionIndex = random.Next(0, (forecastList.Count));
            string condition = forecastList.ElementAt(conditionIndex);
            return condition;
        }
        public int CreateTemperatureInstance()
        {
            int degrees = random.Next(minTemperature, maxTemperature + 1);
            return degrees;
        }

        //day shifting
        public void UpdateSevenDayPrediction(int gameLength)
        {
            sevenDayForecastList.RemoveAt(0);
            AddEndForecastList(gameLength);
            sevenDayTemperatureList.RemoveAt(0);
            AddEndTemperatureList(gameLength);
        }
        public void AddEndTemperatureList(int gameLength)
        {
            if (gameLength >= 7){
                int newTemperature = CreateTemperatureInstance();
                sevenDayTemperatureList.Add(newTemperature);
            }
        }
        public void AddEndForecastList(int gameLength)
        {
            if (gameLength >= 7)
            {
                string newForecast = CreateForecastInstance();
                sevenDayForecastList.Add(newForecast);
                return;
            }
        }

        //Displays
        public void DisplayTodaysWeather()
        {
            UserInterface.DisplayMessage("Today's weather: " + TodayActualTemperature + " degrees and " + TodayActualForecast);
        }
        public void DisplayWeatherPrediction()
        {
            UserInterface.DisplayMessage("7 Day Forecast:");
            UserInterface.DisplayStrList(SevenDayForecastList);
            UserInterface.DisplayIntList(SevenDayTemperatureList);
        }

    }
}
