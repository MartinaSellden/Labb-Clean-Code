using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code
{
    internal class ConsoleIO : IUI
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            System.Environment.Exit(0);
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
