using System;

public partial class Program
{
    private static void GetLetterDigitCount(string line, out int digitCount, out int letterCount)
    {
        line = line.ToLower();
        digitCount = 0;
        letterCount = 0;    
        foreach (char ch in line)
        {
            if((int)ch >= 97 && (int)ch <= 122)
            {
                letterCount++;
            }
            else if ((int)ch >= 48 && (int)ch <= 57)
            {
                digitCount++;
            }
        }
    }
}