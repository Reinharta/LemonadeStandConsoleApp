using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game newGame = new Game();



            newGame.SetupGame();
            Console.ReadLine();
        }
    }
}
