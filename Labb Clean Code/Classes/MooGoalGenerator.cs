using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    internal class MooGoalGenerator : IGoalGenerator
    {
        private readonly Random randomGoalNumber;

        public MooGoalGenerator()
        {
            randomGoalNumber = new Random();
        }
        public int GetGoal()
        {
            string generatedNumber = "";
            for (int i = 0; i < 4; i++)
            {
                string randomDigit = randomGoalNumber.Next(10).ToString();

                while (generatedNumber.Contains(randomDigit))
                {
                    randomDigit = randomGoalNumber.Next(10).ToString();
                }
                generatedNumber = generatedNumber + randomDigit;
            }
            return int.Parse(generatedNumber);
        }
    }
}
