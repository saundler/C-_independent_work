using System;

internal class Program
{
    public static void Main()
    {
        var seed = int.Parse(Console.ReadLine());
        var random = new RandomExtension(seed);

        while (true)
        {
            switch (Console.ReadLine())
            {
                case "nd":
                    Utils.ProcessRequest<double>(random.NextDouble, Console.ReadLine(), 2);
                    break;
                case "ne":
                    Utils.ProcessRequest<int>(random.NextEven, Console.ReadLine(), 2);
                    break;
                case "no":
                    Utils.ProcessRequest<int>(random.NextOdd, Console.ReadLine(), 2);
                    break;
                case "nc":
                    Utils.ProcessRequest<char>(random.NextChar, Console.ReadLine(), 2);
                    break;
                case "nb":
                    Utils.ProcessRequest<ushort, bool>(random.NextBool, Console.ReadLine(), 1);
                    break;
                case "ndt":
                    Utils.ProcessRequest<DateTime>(random.NextDate, Console.ReadLine(), 2);
                    break;
                case "ts":
                    Console.WriteLine(random);
                    break;
                default:
                    return;
            }
        }
        
    }
}