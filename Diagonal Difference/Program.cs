using System;
using System.Collections.Generic;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            List<List<int>> arr = new List<List<int>>();

            for(int i=0; i<n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = CalculateDiagonalDifference(arr);

            Console.WriteLine(result);
            Console.Read();
        }

        public static int CalculateDiagonalDifference(List<List<int>> arr)
        {
            int row = 0;
            int column = arr.Count() - 1;
            int solution = 0;

            for(int i=0; i<arr.Count(); i++)
            {
                solution -= arr[row][row] - arr[row++][column--];
            }

            return Math.Abs(solution);
        }
    }
}