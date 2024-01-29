using System;
using System.Collections.Generic;

internal class Chain<T>
{
    public List<T> str;
    public Chain()
    {
        str = new List<T>();
    }
    public void AddToChain(T a)
    {
        str.Add(a);
    }

    public static int Rule(T e, T d)
    {
        string a = e.ToString(), b = d.ToString();
        int c;
        if(a == b)
            return 0;
        for(int i = 0; i < Math.Min(a.Length,b.Length); i++)
        {
            c = Convert.ToInt32(a[i]) - Convert.ToInt32(b[i]);
            if (c == 0)
                continue;
            return c;
        }
        return a.Length - b.Length;
    }
    public override string ToString()
    {
        T[] arr = str.ToArray();
        if(arr is int[])
        {
            Array.Sort(arr);
            return string.Join(' ', arr);
        }
        if(arr is string[])
        {
            Array.Sort(arr, Rule);
            return string.Join(' ', arr);
        }
        return string.Empty;
    }
}