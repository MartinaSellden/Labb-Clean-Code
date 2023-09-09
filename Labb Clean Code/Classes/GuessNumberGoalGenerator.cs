using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    internal class GuessNumberGoalGenerator : IGoalGenerator
    {
        private Random random = new Random();
        public int GetGoal()
        {
            return random.Next(1, 101);
        }
    }
}
