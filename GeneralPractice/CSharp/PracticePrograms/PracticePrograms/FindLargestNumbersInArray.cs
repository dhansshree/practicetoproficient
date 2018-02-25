using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class FindLargestNumbersInArrays
    {
        private int[][] _input;

        public FindLargestNumbersInArrays(int[][] input)
        {
            _input = input;
        }

        public int[] Run()
        {
            int[] array = new int[4];

            for (int i = 0; i < 4; i++)
            {
                array[i] = findLargestInArray(_input[i]);
            }    

            return array;
        }

        private int findLargestInArray(int[] array)
        {
            int largest = 0 ;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > largest)
                    largest = array[i];
            }
            return largest;
        }
    }
}
