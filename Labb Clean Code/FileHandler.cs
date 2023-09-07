using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public class FileHandler: IDataHandler
    {
        private List<Player> players = new List<Player>(); 

        public FileHandler() { }

        public List<Player> RetrieveData(string fileName) 
        {
            if (!File.Exists(fileName))
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.Close();
            }
            StreamReader dataFromFile = new StreamReader(fileName);

            players.Clear();

            string lineFromFile;
            while ((lineFromFile = dataFromFile.ReadLine()) != null)
            {
                string[] playerData = lineFromFile.Split("&");
                string name = playerData[0];
                int numberOfGames = int.Parse(playerData[1]);
                int totalGuesses = int.Parse(playerData[2]);
                double averageGuesses = double.Parse(playerData[3]);
                Player player = (new Player(name, numberOfGames, totalGuesses, averageGuesses));

                bool playerExists = players.Any(player => player.Name==name);
                if (!playerExists)
                {
                    players.Add(player);
                }
            
            }
            dataFromFile.Close();
            return players;

        }

        public void SaveData(string fileName, List<Player> players)
        {
            if (!File.Exists(fileName))
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.Close();
            }
            StreamWriter writeToFile = new StreamWriter(fileName, append: false);

            foreach(Player gamePlayer in players)    
            {
                writeToFile.WriteLine(gamePlayer.Name + "&"  + gamePlayer.NumberOfGames +"&"+ gamePlayer.TotalGuesses  + "&" + gamePlayer.AverageGuesses );
            }
            writeToFile.Close();
        }
    }
}
