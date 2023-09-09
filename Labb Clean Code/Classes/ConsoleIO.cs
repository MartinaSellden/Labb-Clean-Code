using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_Clean_Code;

namespace Labb_Clean_Code
{
    public class ConsoleIO : IUI
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        public void PutString(string outputString)
        {
            Console.WriteLine(outputString);
        }
    }
}
