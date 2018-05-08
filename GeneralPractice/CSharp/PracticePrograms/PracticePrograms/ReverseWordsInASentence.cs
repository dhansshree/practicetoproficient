using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class ReverseWordsInASentence
    {
        private char[] _input;

        public ReverseWordsInASentence(char[] input)
        {
            _input = input;
        }

        public char[] Run()
        {
            ReverseCharacters(_input, 0, _input.Length - 1);

            int start = 0;
            for (int i = 0; i <= _input.Length; i++)
            {
                if (i == _input.Length || _input[i] == ' ')
                {
                    ReverseCharacters(_input, start, i - 1);
                    start = i + 1;
                }

            }

            return _input;
        }

        public void ReverseCharacters(char[] message, int leftIndex, int rightIndex)
        {
            while( leftIndex < rightIndex)
            {
                char temp = message[leftIndex];
                message[leftIndex] = message[rightIndex];
                message[rightIndex] = temp;

                rightIndex--;
                leftIndex++;
                
            }


        }
    }
}
