using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    internal class GameController
    {
        private Game game;
        private IGameType gameType;

        public GameController(Game game)
        {
            this.game = game;
        }

        public void SetGameType(IGameType gameType)
        {
            this.gameType = gameType;
        }

        public void CheckGuess(string correctNumber, string guess) 
        {
            gameType.CheckGuess(correctNumber, guess);
        }
        public string GenerateNumber()
        {
            return gameType.GenerateNumber();
        }
        

    }

}
    

