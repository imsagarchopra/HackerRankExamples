using System;

class BinarySearch
{
    static int Search(int[] arr, int target)
    {
        int left, mid, right;

        left = 0;
        right = arr.Length - 1;
        

        while(left <= right)
        {
            mid = left + (right - left) / 2;

            if (target == arr[mid])
                return mid;
            else if(target > arr[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    static void Main(string[] args)
    {
        int[] sortedArray = { 2, 5, 8, 12, 16, 23, 38, 45, 56, 72 };
        int target = 23;

        int index = Search(sortedArray, target);

        if (index != -1)
            Console.WriteLine($"Element {target} found at index {index}.");
        else
            Console.WriteLine($"Element {target} was not found in the array.");
    }
}
