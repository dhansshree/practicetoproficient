using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class Palindromes
    {
        private string _input;

        public Palindromes(string input)
        {
            _input = input;
        }

        public bool RunWithoutRecursion()
        {
            return checkPalindromeUsingWhile();
        }

        public bool RunWithRecursion()
        {
            return checkPalindromeWithRecursion(_input, 0, _input.Length - 1);
        }

        private bool checkPalindromeWithRecursion(string str , int front , int back)
        {
            if(front == back)
                return true;
            if (Char.ToLower(str.ElementAt(0)) != Char.ToLower(str.ElementAt(str.Length-1)))
                return false;
            if (front <= back)
            {
                //if(!Char.IsLetter(str.ElementAt(front)))
                //{
                //    front++;
                //}
                //if (!Char.IsLetter(str.ElementAt(back)))
                //{
                //    back--;
                //}

                return checkPalindromeWithRecursion(str, front + 1, back - 1);
            }
            return true;
        }

        private bool checkPalindromeUsingWhile()
        {
            int front = 0;
            int back = _input.Length - 1;
            bool isValid = true;
            while (front < back)
            {
                if (Char.ToLower(_input.ElementAt(front)) != Char.ToLower(_input.ElementAt(back)))
                    return false;
                else
                {
                    front++;
                    back--;
                }
            }
            return isValid;
        }
    }
}
