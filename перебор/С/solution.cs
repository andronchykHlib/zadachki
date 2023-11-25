using System;

namespace Program
{
    internal class Program
    {
        public static void Main()
        {
            int number = Convert.ToInt32(Console.ReadLine());

            int max = (int)Math.Pow(number, 0.25) + 1;

            for (int a = 0; a <= max; a++)
            {
                int aFourth = a * a * a * a;

                for (int b = a; b <= max; b++)
                {
                    int bFourth = b * b * b * b;

                    for (int c = b; c <= max; c++)
                    {
                        int cFourth = c * c * c * c;

                        for (int d = c; d <= max; d++)
                        {
                            int dFourth = d * d * d * d;
                            
                            int eFourth = number - (aFourth + bFourth + cFourth + dFourth);

                            if (eFourth < 0)
                            {
                                break;
                            }

                            int e = (int)Math.Pow(eFourth, 0.25);

                            if (e * e * e * e == eFourth)
                            {
                                Console.WriteLine($"{a} {b} {c} {d} {e}");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("-1 -1 -1 -1 -1");
        }
    }
}