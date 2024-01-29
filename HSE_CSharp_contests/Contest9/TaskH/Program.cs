using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var summator = new Summator("input.txt");
        Console.WriteLine(summator.Sum);
    }
}