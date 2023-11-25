using System;

class Solution {
    public static void Main(string[] args) {
        long[] range = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        long A = range[0];
        long B = range[1];

        for (long i = A; i <= B; i++) {
            if (isPrime(i)) {
                Console.WriteLine(i);
            }
        }
    }

    public static bool isPrime(long num) {
        if (num == 2) {
            return true;
        }
        if (num == 1 || num % 2 == 0) {
            return false;
        }

        long boundary = (long)Math.Floor(Math.Sqrt(num));

        for(long i = 3; i <= boundary; i+=2) {
            if (num % i == 0) {
                return false;
            }
        }

        return true;
    }
}