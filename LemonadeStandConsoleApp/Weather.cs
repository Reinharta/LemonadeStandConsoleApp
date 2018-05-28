using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Weather
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
        private int[] sevenDayTemperatureArray = new int[7];
        private string[] sevenDayForecastArray = new string[7];


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
        public string[] SevenDayForecastArray
        {
            get { return sevenDayForecastArray; }
        }
        public int[] SevenDayTemperatureArray
        {
            get
            {
                return sevenDayTemperatureArray;
            }
        }


        public void CreateSevenDayForecast()
        {
            for (int i = 0; i < sevenDayForecastArray.Length; i++) 
            {
                string condition = CreateForecastInstance();
                sevenDayForecastArray[i] = condition;
            }
        }
        public void CreateSevenDayTemperatures()
        {
            for (int i = 0; i < sevenDayTemperatureArray.Length; i++)
            {
                int degrees = CreateTemperatureInstance();
                sevenDayTemperatureArray[i] = degrees;
            }
        }

        public string CreateForecastInstance()
        {
            int conditionIndex = random.Next(0, (forecastList.Count + 1));
            string condition = forecastList.ElementAt(conditionIndex);
            return condition;
        }
        public int CreateTemperatureInstance()
        {
            int degrees = random.Next(minTemperature, maxTemperature + 1);
            return degrees;
        }

        //end day
        public void AddEndTemperatureList(int gameLength)
        {
            while (gameLength >= 7){
                int newTemperature = CreateTemperatureInstance();
                sevenDayTemperatureArray[6] = newTemperature;
            }
        }
        public void AddEndForecastList(int gameLength)
        {
            while (gameLength >= 7)
            {
                string newForecast = CreateForecastInstance();
                sevenDayForecastArray[6] = newForecast;
            }
        }

        public void CreateTodaysWeather()
        {
            int forecastSelecter = random.Next(0, 9);
            if (forecastSelecter == 0 || forecastSelecter > forecastList.Count)
            {
                todayActualForecast = SevenDayForecastArray[0];
            }
            else
            {
                todayActualForecast = forecastList.ElementAt(forecastSelecter);
            }

            todayActualTemperature = (random.Next(0, 6) + SevenDayTemperatureArray[0]);
        }

        public void DisplayTodaysWeather()
        {
            UserInterface.DisplayMessage("Today's weather: " + TodayActualTemperature + " degrees and " + TodayActualForecast);
        }
        public void DisplayWeatherPrediction()
        {
            UserInterface.DisplayMessage("7 Day Forecast:");
            UserInterface.DisplayArray(SevenDayForecastArray);
            UserInterface.DisplayArray(SevenDayTemperatureArray);
        }

        // create 7 day forecast prediction (plan for end of game <7 days left), (i=0, key/val, must not clear at new instances. Remove i=o, add to end)
        // limit day to day variance by 10degrees
        // create one day forecast prediction, add to ^^ end
        // display 7 day prediction
        // create current day actual weather as variant of forecast (i=0, key=today), need to carry/not clear at new instances. Remove first index, add new to end
        // actual temp to predicted temp variance limited by +-XXdegrees
        // actual forecast more likely to be as predicted, 2/3 chance. Possible small chance of rain repeating? 1/10?
        // 

    }
}
