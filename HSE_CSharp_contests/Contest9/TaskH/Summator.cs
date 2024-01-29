using System;
using System.IO;
using System.Linq;

internal class Summator
{
    public Summator(string path)
    {
        Sum = 0;
        using (StreamReader sr = new StreamReader(path))
        {
            while(!sr.EndOfStream)
                Sum += sr.ReadLine().Split("_").Select(int.Parse).ToArray().Sum();
        }
    }

    public int Sum { get; set; }
}