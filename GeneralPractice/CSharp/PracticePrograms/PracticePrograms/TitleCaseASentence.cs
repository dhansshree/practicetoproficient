using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class TitleCaseASentence
    {
        private string _input;

        public TitleCaseASentence(string input)
        {
            _input = input;
        }

        public string Run()
        {
            int i = 0;
            string word = string.Empty;
            int ordinal = -1;
            int j = 1;

            _input += " "; //Used for termination

            while (i < _input.Length)
            {
                if (_input.ElementAt(i) != ' ')
                {
                    j++;
                }
                else
                {
                    string title = Char.ToUpperInvariant(_input.ElementAt(ordinal + 1)) + _input.Substring(ordinal + 2, j - 2).ToLowerInvariant() + " ";
                    word += title;
                    ordinal = i;
                    j = 1;
                }
                i++;
            }
            return word.Remove(word.Length - 1) ; //Remove the one used for termination.
        }
    }
}
