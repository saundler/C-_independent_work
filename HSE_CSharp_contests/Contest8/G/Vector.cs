using System;
using System.Linq;
using System.Numerics;

public struct Vector
{
    double x;
    double y;
    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    
    public double GetLength()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public double GetAngleCos(Vector a)
    {
        return (Math.Pow(GetLength(), 2) + Math.Pow(a.GetLength(), 2) - Math.Pow((a - this).GetLength(), 2)) / (2 * a.GetLength() * GetLength());
    }
    
    public double GetVectorMultiplication(Vector a)
    {
        return a.GetLength() * GetLength() * Math.Sqrt(1 - Math.Pow(GetAngleCos(a), 2));
    }

    public static void ReadVectors(out Vector vectorA, out Vector vectorB)
    {
        double[] arr;
        while (true)
        {
            try
            {
                arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
                if (arr.Length != 4)
                    throw new Exception();
                break;
            }
            catch
            {
                Console.WriteLine("Incorrect data!");
                continue;
            }
        }
        vectorA = new Vector(arr[0], arr[1]);
        vectorB = new Vector(arr[2], arr[3]);
    }
    
    public static void ReadVectorAndNumber(out Vector vector, out double number)
    {
        double[] arr;
        while (true)
        {
            try
            {
                arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
                if (arr.Length != 3)
                    throw new Exception();
                break;
            }
            catch
            {
                Console.WriteLine("Incorrect data!");
                continue;
            }
        }
        vector = new Vector(arr[0], arr[1]);
        number = arr[2];
    }

    public static Vector ReadVector()
    {
        double[] arr;
        while (true)
        {
            try
            {
                arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
                if (arr.Length != 2)
                    throw new Exception();
                break;
            }
            catch
            {
                Console.WriteLine("Incorrect data!");
                continue;
            }
        }
        return new Vector(arr[0], arr[1]);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y);
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.x - b.x, a.y - b.y);
    }
    public static double operator *(Vector a, Vector b)
    {
        return a.GetLength() * b.GetLength() * b.GetAngleCos(a);
    }
    public static Vector operator *(double a, Vector b)
    {
        return new Vector(b.x * a, b.y * a);
    }
    public override string ToString()
    {
        return $"{x} {y}";
    }
}