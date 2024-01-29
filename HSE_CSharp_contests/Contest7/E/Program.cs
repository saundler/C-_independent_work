using System;

internal class Program
{
    internal static Calculator calculator;

    private static void Main()
    {
        double start = double.Parse(Console.ReadLine());
        int[] args = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        
        StackCalculator.CreateRules(args);
        calculator(ref start);
        Console.WriteLine(start.ToString("f3"));
    }
}

