using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public class Inventory
    {

        // SOLID:: I felt that I used the Open/Closed Principle here in the inventory as well as the Store and Recipe Classes by using Dictionaries.  
        // I think this qualifies because the use of Dictionaries here and how the Display methods in the User Interface class are set-up would make it
        // relatively easy to add new items. I also did not use a value as a setter in the dictionary property, which felt to me like it closed it off to
        // undesired modification. 



        private int cupsInventory;
        private int lemonsInventory;
        private int sugarInventory;
        private int iceInventory;
        private int preparedCups;

        private Dictionary<string, int> currentInventory = new Dictionary<string, int>(){
            {"Cups", 0 },
            { "Lemons", 0},
            {"Sugar", 0 },
            {"Ice", 0 }
        };

        public int LemonsInventory
        {
            get
            {
                return lemonsInventory;
            }
            set
            {
                lemonsInventory = value;
            }
        }
        public int SugarInventory
        {
            get
            {
                return sugarInventory;
            }
            set
            {
                sugarInventory = value;
            }
        }
        public int IceInventory {
            get { return iceInventory; }
            set { iceInventory = value; }
        }
        public int CupsInventory {
            get { return cupsInventory; }
            set { cupsInventory = value; }
        }
        public int PreparedCups { get => preparedCups; set => preparedCups = value; }
        public Dictionary<string, int> CurrentInventory
        {
            get
            {
                return currentInventory;
            }
            set
            {
                currentInventory["Cups"] = CupsInventory;
                currentInventory["Lemons"] = LemonsInventory;
                currentInventory["Sugar"] = SugarInventory;
                currentInventory["Ice"] = IceInventory;
            }
        }



        public void AddInventory(string product, int quantity)
        {
            product = UserInterface.UpperFirstLetter(product);
            if(currentInventory.ContainsKey(product))
            {
                currentInventory[product] = currentInventory[product] + quantity;
            }
            else
            {
                UserInterface.DisplayMessage("ERROR: product given does not match any product keys.");
            }
        }
        public void ReduceInventory(string product, int quantity)
        {
            product = UserInterface.UpperFirstLetter(product);
            if (currentInventory.ContainsKey(product))
            {
                currentInventory[product] = currentInventory[product] - quantity;
            }
            else
            {
                UserInterface.DisplayMessage("ERROR: product given does not match any product keys.");
            }

        }
        public void MakePitcher(Recipe recipe, Day day)
        {
            if (CurrentInventory["Lemons"] >= recipe.currentRecipe["Lemons"] 
                & CurrentInventory["Sugar"] >= recipe.currentRecipe["Sugar"] 
                & CurrentInventory["Ice"] >= recipe.currentRecipe["Ice"])
            {
                CurrentInventory["Lemons"] = CurrentInventory["Lemons"] - recipe.currentRecipe["Lemons"];
                CurrentInventory["Sugar"] = CurrentInventory["Sugar"] - recipe.currentRecipe["Sugar"];
                CurrentInventory["Ice"] = CurrentInventory["Ice"] - recipe.currentRecipe["Ice"];
                PreparedCups = recipe.CupsPerPitcher;
            }
            else
            {
                UserInterface.DisplayMessage("You've Sold Out!");
                day.EndDay();
            }
        }
        public void SellCup(Recipe recipe, Day day)
        {
            PreparedCups = PreparedCups - 1;
            if(PreparedCups == 0)
            {
                MakePitcher(recipe, day);
            }
            else
            {
                return;
            }
        }

    }
}
