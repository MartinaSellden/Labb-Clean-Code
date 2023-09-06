using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public interface IGameType
    {
        void PlayGame(Player player);
        string CheckGuess(string correctNumber, string guess);
        string GenerateRandomNumber(IRandomNumberGenerator randomGenerator);
        bool PlayAgain(string userAnswer);
        bool PlayerExists(List<Player> players, Player player);
        int GetNumberOfGuesses(string generatedNumber);
        void UpdatePlayer(Player player, int numberOfGuesses);
    }
}
