using System;
using System.Text.RegularExpressions;

internal partial class Program
{
    private static Sheep ParseSheep(string line)
    {
        int id;
        string name,
               sound;
        Regex regex = new Regex("Sheep +[\\w]+ with");
        Match match = regex.Match(line);
        name = match.Value[6..^5];
        regex = new Regex("Id +[\\d]+ makes");
        match = regex.Match(line);
        try
        {
            id = int.Parse(match.Value[3..^6]);
            if(id < 1 || id > 999)
            {
                throw new ArgumentException("Incorrect input");
            }
        }
        catch
        {
            throw new ArgumentException("Incorrect input");
        }
        sound = line.Split(" makes ")[1];
        return new Sheep(id, name, sound);
    }
}