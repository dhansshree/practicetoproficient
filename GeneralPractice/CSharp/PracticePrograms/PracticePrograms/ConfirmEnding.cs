using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class ConfirmEnding
    {
        private string _input;

        public ConfirmEnding(string input)
        {
            _input = input;
        }

        public bool Run(string target)
        {
            bool isEnding = true;
            int i = _input.Length - 1;
            int j = target.Length - 1;
            while(i > 0 && j > 0)
            {
                if (j >= target.Length - 1)
                {
                    if (target.ElementAt(j) != _input.ElementAt(i))
                        return false;
                }
                i--;
                j--;
            }

            //if(_input.Length - i - 1 != target.Length)
            //{
            //    return false;
            //}
            return isEnding;
        }
    }
}
