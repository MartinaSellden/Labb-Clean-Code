using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public class GameController
    {
        private IUI ui;
        private IGameType gameType;

        public GameController(IUI ui)
        {
            this.ui = ui;
        }
        public void SetGameType(IGameType gameType)
        {
            this.gameType = gameType;
        }
        public void CheckGuess(int goalNumber, int guessedNumber)
        {
            gameType.CheckGuess(goalNumber, guessedNumber);
        }
        public int GenerateGoalNumber(IGoalGenerator goalGenerator)
        {
            return gameType.GenerateGoalNumber(goalGenerator);
        }
        public void PlayGame(Game game)
        {
            string playerName = getPlayerName();
            Player player = new Player(playerName);

            SetGameType(game.SetGameType());

            gameType.PlayGame(player);
        }
        public void PlayAgain(Game game, Player player)
        {
            SetGameType(game.SetGameType());
            gameType.PlayGame(player);
        }

        string getPlayerName()
        {
            ui.PutString("Enter your user name:\n");
            return ui.GetString();
        }

    }

}


