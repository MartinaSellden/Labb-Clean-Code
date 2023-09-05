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
        private GameScore gameScore;
        private IDataHandler fileHandler;
        private List<Player> players = new List<Player>();

        public Game(IUI ui, GameScore gameScore, IDataHandler fileHandler)
        {
            this.ui = ui;
            this.gameScore = gameScore;
            this.fileHandler = fileHandler;
        }
        public Game(IGameType gameType)
        {
            this.gameType = gameType;
        }

        public void PlayGame(Game game)
        {
            string playerName = getPlayerName();
            Player player = new Player(playerName);

            SetGameType(GetGameType(game));

            gameType.PlayGame(player);
        }
        public void PlayAgain(Game game, Player player)
        {
            SetGameType(GetGameType(game));
            gameType.PlayGame(player);
        }

        public void SetGameType(IGameType gameType)
        {
            this.gameType = gameType;
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

            //while true
            if (number>=1)
                switch (number)
                {
                    case 1:
                        setGameType(new MooGame(this.ui, game, this.gameScore, this.fileHandler));
                        return gameType;
                    case 2:
                        setGameType(new GuessNumberGame(this.ui, game, this.gameScore, this.fileHandler));
                        return gameType;
                }
            return null; // fixa!!
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

        string getPlayerName()
        {
            ui.PutString("Enter your user name:\n");
            return ui.GetString();
        }

    }
}
