using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class ReadWriter
{
    public static (char, char) GetMostAndLeastCommonLetters(string path)
    {
        List<char> charList = new List<char>();
        List<int> intList = new List<int>();
        string str;
        int index, minIndex, n;
        using (StreamReader sr = new StreamReader(path))
        {
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine().ToLower().Replace(" ", "");
                for (int i = 0; i < str.Length; i++)
                {
                    index = charList.FindIndex(a => a == str[i]);
                    if (index != -1)
                    {
                        intList[index]++;
                    }
                    else if ((64 < str[i] && str[i] < 91) || (96 < str[i] && str[i] < 123))
                    {
                        charList.Add(str[i]);
                        intList.Add(1);
                    }
                }
            }
        }
        if (intList.Count == 0)
            return (' ', ' ');
        n = intList.Max();
        index = intList.FindIndex(a => a == n);
        n = intList.Min();
        minIndex = intList.FindIndex(a => a == n);
        return (charList[index], charList[minIndex]);
    }

    public static void ReplaceMostRareLetter((char, char) leastAndMostCommon, string inputPath, string outputPath)
    {
        char[] str;
        using (StreamReader sr = new StreamReader(inputPath))
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine().ToCharArray();
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].ToString().ToLower() == leastAndMostCommon.Item2.ToString())
                    {
                        if (str[i].ToString().ToLower() == str[i].ToString())
                            str[i] = leastAndMostCommon.Item1;
                        else
                            str[i] = leastAndMostCommon.Item1.ToString().ToUpper()[0];
                    }
                }
                sw.WriteLine(string.Join("", str));
            }
        }
    }
}