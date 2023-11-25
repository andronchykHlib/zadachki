using System;
using System.Linq;

class Solution {
    public static void Main(string[] args) {
        int[] sizes = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = sizes[0];
        int m = sizes[1];
        int[][] table = new int[n][];
        int[][] memoizedSum = new int[n][];
      
        for (int i = 0; i < n; i++)
        {
            table[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            if (i > 0)
            {
                memoizedSum[i] = new int[m];
            }
        }

        memoizedSum[0] = table[0];

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                // это пиздец
                int prevMaxSum = Math.Max(memoizedSum[i - 1][j > 0 ? j - 1 : 0], Math.Max(memoizedSum[i - 1][j], memoizedSum[i - 1][j < m - 1 ? j + 1 : m - 1]));
                memoizedSum[i][j] = table[i][j] + prevMaxSum;
            }
        }

        Console.WriteLine(memoizedSum[n - 1].Max());
    }
}