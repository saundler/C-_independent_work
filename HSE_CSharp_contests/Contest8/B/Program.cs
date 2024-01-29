using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Chain<int> intChain = new Chain<int>();
        Chain<string> stringChain = new Chain<string>();
        string[] inputS = Console.ReadLine().Split();
        int[] input = Array.ConvertAll(inputS, int.Parse);
        foreach (var item in input)
        {
            intChain.AddToChain(item);
        }
        foreach (var item in inputS)
        {
            stringChain.AddToChain(item);
        }
        Console.WriteLine(intChain);
        Console.WriteLine(stringChain);
        Console.WriteLine(intChain);
    }
}