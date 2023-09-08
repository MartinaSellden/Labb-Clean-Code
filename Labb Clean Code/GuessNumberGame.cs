using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    internal class GuessNumberGame : IGameType
    {
        private IUI ui;
        private Game game;
        private GameController gameController;
        private GameScore gameScore;
        private IDataHandler fileHandler;
        private List<Player> players;

        public GuessNumberGame(IUI ui, Game game, GameController gameController, GameScore gameScore, IDataHandler fileHandler)
        {
            this.ui=ui;
            this.game=game;
            this.gameController=gameController;
            this.gameScore=gameScore;
            this.fileHandler=fileHandler;
        }

        public string CheckGuess(string correctNumber, string guess)  //dubbelkolla input. Ta in int här
        {
            int numberToGuess = int.Parse(correctNumber);
            int playerGuess = int.Parse(guess);
            while (numberToGuess != playerGuess)
            {
                if (numberToGuess > playerGuess)
                {
                    return "Too low!\n";
                }
                if (numberToGuess < playerGuess)
                {
                    return "Too high!\n";
                }
            }
            return "Correct!";
        }

        public string GenerateRandomNumber(IRandomNumberGenerator randomGenerator)
        {
            int generatedNumber = randomGenerator.Next(1, 101);  //kolla att det är rätt
            return generatedNumber.ToString();
        }

        public void PlayGame(Player player)
        {
            player.NumberOfGames=0;

            IRandomNumberGenerator random = new RandomNumberGenerator();
            string generatedNumber = gameController.GenerateRandomNumber(random);

            ui.PutString("Guess the number (between 1 and 100)\n");
            ui.PutString("For practice the number is:" + generatedNumber);

            int numberOfGuesses = GetNumberOfGuesses(generatedNumber);

            string fileName = "GuessNumberGame.txt";

            players = fileHandler.RetrieveData(fileName);

            UpdatePlayer(player, numberOfGuesses);

            fileHandler.SaveData(fileName, players);
            gameScore.DisplayScore(fileName, players);
            ui.PutString("Well played, " + player.Name + "! It took " + numberOfGuesses + " guesses\nContinue?");

            string answer = ui.GetString();

            if (PlayAgain(answer))
            {
                gameController.PlayAgain(game, player);
            }

            ui.Exit();
        }
        public bool PlayAgain(string answer)
        {
            if (answer != null && answer != "" && answer.Substring(0, 1)=="n")
            {
                return false;
            }
            return true;

        }
        public bool PlayerExists(List<Player> players, Player player)
        {
            return players.Any(p => p.Name==player.Name);
        }

        public int GetNumberOfGuesses(string generatedNumber)
        {
            string guess = ui.GetString();    

            int numberOfGuesses = 1;

            string hint = CheckGuess(generatedNumber, guess);
            if (hint!="Correct!")
            {
                ui.PutString(hint + "\n");
            }
            while (hint != "Correct!")
            {
                numberOfGuesses++;
                guess = ui.GetString();
                hint = CheckGuess(generatedNumber, guess);
                ui.PutString(hint + "\n");
            }
            return numberOfGuesses;
        }
        public void UpdatePlayer(Player player, int numberOfGuesses)
        {
            if (PlayerExists(players, player))
            {
                Player playerToUpdate = players.Find(p => p.Name == player.Name);
                if (playerToUpdate!=null)
                {
                    playerToUpdate.Update(numberOfGuesses);
                }
            }
            else
            {
                player.TotalGuesses = numberOfGuesses;
                player.Update();
                players.Add(player);
            }
        }
    }
}
