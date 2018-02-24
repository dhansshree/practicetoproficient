
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class ReverseStringManually
    {
        private string _input;

        public ReverseStringManually(string input)
        {
            _input = input;
        }

        public string Run()
        {
            int index = _input.Length -1;
            string output = "";
            while(index >=0)
            {
                output = output + _input.ElementAt(index);
                index--;
            }
            return output;
        }

        // With swap
        // With Recursion 
    }
}
