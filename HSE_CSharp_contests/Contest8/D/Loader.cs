using System;
using System.Collections.Generic;

internal static class Loader
{
    private static List<string> ls = new List<string>();
    
    public static int GAMES = 0;
    public static int CONTENT = 0;
    public static int MOVIES = 0;
    public static int TRACKS = 0;
    public static void Download(List<IDownload> downloadsQueue)
    {
        List<char> por = new List<char>();
        for(int i = 0; i < downloadsQueue.Count; i++)
        {
            if(!downloadsQueue[i].DownloadContent())
            {
                Console.WriteLine("Not enough free space!");
                break; 
            }
            if (downloadsQueue[i] is Download<Movie>)
            {
                if (!por.Contains('M'))
                    por.Add('M');
                MOVIES++;
            }
            else if (downloadsQueue[i] is Download<Game>)
            {
                if (!por.Contains('G'))
                    por.Add('G');
                GAMES++;
            }
            else if (downloadsQueue[i] is Download<Content>)
            {
                if (!por.Contains('C'))
                    por.Add('C');
                CONTENT++;
            }
            else if (downloadsQueue[i] is Download<Track>)
            {
                if (!por.Contains('T'))
                    por.Add('T');
                TRACKS++;
            }
        }
        Console.WriteLine("\nDownloaded content:");
        for(int i = 0; i < por.Count; i++)
        {
            if (por[i] == 'M')
                    Console.WriteLine($"Movie: {MOVIES}");
            if (por[i] == 'C')
                Console.WriteLine($"Content: {CONTENT}");
            if (por[i] == 'T')
                Console.WriteLine($"Track: {TRACKS}");
            if (por[i] == 'G')
                Console.WriteLine($"Game: {GAMES}");
        }
        
    }
}