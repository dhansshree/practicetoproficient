using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.BasicDataStructures
{
    public class BinarySearchRecursion
    {
        private int[] _input;

        public BinarySearchRecursion(int[] input)
        {
            _input = input;
        }

        public int Run(int key)
        {
            return BinarySearchRecustiveFunc(key, _input, 0, _input.Length -1);
        }

        private static int BinarySearchRecustiveFunc(int key , int[] array , int lowIndex , int highIndex)
        {
            if (lowIndex > highIndex)
                return -1;

            int mid = (lowIndex + highIndex)/2;

            if (array[mid] == key)
                return mid;

            if (key < array[mid])
                return BinarySearchRecustiveFunc(key, array, lowIndex, mid - 1);

            return BinarySearchRecustiveFunc(key, array, mid + 1, highIndex);

        }
    }
}
