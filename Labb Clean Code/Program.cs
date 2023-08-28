using System;
using System.IO;
using System.Collections.Generic;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    class Program
    {

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            GameScore gameScore = new GameScore(ui);
            Game game = new Game(ui, gameScore);
            GameController gameController = new GameController(game);
            game.PlayGame(game);
             
        }
    }
}
       