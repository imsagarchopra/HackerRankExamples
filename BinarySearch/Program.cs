using System;

class BinarySearch
{
    static int Search(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Check if the target is at the middle
            if (arr[mid] == target)
                return mid;

            // If the target is greater, ignore the left half
            if (arr[mid] < target)
                left = mid + 1;
            // If the target is smaller, ignore the right half
            else
                right = mid - 1;
        }

        // Target not found in the array
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
