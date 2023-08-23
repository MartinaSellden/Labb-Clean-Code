using System;
using System.IO;
using System.Collections.Generic;
using Labb_Clean_Code;

namespace MooGame
{
    class Program
    {

        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            Game game = new Game();
            GameController gameController = new GameController(game, ui);
            gameController.Run();
        }
    }
}
       