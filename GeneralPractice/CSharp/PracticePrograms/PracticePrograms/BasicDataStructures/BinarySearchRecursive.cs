using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms.BasicDataStructures
{
    public class BinarySearchRecursive
    {
        private int[] _input;

        public BinarySearchRecursive(int[] input)
        {
            _input = input;
        }

        public int Run(int elementToBeFound)
        {
            return BinarySearch(_input, elementToBeFound, 0, _input.Length - 1);
        }

        private int BinarySearch(int[] array , int elem , int low , int high)
        {
            if (low > high)
                return -1;

            int mid = (low + high) / 2; //low + ((high - low) / 2);

            if (array[mid] == elem)
                return mid;

            if (elem < array[mid])
                return BinarySearch(array, elem, low, mid - 1);

            return BinarySearch(array, elem, mid +1 , high);
        }
    }
}
