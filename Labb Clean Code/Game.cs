using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    internal class Game
    {
        public string GenerateNumber()
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
    }
}
