﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    internal class GameController
    {
        private Game game;
        private IUI ui;
        private GameScore gameScore;

        public GameController(Game game, IUI ui, GameScore gameScore)
        {
            this.game = game;
            this.ui = ui;
            this.gameScore = gameScore;
        }

        public void Run()
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
            //ui.Exit();   ?
        }

        static string CheckGuess(string correctNumber, string guess)  //borde dubbelkolla att vi tar in ett nummer etc
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
        //static string ShowProgress()
        //{

        //}

    }

}
    

