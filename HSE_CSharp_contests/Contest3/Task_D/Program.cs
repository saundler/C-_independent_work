using System;

public partial class Program
{
    private static bool Validate(string input, out int num)
    {
        return int.TryParse(input, out num) && num >= 0 ? true : false;
    }

    private static int RecurrentFunction(int n)
    {
        if (n == 0)
        {
            return 3;
        }
        return 2 * (RecurrentFunction(n - 1) + 1);
    }
    /*public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if (!Validate(input, out int number))
        {
            Console.WriteLine("Incorrect input");
            return;
        }

        Console.WriteLine(RecurrentFunction(number));
    }*/

}