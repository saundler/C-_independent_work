using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Logger logger = new Logger();
        using (FileStream fs = new FileStream("logs.txt", FileMode.OpenOrCreate))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Print method = null;
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "Console")
                    method = Console.WriteLine;
                else if (command[0] == "File")
                    method = sw.WriteLine;
                else
                    throw new ArgumentException("Некорректная команда");
                logger.MakeLog(method, command[1]);
            }

            logger.OutputLogs();
        }

        Console.WriteLine("Logs in file:");
        Console.WriteLine(File.ReadAllText("logs.txt"));
        File.Delete("logs.txt");
    }
}