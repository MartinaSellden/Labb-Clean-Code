using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;
using Labb_Clean_Code;

namespace Labb_Clean_Code.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        private GameController gameController;

        [TestInitialize]
        public void TestInitialize()
        {
            IUI ui = new ConsoleIO();
            GameController gameController = new GameController(ui);
        }

        [TestMethod]
        public void TestSetGameType()

        {
            //IGameType gameType = new MooGame();
            //gameController.SetGameType();
            //Assert.
        }
    }
}
