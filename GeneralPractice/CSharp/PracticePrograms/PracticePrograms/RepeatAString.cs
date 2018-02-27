
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class RepeatAString
    {
        private string _input;

        public RepeatAString(string input)
        {
            _input = input;
        }


        public string Run(int times)
        {
            string repeat = "";
            int i = times;
            while (i >= 1)
            {
                repeat += _input;
            
                i--;
            }

           
            return repeat;
        }
    }
}
