using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    public class GameController
    {
        private IUI ui;
        private IGameType gameType;

        public GameController(IUI ui)
        {
            this.ui=ui; 
        }
        public void SetGameType(IGameType gameType)
        {
            this.gameType = gameType;
        }
        public void CheckGuess(string correctNumber, string guess) 
        {
            gameType.CheckGuess(correctNumber, guess);
        }
        public string GenerateRandomNumber(IRandomNumberGenerator randomNumberGenerator)
        {
            return gameType.GenerateRandomNumber(randomNumberGenerator);
        }
        public void PlayGame(Game game)
        {
            string playerName = getPlayerName();
            Player player = new Player(playerName);

            SetGameType(game.GetGameType(game));

            gameType.PlayGame(player);
        }
        public void PlayAgain(Game game, Player player)
        {
            SetGameType(game.GetGameType(game));
            gameType.PlayGame(player);
        }
        
        string getPlayerName()
        {
            ui.PutString("Enter your user name:\n");
            return ui.GetString();
        }

    }

}
    

