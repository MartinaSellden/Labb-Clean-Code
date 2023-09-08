using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public class Player
    {
        public string Name { get; private set; }
        public int NumberOfGames { get; set; }
        public int TotalGuesses { get; set; }
        public double AverageGuesses { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }
        public Player(string name, int guesses)
        {
            this.Name = name;
            this.TotalGuesses = guesses;
        }

        public Player(string name, int numberOfGames,int totalGuesses, double averageGuesses)
        {
            this.Name = name;
            this.NumberOfGames = numberOfGames;
            this.TotalGuesses += totalGuesses;
            this.AverageGuesses = averageGuesses;
        }

        public void Update(int numberOfGuesses)
        {
            TotalGuesses += numberOfGuesses;
            NumberOfGames++;
            AverageGuesses = (double) TotalGuesses / NumberOfGames;
           
        }
        public void Update()
        {
            NumberOfGames++;
            AverageGuesses = (double) TotalGuesses / NumberOfGames;
        }

    }
}
