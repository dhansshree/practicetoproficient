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

        [TestFixture]
        public class TitleCaseASentenceTest
        {
            
            [TestCase("I'm a little tea pot", "I'm A Little Tea Pot")]
            [TestCase("sHoRt AnD sToUt", "Short And Stout")]
            [TestCase("HERE IS MY HANDLE HERE IS MY SPOUT", "Here Is My Handle Here Is My Spout")]
            public void TitleCaseASentence_Test(string input, string result)
            {
                Assert.AreEqual(result, new TitleCaseASentence(input).Run());
            }
        }
    }
}
