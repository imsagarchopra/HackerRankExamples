using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arr = Console.ReadLine().TrimEnd().Split(' ').Select(arrTemp => Convert.ToInt64(arrTemp)).ToArray();
            //int[] arr = Console.ReadLine().TrimEnd().Split(' ').Select(arrTemp => Convert.ToInt32(arrTemp)).ToArray();
            MiniMaxSum(arr);
        }

        static void MiniMaxSum(long[] arr)
        {
            //var total = arr[0];
            //var min = arr[0]; 
            //var max = arr[0];
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    total = total + arr[i];
            //    if (min > arr[i])
            //    {
            //        min = arr[i];
            //    }
            //    if (max < arr[i])
            //    {
            //        max = arr[i];
            //    }
            //}
            //Console.WriteLine("" + (total - max) + " " + (total - min) + "\n");
            //Console.Read();

            var total = arr.Sum();
            var max = arr.Max();
            var min = arr.Min();
            Console.WriteLine("" + (total - max) + " " + (total - min) + "\n");
            Console.Read();

            
        }
    }
}
