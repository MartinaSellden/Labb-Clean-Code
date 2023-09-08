using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code.Tests
{
    internal class MockRandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly int mockNumber;

        public MockRandomNumberGenerator(int mockNumber)
        {
            this.mockNumber = mockNumber;
        }
        public int Next(int minValue, int maxValue)
        {
            return mockNumber;
        }

        public int Next(int maxValue)
        {
            return mockNumber;
        }

        public int Next()
        {
            return mockNumber;
        }
        
    }
}
