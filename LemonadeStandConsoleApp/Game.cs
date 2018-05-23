using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Game
    {


        public static Player player = new Player();
        public static Recipe recipe = new Recipe();


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
            DisplayRecipe();
            DisplayInventory();
            AskGoToStore();



            // display inventory
            // ask if go to store
            // if yes, display inventory again and ask what to buy - list ingredients w/ int val, accept int AND string

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
            UserInterface.DisplayIntList(gameLengthOptions);
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
            DisplayInventory();
            DisplayTotalMoney();
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
            if(input == "No")
            {
                return;
            }
            else
            {
                UserInterface.DisplayMessage("Please try again, entering either Yes or No.");
                BuyNextSupply();

            }
        }

        //DISPLAYS - CURRENT STATUS
        public void DisplayInventory()
        {
            UserInterface.DisplayMessage("Your current Inventory is:");
            UserInterface.DisplayDictionary(Inventory.currentInventory);
        }
        public void DisplayTotalMoney()
        {
            UserInterface.DisplayMessage("Your current account balance is: $" + player.TotalMoney);
        }
        public void DisplayRecipe()
        {
            UserInterface.DisplayMessage("Your current Lemonade Recipe is:");
            UserInterface.DisplayDictionary(recipe.CurrentRecipe);
        }
    }
}
;