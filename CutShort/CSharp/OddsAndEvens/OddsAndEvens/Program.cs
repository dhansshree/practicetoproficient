using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CutShort
{
    class Program
    {
        static void Main(string[] args)
        {
            OddsAndEvens.PrintResults(OddsAndEvens.GetResults(new int[] { 1, 2, 3, 4, 5, 5, 5, 6, 62, 3 }));
        }
    }
}
