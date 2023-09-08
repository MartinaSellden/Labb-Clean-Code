using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;
using Labb_Clean_Code;
using Moq;

namespace Labb_Clean_Code.Tests
{
    [TestClass]
    public class GameTests
    {
        private Game game;
        private MockUI mockUI;

        [TestInitialize]
        public void TestInitialize()
        {
            mockUI = new MockUI();
            GameController gameController = new GameController(mockUI);
            IDataHandler fileHandler = new FileHandler();
            GameScore gameScore = new GameScore(mockUI);
            game = new Game(mockUI, gameController, gameScore, fileHandler);
        }

        [DataTestMethod]
        [DataRow(1234, 1234)]
        [DataRow(5678, 5678)]
        public void TestGenerateGoalNumber_MooGame(int mockedGoal, int expectedGoal)
        {
            IGoalGenerator goalGenerator = new MockGoalGenerator(mockedGoal);
       
            mockUI.SetStringInput("1");

            IGameType gameType = game.SetGameType();
            var actualNumber = game.GenerateGoalNumber(goalGenerator);

            Assert.AreEqual(expectedGoal, actualNumber);
        }
        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(1, 1)]
        public void TestGenerateGoalNumber_GuessNumberGame(int mockedGoal, int expectedGoal)
        {
            IGoalGenerator goalGenerator = new MockGoalGenerator(mockedGoal);

            mockUI.SetStringInput("2");

            IGameType gameType = game.SetGameType();
            var actualNumber = game.GenerateGoalNumber(goalGenerator);

            Assert.AreEqual(expectedGoal, actualNumber);
        }

        [TestMethod]
        public void TestGetGameType_ChooseMooGame()
        {
            mockUI.SetStringInput("1");
            IGameType gameType = game.SetGameType();
            Assert.IsInstanceOfType(gameType, typeof(MooGame));
        }

        [TestMethod]
        public void TestGetGameType_ChooseGuessNumberGame()
        {
            mockUI.SetStringInput("2");
            IGameType gameType = game.SetGameType();
            Assert.IsInstanceOfType(gameType, typeof(GuessNumberGame));

        }
    }
}