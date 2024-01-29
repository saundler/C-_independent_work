using System;

namespace B
{
    public delegate double Calculate(int x);
    class Program
    {
        static void Main(string[] args)
        {
            Calculate Calc = (int x) =>
            {
                double n, m = 0;
                for (int i = 1; i < 6; i++)
                {
                    n = 1;
                    for (int j = 1; j < 6; j++)
                    {
                        n *= ((i + 42) * x) / (double)(j * j);
                    }
                    m += n;
                }
                return m;
            };
            Console.WriteLine($"{Calc(int.Parse(Console.ReadLine())):f3}");
        }
    }
}

