using System;

internal class Movie : IDownload
{
    public int size;
    public Movie(int size, string name, short duration, short releaseYear, string genre)
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