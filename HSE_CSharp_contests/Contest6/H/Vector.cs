using System;

internal struct Vector 
{
    public Vector(int x, int y)
    {
        Length = Math.Sqrt(x * x + y * y);
    }

    public double Length;

    public int CompareTo(object? b)
    {
        Vector a = (Vector)b;
        if(this.Length > a.Length)
        {
            return 1;
        }
        else if (this.Length == a.Length)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    public static Vector Parse(string input)
    {
        int[] line;
        try
        {
            line = Array.ConvertAll(input.Split(' '), int.Parse);
            if(line.Length != 2)
            {
                throw new ArgumentException("Incorrect vector");
            }
        }
        catch
        {
            throw new ArgumentException("Incorrect vector");
        }
        return new Vector(line[0], line[1]);
    }
}