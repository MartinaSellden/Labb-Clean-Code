using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    public class MooGame : IGameType
    {
        private IUI ui;
        private Game game;
        private GameController gameController;
        private GameScore gameScore;
        private IDataHandler fileHandler;
        private List<Player> players;


        public MooGame(IUI ui, Game game, GameController gameController, GameScore gameScore, IDataHandler fileHandler)
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

            IGoalGenerator goalGenerator = new MooGoalGenerator();
            int goalNumber = gameController.GenerateGoalNumber(goalGenerator);

            if (IsPracticeSession())
            {
                DisplayGoalNumber(goalNumber);
            }

            ui.PutString("New game:\n");

            int numberOfGuesses = GetNumberOfGuesses(goalNumber);

            string fileName = "MooGame.txt";

            players = fileHandler.RetrieveData(fileName);

            UpdatePlayer(player, numberOfGuesses);

            fileHandler.SaveData(fileName, players);
            gameScore.DisplayScore(fileName, players);

            string message = numberOfGuesses > 1 ? "Correct, it took " + numberOfGuesses + " guesses.\nContinue y/n?" : "Correct, it took " + numberOfGuesses + " guess.\nContinue y/n?";

            ui.PutString(message);

            string answer = ui.GetString();

            if (PlayAgain(answer))
            {
                gameController.PlayAgain(game, player);
            }

            ui.Exit();
        }
        public int GenerateGoalNumber(IGoalGenerator mooGoalGenerator)
        {
            return mooGoalGenerator.GetGoal();
        }
        string CheckGuess(int goalNumber, int guessedNumber)
        {
            string goal = goalNumber.ToString();
            string guess = guessedNumber.ToString();

            int cows = 0, bulls = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
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

            string progress = CheckGuess(goalNumber, guess);
            ui.PutString(progress + "\n");
            while (progress != "BBBB,")
            {
                numberOfGuesses++;
                guess = GetUserGuess();
                ui.PutString(guess + "\n");
                progress = CheckGuess(goalNumber, guess);
                ui.PutString(progress + "\n");
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
                ui.PutString("Please enter a four digit number:");
                string inputString = ui.GetString().Trim();

                if (inputString.Length == 4 && int.TryParse(inputString, out userInput))
                {
                    isValidInput = true;
                }
                else
                {
                    ui.PutString("Invalid input.");
                }
            } while (!isValidInput);

            return userInput;
        }
        void DisplayGoalNumber(int goalNumber)  
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
