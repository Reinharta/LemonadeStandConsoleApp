using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Game
    {


        private Player player = new Player();
        private int gameLength;
        private List<int> gameLengthOptions = new List<int> { 7, 14, 21 };
        Recipe recipe = new Recipe();


        public int GameLength
        {
            get
            {
                return gameLength;
            }
            set
            {
                if (gameLengthOptions.Contains(value))
                {
                    gameLength = value;
                }
                else 
                {
                    UserInterface.DisplayMessage("You've entered an invalid number of days. Please try again.");
                    SetGameDays();
                }
            }
        }

        public void SetupGame()
        {
            DisplayIntructions();
            player.SetName();
            SetGameDays();
            DisplayRecipe();




        }

        public void DisplayIntructions()
        {
            StringBuilder instructions = new StringBuilder();
            instructions.AppendLine("Welcome to Lemonade Stand! Your goal in this game is to make as much");
            instructions.AppendLine("money as you can in 7, 14, or 21 days by selling lemonade at your stand.");
            instructions.AppendLine("You will need to buy supplies and set your recipe based on the weather");
            instructions.AppendLine("and the resulting demand. You may start with the basic recipe, but try");
            instructions.AppendLine("to see if you can do better with your own. You will then need to set your");
            instructions.AppendLine("price based on the weather.  The weather will be an important tool for");
            instructions.AppendLine("proper planning.");
            UserInterface.DisplayMessage(instructions.ToString());

        }
        public void SetGameDays()
        {
            UserInterface.DisplayMessage("\nHow many days would you like your Lemonade Stand to be open? Please choose from: ");
            UserInterface.DisplayIntList(gameLengthOptions);
            string input = UserInterface.GetUserInput();
            int parsedInput;
            Int32.TryParse(input, out parsedInput);
            GameLength = parsedInput;
            /////input comes in as string, set to in var. Characters cannot convert to int -- need to handle this exception. "try" "exception"?
        }

        public void DisplayRecipe()
        {
            UserInterface.DisplayMessage("\nYour current Lemonade Recipe is:");
            UserInterface.DisplayDictionary(recipe.currentRecipe);
        }
        public void AskChangeRecipe()
        {
            UserInterface.DisplayMessage("\nWould you like to change your recipe?");
            string input = UserInterface.GetUserInput().ToLower();
            if(input == "no")
            {
                return;
            }
            if(input == "yes")
            {
                ChangeRecipe();
            }
        }
        public void ChangeRecipe()
        {

        }

        public void DisplayInventory()
        {

        }
        public void DisplayTotalMoney()
        {

        }
    }
}
;