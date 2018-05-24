using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Game
    {


        public Player player = new Player();
        public Recipe recipe = new Recipe();


        private int gameLength;
        private List<int> gameLengthOptions = new List<int> { 7, 14, 21 };


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
            UserInterface.DisplayRecipe();
            UserInterface.DisplayInventory();
            AskGoToStore();
            UserInterface.DisplayRecipe();
            AskChangeRecipe();
            UserInterface.DisplayCurrentStatus();
            UserInterface.MainMenu();





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

        //GAME LENGTH
        public void SetGameDays()
        {
            UserInterface.DisplayMessage("How many days would you like your Lemonade Stand to be open? Please choose from: ");
            UserInterface.DisplayList(gameLengthOptions);
            string input = UserInterface.GetUserInput();
            int parsedInput;
            Int32.TryParse(input, out parsedInput);
            GameLength = parsedInput;
        }


        //RECIPE
        public void AskChangeRecipe()
        {
            UserInterface.DisplayMessage("Would you like to change your recipe?");
            string input = UserInterface.GetUserInput().ToLower();
            input = UserInterface.UpperFirstLetter(input);
            if(input == "No")
            {
                return;
            }
            if(input == "Yes")
            {
                recipe.ChangeRecipeMenu();
            }
            else
            {
                UserInterface.DisplayMessage("Invalid input. Please try again.");
                AskChangeRecipe();
            }
        }




        // STORE
        public void AskGoToStore()
        {
            UserInterface.DisplayMessage("Would you like to purchase any supplies from the store?");
            string input = UserInterface.GetUserInput().ToLower();
            if (input == "yes")
            {
                GoToStore();
            }
            if (input == "no")
            {
                return;
            }
            else{
                UserInterface.DisplayMessage("Please try again, entering either Yes or No.");
                AskGoToStore();
            }
        }
        public void GoToStore()
        {
            Store.StoreMenu();
            UserInterface.DisplayInventory();
            UserInterface.DisplayTotalMoney();
            BuyNextSupply();
        }
        public void BuyNextSupply() { 
            UserInterface.DisplayMessage("Would you like to purchase more supplies?");
            string input = UserInterface.GetUserInput();
            input = UserInterface.UpperFirstLetter(input);
            if(input == "Yes")
            {
                GoToStore();
            }
            if(input == "No" || input == "no")
            {
                return;
            }
            else
            {
                UserInterface.DisplayMessage("Please try again, entering either Yes or No.");
                BuyNextSupply();

            }
        }


    }
}
;