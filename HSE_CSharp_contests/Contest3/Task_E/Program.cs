using System;
using System.Linq;

public partial class Program
{
    private static int[] ParseInput(string input)
    {
        return input.Split(" ").Select(int.Parse).ToArray(); 
    }

    private static int GetMaxInArray(int[] numberArray)
    {
        return numberArray.Max();
    }
    public static void Main(string[] args)
    {
        var numberArray = ParseInput(Console.ReadLine());

        Console.WriteLine(GetMaxInArray(numberArray));
    }

}

