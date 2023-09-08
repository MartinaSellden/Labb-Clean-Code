using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public class Game
    {
        private IGameType gameType;
        private IUI ui;
        private GameController gameController;
        private GameScore gameScore;
        private IDataHandler fileHandler;

        public Game(IUI ui, GameController gameController, GameScore gameScore, IDataHandler fileHandler)
        {
            this.ui = ui;
            this.gameController = gameController;
            this.gameScore = gameScore;
            this.fileHandler = fileHandler;
        }
        public int GenerateGoalNumber(IGoalGenerator goalGenerator)
        {
            return gameType.GenerateGoalNumber(goalGenerator);

        }

        public IGameType GetGameType()
        {
            DisplayMenu();
            int number = getUserInput();

            while (true)
            {
                switch (number)
                {
                    case 1:
                        this.gameType =  new MooGame(ui, this, gameController, gameScore, fileHandler);
                        break;
                    case 2:
                        this.gameType = new GuessNumberGame(ui, this, gameController, gameScore, fileHandler);
                        break;
                    default:
                        ui.PutString("Invalid input");
                        GetGameType();
                        break;
                }
                return gameType;
            }
        }

        void DisplayMenu()
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
                string inputString = ui.GetString().Trim();

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
