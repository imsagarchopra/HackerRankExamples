namespace MostFrequentElement
{
    internal class Program
    {
        // Driver code
        static void Main()
        {
            int[] arr = new int[] { 40, 50, 30, 40, 50, 30, 30, 50, 50, 50 };
            int n = arr.Length;

            Console.Write(mostFrequent2(arr, n));
        }

        private static int mostFrequent1(int[] arr, int n)
        {
            Dictionary<int,int> set = new Dictionary<int,int>();

            for(int i = 0; i<n; i++)
            {
                int key = arr[i];
                if (set.ContainsKey(key))
                {
                    int freq = set[key];
                    freq++;
                    set[key] = freq;
                }
                else
                {
                    set.Add(key, 1);
                }
            }

            int maxCount = 0;
            int result = -1;

            foreach(KeyValuePair<int,int> kvp in set)
            {
                if(kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    result = kvp.Key;
                }
            }

            return result;
        }

        private static int mostFrequent2(int[] arr, int n)
        {
            int maxValue = arr.Max();

            int[] hashArray = new int[maxValue+1];

            for (int i = 0; i < n; i++)
            {
                hashArray[arr[i]]++;
            }

            int maxCount = 0;
            int result = -1;

            for(int i = 0; i< hashArray.Length; i++)
            {
                if (hashArray[i] > maxCount)
                {
                    maxCount = hashArray[i];
                    result = i;
                }
            }           

            return result;
        }
    }
}