using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    internal class Program
    {
        private static int _number;
        private static List<int[]> _solutions;

        static void PlaceQueens(int[] queens, int row)
        {
            if (row == _number)
            {
                _solutions.Add(queens.ToArray());
                return;
            }

            for (int col = 0; col < _number; col++)
            {
                queens[row] = col;

                if (IsSafe(queens, row))
                {
                    PlaceQueens(queens, row + 1);
                }
            }
        }

        static bool IsSafe(int[] queens, int row)
        {
            for (int i = 0; i < row; i++)
            {
                if (queens[i] == queens[row] || Math.Abs(queens[i] - queens[row]) == row - i)
                {
                    return false;
                }
            }
            return true;
        }
        
        public static void Main()
        {
            _number = Convert.ToInt32(Console.ReadLine());
            _solutions = new List<int[]>();

            PlaceQueens(new int[_number], 0);

            foreach (var solution in _solutions)
            {
                Console.WriteLine(string.Join("", solution.Select((x, i) => (char)(i + 'a') + (x + 1).ToString())));
            }

            Console.WriteLine($"(totally {_solutions.Count})");
        }
    }
}