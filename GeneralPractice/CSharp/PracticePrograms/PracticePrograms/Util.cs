using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public static class Util
    {
        public static void PrintResults<T>(IEnumerable<T> results)
        {
            if (results == null)
            {
                Console.WriteLine("No results found");
            }
            else
            {
                foreach (var item in results)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }
}
