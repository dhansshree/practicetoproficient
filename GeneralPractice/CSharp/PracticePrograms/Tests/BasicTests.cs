using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.Tests
{
    public class BasicTests
    {
        [TestFixture]
        public class PalindromesTest
        {
            [TestCase("abcba", true)]
            [TestCase("1 eye for of 1 eye", false)]
            public void PalidromeTests(string input , bool result)
            {
                Assert.AreEqual(result , new Palindromes(input).RunWithRecursion());
            }
        }
    }
}
