using System;
using System.Linq;

partial class Program
{
    private static int[] ParseInput(string input)
    {
        return input.Split(' ').Select(int.Parse).ToArray();
    }

    private static int GetNumberOfEqualElements(int[] first, int[] second)
    {
        int count = 0;
        foreach(int element1 in first)
        {
            foreach(int element2 in second)
            {
                if (element2 ==  element1)
                {
                    count++;
                }
            }
        }
        return count;
    }
    /*public static void Main(string[] args)
    {
        var first = ParseInput(Console.ReadLine());
        var second = ParseInput(Console.ReadLine());

        Console.WriteLine(GetNumberOfEqualElements(first, second));
    }*/

}

