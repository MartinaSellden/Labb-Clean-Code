using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    public interface IUI
    {
        void PutString(string outputString);
        string GetString();
        void Exit();
        void Clear();
    }
}
