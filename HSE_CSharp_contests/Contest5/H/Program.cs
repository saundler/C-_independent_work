using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

internal class Coordinate
{
    public int x;
    public int y;
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

internal class Segment
{
    public readonly Coordinate start;
    public readonly Coordinate end;
    public Segment(Coordinate start, Coordinate end)
    {
        this.start = start;
        this.end = end;
    }
    public static bool IsCross(Segment ver, Segment hor)
    {
        if (ver.start.y > ver.end.y)
        {
            ver = new Segment(ver.end, ver.start);
        }
        if (hor.start.x > hor.end.x)
        {
            hor = new Segment(hor.end, hor.start);
        }
        if (hor.start.x <= ver.start.x && ver.start.x <= hor.end.x && ver.start.y <= hor.start.y && hor.start.y <= ver.end.y)
        {
            return true;
        }
        return false;

    }
    public static bool IsCrossVer(Segment ver1, Segment ver2)
    {
        Segment swapperr;
        if (ver1.start.x == ver2.start.x)
        {
            if (ver1.start.y > ver1.end.y)
            {
                ver1 = new Segment(ver1.end, ver1.start);
            }
            if (ver2.start.y > ver2.end.y)
            {
                ver2 = new Segment(ver2.end, ver2.start);
            }
            if (ver2.end.y > ver1.end.y)
            {
                swapperr = ver1;
                ver1 = ver2;
                ver2 = swapperr;
            }
            if (ver1.end.y >= ver2.end.y && ver1.start.y <= ver2.end.y)
            {
                return true;
            }
        }
        return false;
    }
}

internal class Robot
{
    public List<Segment> way;
    public int[] length;
    public Robot(int[] length)
    {
        this.length = length;
        way = new List<Segment>();
        way.Add(new Segment(new Coordinate(0, 0), new Coordinate(0, length[0])));
    }
    public void BuildWay()
    {
        for (int i = 1; i < length.Length; i++)
        {
            if (i % 4 == 1)
            {
                way.Add(new Segment(way[i - 1].end, new Coordinate(way[i - 1].end.x - length[i], way[i - 1].end.y)));
            }
            else if (i % 4 == 2)
            {
                way.Add(new Segment(way[i - 1].end, new Coordinate(way[i - 1].end.x, way[i - 1].end.y - length[i])));
            }
            else if (i % 4 == 3)
            {
                way.Add(new Segment(way[i - 1].end, new Coordinate(way[i - 1].end.x + length[i], way[i - 1].end.y)));
            }
            else
            {
                way.Add(new Segment(way[i - 1].end, new Coordinate(way[i - 1].end.x, way[i - 1].end.y + length[i])));
            }
        }
    }

    public bool FindCross()
    {
        for (int i = 0; i < way.Count; i += 2)
        {
            if(i + 3 < way.Count && Segment.IsCross(way[i], way[i + 3]))
            {
                return true;
            }
            else if (i + 5 < way.Count && Segment.IsCross(way[i], way[i + 5]))
            {
                return true;
            }
            else if (i != 0 && Segment.IsCrossVer(way[i], way[0]))
            {
                return true;
            }
        }
        return false;
    }
}
internal static class Program
{
    private static void Main(string[] args)
    {
        Robot robot = new Robot(Console.ReadLine().Split().Select(int.Parse).ToArray());
        robot.BuildWay();
        if (robot.FindCross())
        {
            Console.WriteLine("Cross");
        }
        else
        {
            Console.WriteLine("No cross");
        }
    }
}