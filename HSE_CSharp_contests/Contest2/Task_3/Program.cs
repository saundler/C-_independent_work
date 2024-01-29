using System;

namespace Task_C
{
    internal class Program
    {
        static void Main()
        {
            bool flaga = int.TryParse(Console.ReadLine(), out int a),
                 flagb = int.TryParse(Console.ReadLine(), out int b);
            if (!flaga || !flagb || a > b)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            for (int i = a; i < b ; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}