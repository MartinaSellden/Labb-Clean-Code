using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code.Tests
{
    [TestClass]
    public class MooGameTests
    {
        [TestMethod]
        public void TestGenerateGoalNumber() //kolla 
        {
            IGoalGenerator mockGoalGenerator = new MockGoalGenerator(1234);

            var generatedNumber = mockGoalGenerator.GetGoal();
            Assert.AreEqual(1234, generatedNumber);
        }
    }
}
