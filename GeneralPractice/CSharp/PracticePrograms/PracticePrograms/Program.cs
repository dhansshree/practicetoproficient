using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Util.PrintResults(new FindIndicesOfSumInArray(new int[] { 3, 4, 6 }, 10).Run());
            //Util.PrintResults(new List<string>() { new CheckFormityOfParanthesis("{()[]}").Run() });
            //Console.WriteLine(new ReverseStringManually("Greetings from Earth").Run());
            //Console.WriteLine(new FactorialOfCourse(20).Run());
            //Console.WriteLine(new FibonacciWithMemoization(9).Run());
            //Console.WriteLine(new Palindromes("abcba").RunWithoutRecursion());
            //Console.WriteLine(new Palindromes("abcba").RunWithRecursion());
            Console.WriteLine(new FindLongestWord("What if we try a super-long word otorhinolaryngologysuch as otorhinolaryngology").Run().Length);
        }

    }
}
