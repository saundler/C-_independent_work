using System;

public delegate void Calculator(ref double x); 

class StackCalculator
{
    public static void Sin(ref double x) => x = Math.Sin(x);
    public static void Cos(ref double x) => x = Math.Cos(x);
    public static void Tan(ref double x) => x = Math.Tan(x);
    public static void CreateRules(int[] args)
    {
        foreach(int i in args)
            switch (i)
            {
                case 0:
                    Program.calculator += Sin;
                    break;
                case 1:
                    Program.calculator += Cos;
                    break;
                case 2:
                    Program.calculator += Tan;
                    break;
            }
    }
}