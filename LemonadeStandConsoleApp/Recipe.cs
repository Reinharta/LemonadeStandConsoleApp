using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public class Recipe
    {
        private int lemonsPerPitcher;
        private int sugarCupsPerPitcher;
        private int iceCubesPerCup;
        private int cupsPerPitcher;

        public int LemonsPerPitcher
        {
            get
            {
                return lemonsPerPitcher;
            }
            set
            {
                lemonsPerPitcher = value;
            }
        }
        public int SugarCupsPerPitcher
        {
            get
            {
                return sugarCupsPerPitcher;
            }
            set
            {
                sugarCupsPerPitcher = value;
            }
        }
        public int IceCubesPerCup
        {
            get
            {
                return iceCubesPerCup;
            }
            set
            {
                iceCubesPerCup = value;
            }
        }
        public int CupsPerPitcher
        {
            get
            {
                return cupsPerPitcher;
            }
            set
            {
                iceCubesPerCup = value;
            }
        }



        public Dictionary<string, int> currentRecipe = new Dictionary<string, int>(){
            {"Lemons", 4 },
            {"Sugar", 4 },
            {"Ice", 4 }
        };

        public void ChangeRecipeMenu()
        {
            string key = "";
            
            UserInterface.DisplayMessage("What would you like to change?\n(1) Lemons\n(2) Sugar\n(3) Ice\n(4) Exit");
            string input = UserInterface.GetUserInput();
            input = UserInterface.UpperFirstLetter(input);
            if (input == "4" || input == "Exit")
            {
                return;
            }
            if (currentRecipe.ContainsKey(input)){
                key = input;
            }
            else
            {
                Int32.TryParse(input, out int parsedInput);
                if (parsedInput == 1) { key = "Lemons"; }
                if (parsedInput == 2) { key = "Sugar"; }
                if (parsedInput == 3) { key = "Ice"; }
            }
            UserInterface.DisplayMessage("Please enter new desired quantity of " + key +".");
            Int32.TryParse(UserInterface.GetUserInput(), out int qty);
            ChangeRecipe(key, qty);
            }

        

        public void ChangeRecipe(string key, int value)
        {

            if (currentRecipe.ContainsKey(key) & value >= 0)
            {
                currentRecipe[key] = value;
            }
            else
            {
                UserInterface.DisplayMessage("Invalid Input. Please try again.");
            }
            ChangeRecipeMenu();
        }


        //public void ChangeRecipeValues()
        //{
        //    currentRecipe["Lemons"] = lemonsPerPitcher;
        //    currentRecipe["Sugar"] = sugarCupsPerPitcher;
        //    currentRecipe["Ice"] = iceCubesPerCup;
        //}
        


        // calculate # of cups per pitcher based on ice 
        // cupsperpitcher 


    }
}
