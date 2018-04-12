using NUnit.Framework;
using PracticePrograms.BasicDataStructures;
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
            //Console.WriteLine(new FindLongestWord("What if we try a super-long word otorhinolaryngologysuch as otorhinolaryngology").Run());
            //Console.WriteLine(new TitleCaseASentence("HERE IS MY HANDLE HERE IS MY SPOUT").Run());

            //int[][] jaggedArray = new int[4][];
            //jaggedArray[0] = new int[] { 4, 5, 1, 3 };
            //jaggedArray[1] = new int[] { 13, 27, 18, 26 };
            //jaggedArray[2] = new int[] { 32, 35, 37, 39 };
            //jaggedArray[3] = new int[] { 1000, 2001, 857, 1 };
            //Util.PrintResults(new FindLargestNumbersInArray(jaggedArray).Run());

            //Console.WriteLine(new ConfirmEnding("If you want to save our world, you must hurry. We dont know how much longer we can withstand the nothing").Run("nothing")); ;

            //Console.WriteLine(new RepeatAString("*").Run(3)); ;

            //Console.WriteLine(new BinarySearchRecursive(new int[] { 4 , 5, 5, 7 }).Run(7));

            //Console.WriteLine(new BinarySearchNonRecursive(new int[] { 4, 5, 5, 7 , 9}).Run(19));

            //Console.WriteLine(new ReverseWordsInASentence(new char[] { 't', 'h', 'e', ' ', 'e', 'a', 'g', 'l', 'e', ' ','h', 'a', 's', ' ', 'l', 'a', 'n', 'd', 'e', 'd' }).Run());

            Console.WriteLine(new RemoveWhiteSpaces(new char[] { ' ','t', 'h', 'e', ' ', 'e', 'a', 'g', 'l', 'e', ' ', 'h', 'a', 's', ' ', 'l', 'a', 'n', 'd', 'e', 'd' ,' ',' '}).Run());

        }

    }
}
