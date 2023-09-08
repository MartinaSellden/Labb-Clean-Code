﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public interface IRandomNumberGenerator
    {
        int Next(int minValue, int maxValue);
        int Next(int maxValue);
        int Next();
    }
}
