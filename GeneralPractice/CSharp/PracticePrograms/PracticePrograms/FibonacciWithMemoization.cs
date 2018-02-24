using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class FibonacciWithMemoization
    {
        private long _input;

        public FibonacciWithMemoization(long input)
        {
            _input = input;
        }

        public long Run()
        {
            Dictionary<long, long> dict = new Dictionary<long, long>();

            return fib(_input, dict);

        }

        private long fib(long n , Dictionary<long,long> dict)
        {
             if(n <= 1)
             {
                return n;
             }

             if (dict.ContainsKey(n))
                return dict[n];
             long fibVal = fib(n - 1,dict) + fib(n - 2,dict);
             dict[n] = fibVal;
             return fibVal;
        }
    }
}
