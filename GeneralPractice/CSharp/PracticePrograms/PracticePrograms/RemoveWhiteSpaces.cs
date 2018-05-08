using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class RemoveWhiteSpaces
    {
        private char[] _input;

        public RemoveWhiteSpaces(char[] input)
        {
            _input = input;
            
        }

        public char[] Run()
        {
            int readPtr = 0;
            int writePtr = 0;

            while(readPtr < _input.Length)
            {
                if(_input[readPtr] != ' ')
                {
                    _input[writePtr] = _input[readPtr];
                    writePtr++;
                }

                readPtr++;
            }

            _input[writePtr] = '%';

            return _input;

        }

    }
}
