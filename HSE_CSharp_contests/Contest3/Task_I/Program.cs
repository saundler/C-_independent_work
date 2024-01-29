using System;
using System.Linq;

public static class Program
{
    static int[] StringToIntConverter(string valuesstring)
    {
        return valuesstring.Split(',').Select(int.Parse).ToArray();
    }
    static void ArrayOutput(int[] Arr)
    {
        for (int i = 0; i < Arr.Length; i++)
        {
            for (int j = i; j < Arr.Length; j++)
            {
                Console.Write(Arr[j]);
            }
            for(int j = 0; j < i; j++)
            {
                Console.Write(Arr[j]);
            }
            Console.WriteLine("");
        }
    }
    public static void Main()
    {
        ArrayOutput(StringToIntConverter(Console.ReadLine()));
    }
}