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
            IDataHandler fileHandler = new FileHandler();
            GameScore gameScore = new GameScore(ui, fileHandler);
            Game game = new Game(ui, gameScore, fileHandler);
            GameController gameController = new GameController(game);
            game.PlayGame(game);
             
        }
    }
}
       