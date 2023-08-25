using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    internal class MooGame : IGameType
    {
        private IUI ui;
        private Game game;
        private GameScore gameScore;

        public MooGame(IUI ui, Game game, GameScore gameScore)
        {
            this.ui=ui;
            this.game=game;
            this.gameScore=gameScore;
        }

        public string CheckGuess(string correctNumber, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars     ska det här verkligen behöva vara med?
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (correctNumber[i] == guess[j])
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

        public void PlayGame()
        {
            string answer = "";
            do
            {
                ui.PutString("Enter your user name:\n");

                string playerName = ui.GetString();
                string generatedNumber = game.GenerateNumber(); //borde generera en int och felhantera kring det? 

                ui.PutString("New game:\n");
                //comment out or remove next line to play real games!
                ui.PutString("For practice, number is: " + generatedNumber + "\n");

                string guess = ui.GetString();

                int numberOfGuesses = 1;

                string progress = CheckGuess(generatedNumber, guess);
                ui.PutString(progress + "\n");
                while (progress != "BBBB,")
                {
                    numberOfGuesses++;
                    guess = ui.GetString();
                    ui.PutString(guess + "\n");
                    progress = CheckGuess(generatedNumber, guess);
                    ui.PutString(progress + "\n");
                }
                gameScore.SaveScore(playerName, numberOfGuesses); //ska den vara i game-klassen? Eller i controller?
                gameScore.DisplayScore();
                ui.PutString("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
                answer = ui.GetString();
            } while (answer != null && answer != "" && answer.Substring(0, 1) != "n");
        }

        public string GenerateNumber()
        {
            Random randomGenerator = new Random();

            string generatedNumber = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (generatedNumber.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                generatedNumber = generatedNumber + randomDigit;
            }
            return generatedNumber;
        }
    }
}
