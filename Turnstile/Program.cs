using System;
using System.Collections.Generic;

public class Turnstile
{
    public static int[] GetTimes(int[] time, int[] direction)
    {
        Queue<int> enters = new Queue<int>();
        Queue<int> exits = new Queue<int>();
        int n = time.Length;
        for (int i = 0; i < n; i++)
        {
            Queue<int> q = direction[i] == 1 ? exits : enters;
            q.Enqueue(i);
        }

        int[] result = new int[n];
        int lastTime = -2;
        Queue<int> lastQ = exits;
        while (enters.Count > 0 && exits.Count > 0)
        {
            int currentTime = lastTime + 1;
            int peekEnterTime = time[enters.Peek()];
            int peekExitTime = time[exits.Peek()];
            Queue<int> q;
            if (currentTime < peekEnterTime && currentTime < peekExitTime)
            {
                q = (peekEnterTime < peekExitTime) ? enters : exits;
                int personIdx = q.Dequeue();
                result[personIdx] = time[personIdx];
                lastTime = time[personIdx];
                lastQ = q;
            }
            else
            {
                if (currentTime >= peekEnterTime && currentTime >= peekExitTime)
                {
                    q = lastQ;
                }
                else
                {
                    q = currentTime >= peekEnterTime ? enters : exits;
                }
                int personIdx = q.Dequeue();
                result[personIdx] = currentTime;
                lastTime = currentTime;
                lastQ = q;
            }
        }

        Queue<int> q2 = enters.Count > 0 ? enters : exits;
        while (q2.Count > 0)
        {
            int currentTime = lastTime + 1;
            int personIdx = q2.Dequeue();
            if (currentTime < time[personIdx])
            {
                currentTime = time[personIdx];
            }

            result[personIdx] = currentTime;
            lastTime = currentTime;
        }

        return result;
    }

    public static void Test(int[] time, int[] direction, int[] expected)
    {
        int[] result = GetTimes(time, direction);
        Console.WriteLine("ACTUAL: " + string.Join(", ", result));
        Console.WriteLine("EXPECTED: " + string.Join(", ", expected));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Turnstile");
        Test(new int[] { 0, 0, 1, 5 }, new int[] { 0, 1, 1, 0 }, new int[] { 2, 0, 1, 5 });
        Test(new int[] { 0, 0, 5, 5 }, new int[] { 0, 1, 1, 0 }, new int[] { 1, 0, 5, 6 });
        Test(new int[] { 0, 0, 1, 1 }, new int[] { 0, 1, 1, 0 }, new int[] { 2, 0, 1, 3 });
        Test(new int[] { 0, 0, 0, 0 }, new int[] { 0, 1, 1, 0 }, new int[] { 2, 0, 1, 3 });
        Test(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 1, 2, 3 });
        Test(new int[] { 0, 0, 1, 3, 10 }, new int[] { 0, 1, 1, 1, 0 }, new int[] { 2, 0, 1, 3, 10 });
        Test(new int[] { 0, 1, 1, 3, 3 }, new int[] { 0, 1, 0, 0, 1 }, new int[] { 0, 2, 1, 4, 3 });
    }
}
