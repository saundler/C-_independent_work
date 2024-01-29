using System;

partial class Program
{
    internal static int[] StrangeSort(int[] arr)
    {
        int[] a = new int[arr.Length];
        Array.Copy(arr, a, arr.Length);
        Array.Sort(a, (int a, int b) => { return a.ToString().Length - b.ToString().Length; });
        return a;
    }
}