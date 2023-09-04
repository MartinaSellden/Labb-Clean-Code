using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    internal class GameScore
    {
        private IUI ui;
        private IDataHandler fileHandler;

        public GameScore(IUI ui, IDataHandler fileHandler)
        {
            this.ui = ui;
            this.fileHandler = fileHandler;
        }
        public void DisplayScore(string fileName)
        {
            
            List<Player> players = fileHandler.RetrieveData(fileName);

            List<Player> playersOrderedByAverageGuesses = players.OrderBy(player => player.AverageGuesses).ToList();
            ui.PutString("Player   games average");

            foreach (Player player in playersOrderedByAverageGuesses)
            {
                ui.PutString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.AverageGuesses));
            }    
        }
    }
}
