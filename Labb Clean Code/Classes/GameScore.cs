using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    public class GameScore
    {
        private IUI ui;
        public GameScore(IUI ui)
        {
            this.ui = ui;
        }
        public void DisplayScore(string fileName, List<Player> players)
        {
            List<Player> playersOrderedByAverageGuesses = players.OrderBy(player => player.AverageGuesses).ToList();
            ui.PutString("Player   games average");

            foreach (Player player in playersOrderedByAverageGuesses)
            {
                ui.PutString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.AverageGuesses));
            }
        }
    }
}
