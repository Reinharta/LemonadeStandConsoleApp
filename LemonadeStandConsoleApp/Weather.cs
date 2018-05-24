﻿using System;
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
        // string list of possible forecast values
        private int todayActualTemperature;
        // limit w/ min and max
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

        //move this to game or UI, passing object parameters as needed
        // cntrl then type replaces char
        public void AddEndTemperatureList()
        {
            while (){
                int newTemperature = CreateTemperatureInstance();
                sevenDayTemperatureArray[6] = newTemperature;
            }
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
