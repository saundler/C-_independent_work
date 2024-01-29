using System;

internal class Game : IDownload
{
    public int size;
    public Game(int size, string name, string developer, string genre, short levels)
    {
        this.size = size;
    }
    public bool DownloadContent()
    {
        if (size <= Program.FreeSpace)
        {
            Console.WriteLine($"{size}/{size} MB");
            Program.FreeSpace -= size;
            return true;
        }
        else
        {
            Console.WriteLine($"{Program.FreeSpace}/{size} MB");
            Program.FreeSpace = 0;
            return false;
        }

    }
}