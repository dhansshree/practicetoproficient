using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograms
{
    public class FindIndicesOfSumInArray
    {
        private int[] _inputArray;
        private int _expectedSum;

        public FindIndicesOfSumInArray(int[] inputArray, int expectedSum)
        {
            _inputArray = inputArray;
            _expectedSum = expectedSum;
        }

        public List<int> Run()
        {
            List<int> outputList = null;
            Dictionary<int, int> dictOfIndices = new Dictionary<int, int>();
            for (int i = 0; i < _inputArray.Length; i++)
            {
                dictOfIndices[_inputArray[i]] = i;
            }
            
            for (int i = 0; i < _inputArray.Length; i++)
            {
                int diff = _expectedSum - _inputArray[i];
                if(dictOfIndices.ContainsKey(diff) && dictOfIndices[diff]!= i)
                {
                    outputList = new List<int>();
                    outputList.Add(i);
                    outputList.Add(dictOfIndices[diff]);
                    break;
                }
            }
            return outputList;
        }

        
    }
}
