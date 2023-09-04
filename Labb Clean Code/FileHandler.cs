using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    internal class FileHandler: IDataHandler
    {
        private List<Player> players = new List<Player>();
        public FileHandler() { }

        public List<Player> RetrieveData(string fileName) //göra till List<Player>? 
        {
            if (!File.Exists(fileName))
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.Close();
            }
            StreamReader dataFromFile = new StreamReader(fileName);

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
                //{
                //    Player playerToUpdate = players.Find(player => player.Name == name);
                //    if (playerToUpdate!=null)
                //    {
                //        playerToUpdate.Update(totalGuesses);
                //    }
                //}
                //else
                //{
                    players.Add(player);
                //}         
            }
            dataFromFile.Close();
            return players;

        }

        public void SaveData(string fileName, Player player)
        {
            if (!File.Exists(fileName))
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.Close();
            }
            StreamWriter writeToFile = new StreamWriter(fileName, append: false);
           // player.Update();

            foreach(Player gamePlayer in players)
            {
                writeToFile.WriteLine(gamePlayer.Name + "&"  + gamePlayer.NumberOfGames +"&"+ gamePlayer.TotalGuesses  + "&" + gamePlayer.AverageGuesses );
            }
            writeToFile.Close();
        }
    }
}
