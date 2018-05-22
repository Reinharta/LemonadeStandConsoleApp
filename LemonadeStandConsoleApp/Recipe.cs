using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Recipe
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



        Dictionary<string, int> currentRecipe = new Dictionary<string, int>(){
            {"Lemons", 4 },
            {"Sugar", 4 },
            {"Ice", 4 }
        };

        public Dictionary<string,int> CurrentRecipe
        {
            get
            {
                return currentRecipe;
            }
        }


        public void ChangeRecipeValues()
        {
            currentRecipe["Lemons"] = lemonsPerPitcher;
            currentRecipe["Sugar"] = sugarCupsPerPitcher;
            currentRecipe["Ice"] = iceCubesPerCup;
        }
        


        // calculate # of cups per pitcher based on ice 
        // cupsperpitcher 


    }
}
