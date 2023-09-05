using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    internal class Game
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
        public string GenerateNumber()
        {
            return gameType.GenerateNumber();

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
            string choice = ui.GetString();
            while (choice == null || choice == "")
            {
                ui.PutString("Please enter a valid number\n 1. Moo Game \n2. Guess the Number Game");
            }
            bool success = int.TryParse(choice, out int number);
            if (success)
            {
                return number;
            }
            return -1;
        }

    }
}
