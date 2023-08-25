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
        private IUI ui;
        private GameScore gameScore;
        private IGameType gameType;

        public GameController(Game game, IUI ui, GameScore gameScore, IGameType gameType)
        {
            this.game = game;
            this.ui = ui;
            this.gameScore = gameScore;
            this.gameType=gameType;
        }

        public void PlayGame()
        {
            gameType.PlayGame();
        }

        public void CheckGuess(string correctNumber, string guess)  //borde dubbelkolla att vi tar in ett nummer etc
        {
            gameType.CheckGuess(correctNumber, guess);
        }
        public string GenerateNumber()
        {
            return gameType.GenerateNumber();
        }

    }

}
    

