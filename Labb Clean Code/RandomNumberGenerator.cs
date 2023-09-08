using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    internal class RandomNumberGenerator: IRandomNumberGenerator
    {
        private readonly Random random;

        public RandomNumberGenerator()
        {
            random = new Random();
        }

        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }
        public int Next(int minValue,int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        public int Next()
        {
            return random.Next();
        }

    }
}
