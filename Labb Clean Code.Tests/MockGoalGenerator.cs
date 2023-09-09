using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code.Tests
{
    internal class MockGoalGenerator : IGoalGenerator
    {
        private readonly int mockNumber;

        public MockGoalGenerator(int mockNumber)
        {
            this.mockNumber = mockNumber;
        }
        public int GetGoal()
        {
            return this.mockNumber;
        }
        
    }
}
