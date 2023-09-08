﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public interface IDataHandler
    {
        void SaveData(string fileName, List<Player> players);
        List<Player> RetrieveData(string fileName);
    }
}
