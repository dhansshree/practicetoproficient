using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class FindLongestWord
    {
        private string _input;

        public FindLongestWord(string input)
        {
            _input = input;
        }

        public string Run()
        {
            int i = 0;
            string word = string.Empty;
            int ordinal = 0;
            int j = 0;

            _input += " "; //Used for termination

            while (i < _input.Length)
            {
                if (_input.ElementAt(i) != ' ')
                {
                    j++;
                }
                else
                {
                    if (j > word.Length)
                        word = _input.Substring(ordinal, j);
                    ordinal = i;
                    j = 0;
                }
                i++;
            }
            return word;
        }
    }
}
