internal class Program
{
    private const string InputPath = "input.txt";
    
    private const string OutputPath = "output.txt";

    private static void Main(string[] args)
    {
        var mostAndLeastCommon = ReadWriter.GetMostAndLeastCommonLetters(InputPath);
        ReadWriter.ReplaceMostRareLetter(mostAndLeastCommon, InputPath, OutputPath);
    }
}