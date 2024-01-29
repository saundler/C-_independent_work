using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] params1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Matrix matrix1 = new Matrix(params1[0], params1[1]);
        matrix1.ReadMatrix();
        int[] params2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Matrix matrix2 = new Matrix(params2[0], params2[1]);
        matrix2.ReadMatrix();
        int n = int.Parse(Console.ReadLine());
        try
        {
            Console.WriteLine(matrix1 + matrix2);
        }
        catch(ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            Console.WriteLine(matrix1 - matrix2);
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            Console.WriteLine(matrix1 * matrix2);
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            Console.WriteLine(~matrix1);
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            Console.WriteLine(matrix1 ^ n);
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            Console.WriteLine(!matrix1);
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}