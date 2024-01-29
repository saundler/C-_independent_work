using System;

partial class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        int[] sortedArr = StrangeSort(arr);
        Print(arr);
        Print(sortedArr);
    }

    private static void Print(int[] arr)
    {
        foreach (var item in arr)
            Console.Write(item + " ");
        Console.WriteLine();
    }
}