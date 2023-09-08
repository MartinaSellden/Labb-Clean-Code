using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code.Tests
{

    [TestClass]
    public class GuessRandomNumberTests
    {
        [TestMethod]
        public void TestGenerateRandomNumber()
        {
            IRandomNumberGenerator mockRandomGenerator = new MockRandomNumberGenerator(1234);

            var generatedNumber = mockRandomGenerator.Next();
            Assert.AreEqual(1234, generatedNumber);
        }
    }
}
