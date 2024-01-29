using System;

internal class Content : IDownload
{
    public int size;
    public Content(int size, string information)
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