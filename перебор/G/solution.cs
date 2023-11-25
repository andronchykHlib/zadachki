using System;

namespace Program
{
    internal class Program
    {
        private static void SumOfThird(int n, int x, int[] array)
        {
            Array.Sort(array); 
            
            for (int i = 0; i < n - 2; i++)
            {
                int left = i + 1;
                int right = n - 1;
                int current = array[i];

                while (left < right)
                {
                    int sum = current + array[left] + array[right];

                    if (sum == x)
                    {
                        Console.WriteLine($"{current} {array[left]} {array[right]}");
                        return;
                    }
                    
                    if (sum < x)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            Console.WriteLine("-1");
        }
        
        public static void Main()
        {
            string[] strOfFirst = Console.ReadLine().Split();
            
            int n = int.Parse(strOfFirst[0]);
            int x = int.Parse(strOfFirst[1]);

            string[] strOfSecond = Console.ReadLine().Split();
            
            int[] array = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(strOfSecond[i]);
            }

            SumOfThird(n, x, array);
        }
    }
}