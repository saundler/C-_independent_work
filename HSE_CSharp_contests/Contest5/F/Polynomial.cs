using System;
using System.Collections.Generic;
using System.Linq;

public class Coople
{
    public int value;
    public int power;
    public Coople(int value, int power)
    {
        this.value = value;
        this.power = power;
    }
    public static Coople operator +(Coople a, Coople b)
    {
        if(a.power == b.power)
            return new Coople(a.value + b.value, a.power);
        throw new Exception();
    }
    public static Coople operator -(Coople a, Coople b)
    {
        if (a.power == b.power)
            return new Coople(a.value - b.value, a.power);
        throw new Exception();
    }
    public static Coople operator *(Coople a, int b)
    {
       return new Coople(a.value * b, a.power);
    }
    public static Coople operator *(Coople a, Coople b)
    {
        return new Coople(a.value * b.value, a.power + b.power);
    }
    public override string ToString()
    {
        string str = "";
        if(value == 0)
        {
            return str;
        }
        str += "+ ";
        if(power == 0)
        {
            str += value;
        }
        else if (power == 1)
        {
            str += value + "x ";
        }
        else
        {
            str += $"{value}x{power} ";
        }
        return str;
    }
}


internal sealed class Polynomial
{
    public List<Coople> cop;
    public Polynomial(int[] a)
    {
        cop = new List<Coople>();
        for (int i = 0; i < a.Length; i++)
        {
            cop.Add(new Coople(a[i], i));
        }
    }

    public static bool TryParsePolynomial(string line, out Polynomial polynomial)
    {
        polynomial = null;
        try
        {
            polynomial = new Polynomial(line.Split(' ').Select(int.Parse).ToArray());
        }
        catch
        {
            return false;
        }
        return true;
    }
    private static void Adder(ref Polynomial a, int n)
    {
        int b = a.cop[^1].power;
        for (int i = 0; i < n; i++)
        {
            a.cop.Add(new(0, ++b));
        }
    }
    private static void Equalizer(ref Polynomial a, ref Polynomial b)
    {
        int n = a.cop.Count - b.cop.Count;
        if (n > 0)
        {
            Adder(ref b, n);
        }
        else if (n < 0)
        {
            Adder(ref a, -1 * n);
        }
    }
    public static Polynomial operator +(Polynomial a, Polynomial b)
    {
        Equalizer(ref a, ref b);
        Polynomial c = new Polynomial(new int[0]);
        for(int i = 0; i < a.cop.Count; i++)
        {
            c.cop.Add(a.cop[i] + b.cop[i]);
        }
        return c;
    }
    public static Polynomial operator -(Polynomial a, Polynomial b)
    {
        Equalizer(ref a, ref b);
        Polynomial c = new Polynomial(new int[0]);
        for (int i = 0; i < a.cop.Count; i++)
        {
            c.cop.Add(a.cop[i] - b.cop[i]);
        }
        return c;
    }
    public static Polynomial operator *(Polynomial a, int b)
    {
        Polynomial c = new Polynomial(new int[0]);
        for (int i = 0; i < a.cop.Count; i++)
        {
            c.cop.Add(a.cop[i] * b);
        }
        return c;
    }
    public static Polynomial operator *(Polynomial a, Polynomial b)
    {
        Equalizer(ref a, ref b);
        Polynomial c = new Polynomial(new int[0]);
        for (int i = 0; i < a.cop.Count; i++)
        {
            for (int j = 0; j < b.cop.Count; j++)
            {
                c.cop.Add(a.cop[i] * b.cop[j]);
            }
        }
        c.cop = new List<Coople>(c.cop.OrderBy(cop => cop.power).ToArray());
        for (int i = 0; i < c.cop.Count; i++)
        {
            if (i + 1 != c.cop.Count && c.cop[i].power == c.cop[i + 1].power)
            {
                c.cop[i] += c.cop[i + 1];
                c.cop.RemoveAt(i + 1);
                i--;
            }
        }
        return c;
    }
    public override string ToString()
    {
        string str = "";
        for(int i = cop.Count - 1; i >= 0; i--)
        {
            str += cop[i].ToString();
        }
        if (str == "")
            return "0";
        return str.Substring(2);
    }
}