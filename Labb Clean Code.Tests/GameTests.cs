using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestGenerateRandomNumber()
        {
            IUI ui = new ConsoleIO();
            GameController gameController = new GameController(ui);
            IDataHandler fileHandler = new FileHandler();
            GameScore gameScore = new GameScore(ui);
            Game game = new Game(ui, gameController, gameScore, fileHandler);

            IRandomNumberGenerator randomNumberGenerator = new MockRandomNumberGenerator(1234);
            string generatedNumber = game.GenerateRandomNumber(randomNumberGenerator);

            Assert.AreEqual(1234, generatedNumber);
        }

        [TestMethod]
        public void TestGetGameType()
        {
        }

        [TestMethod]
        public void TestDisplayMenu()
        {
        }
    }
}