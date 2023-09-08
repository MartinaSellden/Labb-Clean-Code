using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    public class GuessNumberGame : IGameType
    {
        private IUI ui;
        private Game game;
        private GameController gameController;
        private GameScore gameScore;
        private IDataHandler fileHandler;
        private List<Player> players;

        public GuessNumberGame(IUI ui, Game game, GameController gameController, GameScore gameScore, IDataHandler fileHandler)
        {
            this.ui = ui;
            this.game = game;
            this.gameController = gameController;
            this.gameScore = gameScore;
            this.fileHandler = fileHandler;
        }
        public void PlayGame(Player player)
        {
            player.NumberOfGames = 0;

            IGoalGenerator goalGenerator = new GuessNumberGoalGenerator();
            int goalNumber = gameController.GenerateGoalNumber(goalGenerator);

            if (IsPracticeSession())
            {
                DisplayGoalNumber(goalNumber);
            }

            ui.PutString("Guess the number (between 1 and 100)\n");

            int numberOfGuesses = GetNumberOfGuesses(goalNumber);

            string fileName = "GuessNumberGame.txt";

            players = fileHandler.RetrieveData(fileName);

            UpdatePlayer(player, numberOfGuesses);

            fileHandler.SaveData(fileName, players);
            gameScore.DisplayScore(fileName, players);

            string message = numberOfGuesses > 1 ? "Well played, " + player.Name + "! It took " + numberOfGuesses + " guesses\nContinue y/n? " : "Well played, " + player.Name + "! It took " + numberOfGuesses + " guess\nContinue y/n?";

            ui.PutString(message);

            string answer = ui.GetString();
            if (PlayAgain(answer))
            {
                gameController.PlayAgain(game, player);
            }

            ui.Exit();
        }
        public int GenerateGoalNumber(IGoalGenerator goalNumberGenerator)
        {
            return goalNumberGenerator.GetGoal();
        }
        public string CheckGuess(int goalNumber, int guessedNumber)
        {

            while (goalNumber != guessedNumber)
            {
                if (goalNumber > guessedNumber)
                {
                    return "Too low, try again:\n";
                }
                if (goalNumber < guessedNumber)
                {
                    return "Too high, try again:\n";
                }
            }
            return "Correct!";
        }
        bool PlayAgain(string answer)
        {
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }
            return true;

        }
        bool PlayerExists(List<Player> players, Player player)
        {
            return players.Any(p => p.Name == player.Name);
        }

        int GetNumberOfGuesses(int goalNumber)
        {
            int guess = GetUserGuess();

            int numberOfGuesses = 1;

            string hint = CheckGuess(goalNumber, guess);

            while (hint != "Correct!")
            {
                ui.PutString("\n" + hint);
                numberOfGuesses++;
                guess = GetUserGuess();
                hint = CheckGuess(goalNumber, guess);
                ui.PutString("\n" + hint);
            }
            return numberOfGuesses;
        }
        void UpdatePlayer(Player player, int numberOfGuesses)
        {
            if (PlayerExists(players, player))
            {
                Player playerToUpdate = players.Find(p => p.Name == player.Name);
                if (playerToUpdate != null)
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

        int GetUserGuess()
        {
            int userInput = 0;
            bool isValidInput = false;

            do
            {
                ui.PutString("\nEnter a number between 1 and 100:");
                string inputString = ui.GetString().Trim();

                if (inputString.Length > 0 && inputString.Length < 4 && int.TryParse(inputString, out userInput))
                {
                    isValidInput = true;
                }
                else
                {
                    ui.PutString("\nInvalid input.");
                }
            } while (!isValidInput);

            return userInput;
        }

        void DisplayGoalNumber(int goalNumber)   // ska sådana här vara här? Ska de finnas i interfacet?
        {
            ui.PutString("For practice the number is:" + goalNumber);
        }
        bool IsPracticeSession()
        {
            ui.PutString("\nWould you like to practice ? y/n : ");
            string inputString = ui.GetString().Trim();

            if (inputString != null && inputString != "" && inputString.Substring(0, 1) != "n")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
