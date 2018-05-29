using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    public class Game
    {


        public Player player = new Player();
        public Recipe recipe = new Recipe();


        private int gameLength;
        private int dayCount;
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
        public int DayCount
        {
            get
            {
                return dayCount;
            }
            set
            {
                dayCount = value;
            }
        }

        public void SetupGame()
        {
            DisplayIntructions();
            player.SetName();
            SetGameDays();
            UserInterface.DisplayRecipe(player);
            GoToStore();
            UserInterface.DisplayRecipe(player);
            AskChangeRecipe();
            RunGame();

        }

        public void RunGame()
        {
            CreateDay();
            if (DayCount == GameLength)
            {
                EndGame();
            }
            if (DayCount < GameLength)
            {
                CreateDay();

            }
        }


        public void CreateDay()
        {
            DayCount = DayCount + 1;
            if (DayCount == 1)
            {
                Day day = new Day(player);
                day.CreateFirstDay(player, GameLength, DayCount);
                RunMainMenu(day);
                

            }
            if (DayCount > 1 & DayCount <= GameLength)
            {
                Day day = new Day(player);
                day.CreateDay(player, GameLength, DayCount);
                RunMainMenu(day);

            }
            else
            {
                EndGame();
            }

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

        public void RunMainMenu(Day today)
        {
            string input = UserInterface.MainMenu();
            if (input == "1")
            {
                UserInterface.DisplayCurrentStatus(player, today);
                RunMainMenu(today);
            }
            if (input == "2")
            {
                Store.StoreMenu(player);
                RunMainMenu(today);
            }
            if (input == "3")
            {
                recipe.ChangeRecipeMenu();
                RunMainMenu(today);
            }
            if (input == "4")
            {
                today.weather.DisplayTodaysWeather(); 
            }
            if (input == "5")
            {
                today.weather.DisplayWeatherPrediction();
            }
            if (input == "6")
            {
                RunGame();
            }
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
            input = UserInterface.UpperFirstLetter(input);
            switch (input)
            {
                case "No":
                    {
                        break;
                    }
                case "Yes":
                    {
                        recipe.ChangeRecipeMenu();
                        break;
                    }
                default:
                    {
                        UserInterface.DisplayMessage("Invalid input. Please try again.");
                        AskChangeRecipe();
                        break;
                    }
            }
        }




        // STORE
        public void GoToStore()
        {
            UserInterface.DisplayInventory(player);
            UserInterface.DisplayTotalMoney(player);
            UserInterface.DisplayMessage("Would you like to purchase supplies?");
            string input = UserInterface.GetUserInput();
            input = UserInterface.UpperFirstLetter(input);
            switch (input)
            {
                case "Yes":
                    {
                        Store.StoreMenu(player);
                        GoToStore();
                        break;
                    }
                case "No":
                    {
                        break;
                    }
                default:
                    {
                        UserInterface.DisplayMessage("Please try again, entering either Yes or No.");
                        GoToStore();
                        break;
                    }
            }
        }

        public void EndGame()
        {

        }

    }
}
;