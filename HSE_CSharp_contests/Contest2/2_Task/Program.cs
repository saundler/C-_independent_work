using System;

namespace Task_B
{
    internal class Program
    {
        static void Main()
        {
            int sum = 0, password = 0;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out password))
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
                if (password % 2 == 1 || password % 2 == -1)
                {
                    sum += password;
                }
            } while (password != 0) ;
            Console.WriteLine(sum);
        }
    }
}