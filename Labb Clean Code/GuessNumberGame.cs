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
        private GameScore gameScore;

        public GuessNumberGame(IUI ui, Game game, GameScore gameScore)
        {
            this.ui=ui;
            this.game=game;
            this.gameScore=gameScore;
        }

        public string CheckGuess(string correctNumber, string guess)  //dubbelkolla input
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

        public string GenerateNumber()
        {
            Random randomGenerator = new Random();
            int generatedNumber = randomGenerator.Next(0, 101);
            return generatedNumber.ToString();
        }

        public void PlayGame()
        {
            string answer = "";
            ui.PutString("Enter your user name:\n");

            string playerName = ui.GetString();
            string generatedNumber = game.GenerateNumber();

            ui.PutString("Guess the number (between 1 and 100)\n");
            ui.PutString("For practice the number is:" + generatedNumber);

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
            gameScore.SaveScore(playerName, numberOfGuesses);
            gameScore.DisplayScore();
            ui.PutString("It took " + numberOfGuesses + " guesses\nContinue?");
            
            answer = ui.GetString();

            if (PlayAgain(answer))
            {
                game.PlayGame(game);
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
    }
}
