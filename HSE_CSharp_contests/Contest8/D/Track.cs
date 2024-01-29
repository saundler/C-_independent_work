using System;

internal class Track : IDownload
{
    public int size;
    public Track(int size, string trackName, string singer, string albumName, short length)
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