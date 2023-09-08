using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    public interface IGameType
    {
        void PlayGame(Player player);
        int GenerateGoalNumber(IGoalGenerator goalGenerator);
    }
}
