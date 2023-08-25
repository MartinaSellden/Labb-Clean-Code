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
            Game game = new Game();
            GameScore gameScore = new GameScore(ui);
            IGameType gameType = new MooGame(ui, game, gameScore);
            game.SetGameType(gameType);
            GameController gameController = new GameController(game, ui, gameScore, gameType);
            gameController.PlayGame();
             
        }
    }
}
       