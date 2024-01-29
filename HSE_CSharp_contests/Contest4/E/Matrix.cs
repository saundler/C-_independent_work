using System;
using System.IO;
using System.Linq;

internal sealed class Matrix
{
    private int[][] fileMatrix;
    public Matrix(string filename)
    {
        SumOfEvenElements = 0;
        string[] rowes = File.ReadAllLines(filename);
        fileMatrix = new int[rowes.Length][];
        for (int i = 0; i < rowes.Length; i++)
        {
            fileMatrix[i] = rowes[i].Split(';').Select(int.Parse).ToArray();
            
        }
        for(int i = 0; i < fileMatrix.Length; i++)
        {
            for (int j = 0; j < fileMatrix[i].Length; j++)
            {
                if(fileMatrix[i][j] % 2 == 0)
                {
                    SumOfEvenElements += fileMatrix[i][j];
                }
            }
        }
    }

    public override string ToString()
    {
        string a = "";
        foreach(int[] row in fileMatrix)
        {
            a += string.Join("\t", row);
            a += "\n";
        }
        return a;
    }

    public int SumOfEvenElements;

}