using System;

public class RandomExtension
{
    Random rnd;
    public RandomExtension(int n)
    {
        rnd = new Random(n);
    }
    public double NextDouble(double minValue, double maxValue)
    {
        if (minValue >= maxValue)
            throw new ArgumentException("minValue cannot be greater than maxValue");
        return rnd.NextDouble() * (maxValue - minValue) + minValue;
    }

    public int NextEven(int minValue, int maxValue)
    {
        if (minValue >= maxValue) 
            throw new ArgumentException("minValue cannot be greater than maxValue");
        if (minValue + 1 == maxValue && minValue % 2 != 0) 
            throw new ArgumentException("no numbers in this range");
        var a = rnd.Next(minValue, maxValue);
        if (a == maxValue - 1 && a % 2 != 0) return a - 1;
        return a % 2 == 0 ? a : a + 1;
    }

    public int NextOdd(int minValue, int maxValue)
    {
        if (minValue >= maxValue) 
            throw new ArgumentException("minValue cannot be greater than maxValue");
        if (minValue + 1 == maxValue && minValue % 2 == 0) 
            throw new ArgumentException("no numbers in this range");
        var a = rnd.Next(minValue, maxValue);
        if (a == maxValue - 1 && a % 2 == 0) 
            return a - 1;
        return a % 2 == 0 ? a + 1 : a;
    }

    public char NextChar(char minValue, char maxValue)
    {
        if (minValue >= maxValue)
            throw new ArgumentException("minValue cannot be greater than maxValue");
        return (char)rnd.Next(minValue, maxValue);
    }

    public bool NextBool(ushort probability)
    {
        return rnd.Next(100) < probability;
    }

    public DateTime NextDate(DateTime minValue, DateTime maxValue)
    {
        if (minValue >= maxValue)
            throw new ArgumentException("minValue cannot be greater than maxValue");
        return minValue.AddSeconds(NextDouble(0, (maxValue - minValue).TotalSeconds));
    }

    public override string ToString()
    {
        string str = "";
        int length = rnd.Next(1, 100 + 1);
        for (int i = 0; i < length; ++i)
        {
            str += rnd.Next(2) == 0 ? NextChar('a', (char)('z' + 1)) : NextChar('A', (char)('Z' + 1));
        }

        return str;
    }
}