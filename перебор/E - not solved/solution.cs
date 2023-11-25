using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<string> permutations = new List<string>();

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        long V = long.Parse(input[0]);
        long S = long.Parse(input[1]);

        for (long a = 1; a * a <= V; a++)
        {
            if (V % a == 0)
            {
                long bc = V / a;
                for (long b = a; b * b <= bc; b++)
                {
                    if (bc % b == 0)
                    {
                        long c = bc / b;
                        if (2 * (a * b + b * c + c * a) == S)
                        {
                            Permute(new long[] {a, b, c}, 0, 2);
                        }
                    }
                }
            }
        }

        if (permutations.Count > 0) {
            var intPermutations = permutations.ConvertAll<long[]>((string str) => Array.ConvertAll(str.Split(), long.Parse));
            intPermutations.Sort(new PermutationComparer());
            foreach(var permutation in intPermutations) {
               Console.WriteLine($"{permutation[0]} {permutation[1]} {permutation[2]}");
            }
        } else {
            Console.WriteLine("0 0 0");
        }
    }

    static void Permute(long[] numbers, long left, long right)
    {
        if (left == right)
        {
            string str = string.Join(' ', numbers);
            if (!permutations.Contains(str)) {
                permutations.Add(str);
            }
        }
        else
        {
            for (long i = left; i <= right; i++)
            {
                Swap(numbers, left, i);
                Permute(numbers, left + 1, right);
                Swap(numbers, left, i);
            }
        }
    }

    static void Swap(long[] numbers, long i, long j)
    {
        long temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
    }
    
}
        
class PermutationComparer : IComparer<long[]>
    {
        public int Compare(long[] x, long[] y)
        {
            if (x[0] != y[0])
            {
                return x[0].CompareTo(y[0]);
            }
            else
            {
                return x[1].CompareTo(y[1]);
            }
        }
    }