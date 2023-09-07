using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_Clean_Code.Tests
{
    internal class MockUI : IUI
    {
        private string inputString;
        private string outputString;
        private bool exitRequested;
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            exitRequested = true;
        }

        public string GetString()
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                string input = inputString;  
                inputString = null;         
                return input;               
            }
            throw new InvalidOperationException("No more string inputs provided.");
        }

        public void PutString(string outputString)
        {
            this.outputString = outputString;
        }

        public void SetStringInput(string inputString)
        {
            this.inputString = inputString;
        }
    }
}
