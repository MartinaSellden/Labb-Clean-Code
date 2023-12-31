﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Labb_Clean_Code
{
    class Program
    {

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            IDataHandler fileHandler = new FileHandler();
            GameScore gameScore = new GameScore(ui);
            GameController gameController = new GameController(ui);
            Game game = new Game(ui, gameController, gameScore, fileHandler);
            gameController.PlayGame(game);

        }
    }
}
