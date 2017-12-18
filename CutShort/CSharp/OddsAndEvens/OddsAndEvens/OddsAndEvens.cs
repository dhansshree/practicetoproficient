using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutShort
{
    public static class OddsAndEvens
    {
        public static void PrintResults(List<Result> results)
        {
            foreach (Result item in results)
            {
                Console.WriteLine("Total of {0} {1} items with sum {2}.", item.Count, item.TypeOfNumber, item.Sum);
            }
        }

        public static List<Result> GetResults(int[] arr)
        {
            int count = 1, sum=0;
            TypeOfNumber typeOfNumber = GetTypeOfNumber(arr[0]);
            sum = sum + arr[0];
            List<Result> result = new List<Result>();
            int i = 1;
            while (i < arr.Length)
            {
                if (typeOfNumber == GetTypeOfNumber(arr[i]))
                {
                    count++;
                    sum = sum + arr[i];
                    typeOfNumber = GetTypeOfNumber(arr[i]);
                }
                else
                {
                    result.Add(new Result(count, sum, typeOfNumber));
                    count = 1;
                    sum = 0;
                    sum = sum + arr[i];
                    typeOfNumber = GetTypeOfNumber(arr[i]);
                }
                i++;
            }
            result.Add(new Result(count, sum, typeOfNumber));
            return result;

        }

        private static TypeOfNumber GetTypeOfNumber(int i)
        {
            return i % 2 == 0 ? TypeOfNumber.Even : TypeOfNumber.Odd;
        }
    }

    public class Result
    {
        private int _count;
        private int _sum;
        private TypeOfNumber _typeOfNumber;

        public Result(int count, int sum , TypeOfNumber type)
        {
            _count = count;
            _sum = sum;
            _typeOfNumber = type;
        }

        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                _count = value;
            }
        }

        public int Sum
        {
            get
            {
                return _sum;
            }

            set
            {
                _sum = value;
            }
        }

        public TypeOfNumber TypeOfNumber
        {
            get
            {
                return _typeOfNumber;
            }

            set
            {
                _typeOfNumber = value;
            }
        }
    }

    
    public enum TypeOfNumber
    {
        Even,
        Odd
    }

    
}
