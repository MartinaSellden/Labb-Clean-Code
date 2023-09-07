using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    public class Game
    {
        IGameType gameType;
        private IUI ui;
        private GameController gameController;
        private GameScore gameScore;
        private IDataHandler fileHandler;
        private List<Player> players = new List<Player>();

        public Game(IUI ui, GameController gameController, GameScore gameScore, IDataHandler fileHandler)
        {
            this.ui = ui;
            this.gameController = gameController;
            this.gameScore = gameScore;
            this.fileHandler = fileHandler;
        }
        public string GenerateRandomNumber(IRandomNumberGenerator randomNumberGenerator)
        {
            return gameType.GenerateRandomNumber(randomNumberGenerator);

        }
        private void setGameType(IGameType gameType)
        {
            this.gameType = gameType;
        }
        public IGameType GetGameType(Game game)
        {
            DisplayMenu();
            int number = getUserInput();

            while (true)
            {
                switch (number)
                {
                    case 1:
                        setGameType(new MooGame(this.ui, game, this.gameController, this.gameScore, this.fileHandler));
                        break;
                    case 2:
                        setGameType(new GuessNumberGame(this.ui, game, this.gameController, this.gameScore, this.fileHandler));
                        break;
                    default:
                        ui.PutString("Invalid input");
                        GetGameType(game);
                        break;
                }
                return gameType; 
            }
        }

        public void DisplayMenu()
        {
            ui.PutString("Choose a game:\n");
            ui.PutString("1. Moo Game \n2. Guess the Number Game");
        }

        int getUserInput()
        {
            int userInput = 0;
            bool isValidInput = false;

            do
            {
                ui.PutString("\nPlease enter the number corresponding to the game you wish to play:");
                string inputString = ui.GetString();

                if (inputString.Length == 1 && int.TryParse(inputString, out userInput))
                {
                    isValidInput = true;
                }
                else
                {
                    ui.PutString("Invalid input.");
                    DisplayMenu();
                }
            } while (!isValidInput);

            return userInput;
        }
    }
}
