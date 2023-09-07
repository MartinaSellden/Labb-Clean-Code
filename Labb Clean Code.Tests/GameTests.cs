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
        private Game game;

        [TestInitialize]
        public void TestInitialize()
        {
            IUI ui = new ConsoleIO();
            GameController gameController = new GameController(ui);
            IDataHandler fileHandler = new FileHandler();
            GameScore gameScore = new GameScore(ui);
            game = new Game(ui, gameController, gameScore, fileHandler);
        }

        [TestMethod]
        public void TestGenerateRandomNumber()
        {  
            IRandomNumberGenerator randomNumberGenerator = new MockRandomNumberGenerator(1234);
            var generatedNumber = game.GenerateRandomNumber(randomNumberGenerator);

            Assert.AreEqual("1234", generatedNumber);
        }

        [TestMethod]
        public void TestGetGameType_ChooseMooGame()
        {
            var mockUI = new MockUI();
            GameController gameController = new GameController(mockUI);
            IDataHandler fileHandler = new FileHandler();
            GameScore gameScore = new GameScore(mockUI);
            game = new Game(mockUI, gameController, gameScore, fileHandler);

            mockUI.PutString("Choose a game type: 1 for MooGame, 2 for GuessNumberGame");
            mockUI.SetStringInput("1"); 
            IGameType gameType = game.GetGameType(game);
            Assert.IsInstanceOfType(gameType, typeof(MooGame));

        }

        [TestMethod]
        public void TestGetGameType_ChooseGuessNumberGame()
        {
            var mockUI = new MockUI();
            GameController gameController = new GameController(mockUI);
            IDataHandler fileHandler = new FileHandler();
            GameScore gameScore = new GameScore(mockUI);
            game = new Game(mockUI, gameController, gameScore, fileHandler);

            mockUI.PutString("Choose a game type: 1 for MooGame, 2 for GuessNumberGame");
            mockUI.SetStringInput("2"); 

            IGameType gameType = game.GetGameType(game);
            Assert.IsInstanceOfType(gameType, typeof(GuessNumberGame));

        }

        [TestMethod]
        public void TestDisplayMenu()
        {
        }
    }
}