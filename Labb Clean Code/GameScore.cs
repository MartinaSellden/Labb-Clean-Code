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
        public GameScore(IUI ui)
        {
            this.ui = ui;
        }
        public void SaveScore(string playerName, int numberOfGuesses)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(playerName + "#&#" + numberOfGuesses);
            output.Close();
        }
        public void DisplayScore()
        {
            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string lineFromFile;
            while ((lineFromFile = input.ReadLine()) != null)
            {
                string[] nameAndScore = lineFromFile.Split(new string[] { "#&#" }, StringSplitOptions.None); //kan man inte göra en dictionary här? Så man har key-value
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                //Dictionary<string, int> scores = new Dictionary<string, int>();  //om man har samma namn? Då skrivs den ju över. Kan man promta om nytt namn om det finns? Är det att lägga till funktionalitet?
                PlayerData playerData = new PlayerData(name, guesses);
                int indexOfPlayerData = results.IndexOf(playerData);
                if (indexOfPlayerData < 0)
                {
                    results.Add(playerData);
                }
                else
                {
                    results[indexOfPlayerData].Update(guesses);
                }
            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            ui.PutString("Player   games average");
            foreach (PlayerData p in results)
            {
                ui.PutString(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
            }
            input.Close();
        }

    }
}
