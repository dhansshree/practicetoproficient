using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class CheckFormityOfParanthesis
    {
        private Dictionary<char, char> _dict = new Dictionary<char, char>()
            {
                 { ')', '(' },
                 { '>', '<' },
                 { ']', '[' },
                 { '}', '{' }
            };

        private string _input;

        public CheckFormityOfParanthesis(string input)
        {
            _input = input;
        }

        public string Run()
        {
            Stack<char> stack = new Stack<char>();
            try
            {
                foreach (var item in _input.ToCharArray())
                {
                    if (_dict.ContainsValue(item))
                    {
                        stack.Push(item);
                    }
                    else
                    {
                        if (stack.First() == _dict[item])
                            stack.Pop();
                    }

                }
            }
            catch
            {
                return "InValid";
            }
            return stack.Count == 0 ? "Valid" : "InValid";
        }

        private static char GetClosingParathesis(char openParanthesis)
        {
            char closingParathesis = '}';
            switch (openParanthesis)
            {
                case '}':
                    closingParathesis = '{';
                    break;
                case ']':
                    closingParathesis = '[';
                    break;
                case ')':
                    closingParathesis = '(';
                    break;
                case '>':
                    closingParathesis = '<';
                    break;
                default:
                    closingParathesis = '!';
                    break;
            }
            return closingParathesis;
        }
    }
}
