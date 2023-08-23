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

        public GameController(Game game, IUI ui)
        {
            this.game = game;
            this.ui = ui;
        }

        public void Run()
        {
            bool playOn = true;
            ui.PutString("Enter your user name:\n");
            string playerName = ui.GetString();

            while (playOn)
            {
                string generatedNumber = game.GenerateNumber();

                //display method
                ui.PutString("New game:\n");
                //comment out or remove next line to play real games!
                ui.PutString("For practice, number is: " + generatedNumber + "\n");
                string guess = ui.GetString();

                int numberOfGuesses = 1;

                //handle method
                string bbcc = checkBC(generatedNumber, guess);
                ui.PutString(bbcc + "\n");
                while (bbcc != "BBBB,")
                {
                    numberOfGuesses++;
                    guess = ui.GetString();
                    ui.PutString(guess + "\n");
                    bbcc = checkBC(generatedNumber, guess);
                    ui.PutString(bbcc + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + numberOfGuesses);
                output.Close();
                showTopList();
                ui.PutString("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
                string answer = ui.GetString();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }

            static string checkBC(string goal, string guess)
            {
                int cows = 0, bulls = 0;
                guess += "    ";     // if player entered less than 4 chars
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


            void showTopList()
            {
                StreamReader input = new StreamReader("result.txt");
                List<PlayerData> results = new List<PlayerData>();
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                    string name = nameAndScore[0];
                    int guesses = Convert.ToInt32(nameAndScore[1]);
                    PlayerData pd = new PlayerData(name, guesses);
                    int pos = results.IndexOf(pd);
                    if (pos < 0)
                    {
                        results.Add(pd);
                    }
                    else
                    {
                        results[pos].Update(guesses);
                    }


                }
                results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
                ui.PutString("Player   games average");
                foreach (PlayerData p in results)
                {
                    ui.PutString(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
                }
                input.Close();
            }
        }

        class PlayerData
        {
            public string Name { get; private set; }
            public int NGames { get; private set; }
            int totalGuess;


            public PlayerData(string name, int guesses)
            {
                this.Name = name;
                NGames = 1;
                totalGuess = guesses;
            }

            public void Update(int guesses)
            {
                totalGuess += guesses;
                NGames++;
            }

            public double Average()
            {
                return (double)totalGuess / NGames;
            }


            public override bool Equals(Object p)
            {
                return Name.Equals(((PlayerData)p).Name);
            }


            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }
    }

}
    

