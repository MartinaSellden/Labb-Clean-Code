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
    internal class MooGame : IGameType
    {
        private IUI ui;
        private Game game;
        private GameScore gameScore;
        private IDataHandler fileHandler;
        private List<Player> players;

        public MooGame(IUI ui, Game game, GameScore gameScore, IDataHandler fileHandler)
        {
            this.ui=ui;
            this.game=game;
            this.gameScore=gameScore;
            this.fileHandler=fileHandler;
        }

        public string CheckGuess(string correctNumber, string guess)              //dubbelkolla input
        {
            int cows = 0, bulls = 0;
            guess += "    ";                  // if player entered less than 4 chars     ska det här verkligen behöva vara med? Magisk sträng?
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

        public void PlayGame(Player player)
        {
            string generatedNumber = game.GenerateNumber(); 

            ui.PutString("New game:\n");
            //comment out or remove next line to play real games!
            ui.PutString("For practice, number is: " + generatedNumber + "\n");

            int numberOfGuesses = GetNumberOfGuesses(generatedNumber);

            string fileName = "MooGame.txt";

            players = fileHandler.RetrieveData(fileName);

            UpdatePlayer(player, numberOfGuesses);

            fileHandler.SaveData(fileName, players);
            players.Clear();                             //ska det vara med?
            gameScore.DisplayScore(fileName);
            ui.PutString("Correct, it took " + numberOfGuesses + " guesses\nContinue?");

            string answer = ui.GetString();

            if (PlayAgain(answer))
            {
                game.PlayAgain(game, player);
            }

            ui.Exit();
        }

        public string GenerateNumber()    //ändra denna?
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
            string guess = ui.GetString(); //bryt ut hela gissningsmetoden
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
