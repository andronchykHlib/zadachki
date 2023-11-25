using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    internal class Program
    {
        public static void Main()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int[] heights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int[] dp = new int[number];
            List<int> usedPlatforms = new List<int>();
            usedPlatforms.Add(1);

            for (int i = 1; i < number; i++)
            {
                dp[i] = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);
                usedPlatforms.Add(i + 1);
                
                if (i >= 2)
                {
                    int prevDpi = dp[i];
                    int lastUsedPlatformIndex = usedPlatforms.Count - 1;
                    dp[i] = Math.Min(dp[i], dp[i - 2] + 3 * Math.Abs(heights[i] - heights[i - 2]));
                    if (dp[i] != prevDpi) {
                        usedPlatforms[lastUsedPlatformIndex] = i - 1;
                    }
                }
            }

            Console.WriteLine(dp[number - 1]);
            Console.WriteLine(usedPlatforms.Count);
            Console.WriteLine(String.Join(" ", usedPlatforms.ToArray()));
        }
    }
}