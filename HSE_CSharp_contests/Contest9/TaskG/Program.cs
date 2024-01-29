using System;
using System.IO;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        ushort n;
        ushort[] Arr;
        byte[] bin;
        using (StreamReader sr = new StreamReader("input.txt"))
        {
            n = ushort.Parse(sr.ReadLine());
            Arr = new ushort[n];
            for (int i = 0; i < n; i++)
            {
                Arr[i] = ushort.Parse(sr.ReadLine());
            }
        }
        using (FileStream fs = new FileStream("output.bin", FileMode.OpenOrCreate, FileAccess.Write))
        {
            fs.Write(BitConverter.GetBytes(n), 0, 2);
            for(int i = 0; i < n; i++)
            {
                fs.Write(BitConverter.GetBytes(Arr[i]), 0, 2);
            }
        }
    }
}