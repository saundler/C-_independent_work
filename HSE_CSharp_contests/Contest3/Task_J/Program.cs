using System;
using System.IO;
using System.Text.RegularExpressions;

public partial class Program
{
    private static string[] ReadCodeLines(string codePath)
    {
        return File.ReadAllLines(codePath);
    }
    private static string[] CleanCode(string[] codeWithComments)
    {
        string slash = @"\b\U+002F",
               startslash = "/*",
               stopslash = "*/";
        for(int i = 0; i < codeWithComments.Length; i++)
        {

        }
        return codeWithComments;
    }
    private static void WriteCode(string codeFilePath, string[] codeLines)
    {
        File.WriteAllLines(codeFilePath, codeLines);
    }
    public static void Main(string[] args)
    {
        string inputFilePath = "code.cs";
        string outputFilePath = "cleanCode.cs";
        string[] codeWithComments = ReadCodeLines(inputFilePath);
        string[] codeWithoutComments = CleanCode(codeWithComments);
        WriteCode(outputFilePath, codeWithoutComments);
    }
}