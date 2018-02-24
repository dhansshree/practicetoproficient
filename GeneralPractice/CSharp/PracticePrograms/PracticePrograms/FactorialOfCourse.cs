using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class FactorialOfCourse
    {
        private long _input;

        public FactorialOfCourse(long input)
        {
            _input = input;
        }

        public long Run()
        {
            return factorial(_input);
        }

        private long factorial(long n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }
    }
}
