using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    internal class Game
    {
        IGameType gameType;

        public Game()
        {

        }
        public Game(IGameType gameType)
        {
            this.gameType = gameType;
        }

        public void SetGameType(IGameType gameType)
        {
            this.gameType = gameType;
        }

        public string GenerateNumber()
        {
            return gameType.GenerateNumber();
           
        }  
        
    }
}
