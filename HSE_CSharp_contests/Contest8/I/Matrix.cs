using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class Matrix
{
    public int n, m;
    public int[,] matrix;
    public Matrix(int n, int m)
    {
        this.n = n;
        this.m = m;
        matrix = new int[n,m];
    }
    public void ReadMatrix()
    {
        int[] line;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (var j = 0; j < m; j++)
                matrix[i,j] = line[j];
        }
    }
    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.n != b.n || a.m != b.m)
            throw new ArithmeticException("Impossible");
        Matrix c = new Matrix(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++)
                c.matrix[i,j] = a.matrix[i, j] + b.matrix[i, j];
        return c;
    }
    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.n != b.n || a.m != b.m)
            throw new ArithmeticException("Impossible");
        Matrix c = new Matrix(a.n, a.m);
        for (int i = 0; i < a.n; i++)
            for (int j = 0; j < a.m; j++)
                c.matrix[i,j] = a.matrix[i,j] - b.matrix[i,j];
        return c;
    }
    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.m != b.n)
            throw new ArithmeticException("Impossible");
        Matrix c = new Matrix(a.n, b.m);
        for (int i = 0; i < a.n; i++)
            for (int k = 0; k < b.m; k++)
                for (int j = 0; j < a.m; j++)
                    c.matrix[i,k] += a.matrix[i,j] * b.matrix[j,k];
        return c;
    }
    public static Matrix operator ~(Matrix a)
    {
        Matrix b = new Matrix(a.m, a.n);
        for (int i = 0; i < a.m; i++)
            for (int j = 0; j < a.n; j++)
                b.matrix[i,j] = a.matrix[j,i];
        return b;
    }

    public static Matrix operator ^(Matrix a, int n)
    {
        if (a.n != a.m || n < 0)
            throw new ArithmeticException("Impossible");
        Matrix c = new Matrix(a.n, a.m);
        if (n == 0)
        {
            for (int i = 0; i < c.m; i++)
                for (int j = 0; j < c.m; j++)
                    if (i == j)
                        c.matrix[i, j] = 1;
            return c;
        }
        for (int i = 0; i < c.m; i++)
            for (int j = 0; j < c.m; j++)
                c.matrix[i, j] = a.matrix[i, j];
        for (int i = 0; i < n - 1; i++)
                c = c * a;
        return c;
    }

    public static Matrix MinMatr(int[,] matrix, int k)
    {
        int[,] minor = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
        List<int> list;
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            list = new List<int>();
            for (int j = 0; j < matrix.GetLength(0); j++)
                if (j != k)
                    list.Add(matrix[i + 1, j]);
            for (int j = 0; j < matrix.GetLength(0) - 1; j++)
                minor[i, j] = list[j];
        }
        Matrix minMatr = new Matrix(matrix.GetLength(0) - 1, matrix.GetLength(0) - 1);
        minMatr.matrix = minor;
        return minMatr;
    }
    public static int DetCalc(Matrix a)
    {
        int det = 0;
        int[,] matrix = a.matrix;
        if (a.n == 1)
            return a.matrix[0,0];
        if (a.n == 2)
            return a.matrix[0,0] * a.matrix[1,1] - a.matrix[0,1] * a.matrix[1,0];

        for (int i = 0; i < a.m; i++)
            det += (int)Math.Pow(-1, i) * matrix[0,i] * DetCalc(MinMatr(matrix, i));
        return det;
    }
    public static int operator !(Matrix a)
    {
        if (a.n != a.m)
            throw new ArithmeticException("Impossible");
        return DetCalc(a);

    }
    public override string ToString()
    {
        string str = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                str += matrix[i,j] + " ";
            str += "\n";
        }
        return str;
    }
}

