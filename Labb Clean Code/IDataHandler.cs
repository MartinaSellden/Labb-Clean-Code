using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    internal interface IDataHandler
    {
        void SaveData(string fileName, Player player);
        List<Player> RetrieveData(string fileName);
    }
}
