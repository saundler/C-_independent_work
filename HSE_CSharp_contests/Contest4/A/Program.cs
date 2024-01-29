using System;

internal static class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var number = new IntWrapper(int.Parse(Console.ReadLine()));
            Console.WriteLine(number.NumberLength);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}