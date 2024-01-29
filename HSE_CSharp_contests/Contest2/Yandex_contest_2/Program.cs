using System;

namespace Task_A
{
    internal class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            uint sum = 0 , password;
            if (!uint.TryParse(str, out password))
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            for(int i = 0; i <  str.Length; i++)
            {
                sum += (password % 10);
                password /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}