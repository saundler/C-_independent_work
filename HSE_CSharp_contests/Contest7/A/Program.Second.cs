using System;
using System.Linq;

partial class Program
{
    public static int SecondInArray(int[] arr)
    {
        if(arr.Length < 2)
        {
            throw new ArgumentException("Not enough elements");
        }
        Array.Sort(arr);
        return arr[^2];
    }
}