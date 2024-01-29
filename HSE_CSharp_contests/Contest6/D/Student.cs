using System;
using System.Linq;

internal struct Student 
{
    public int Id;
    public int Height;
    public int Math;
    public int Eng;
    public int Pe;
    static bool fl;

    public Student(int id, int height, int math, int english, int PE)
    {
        Id = id;
        Height = height;
        Math = math;
        Eng = english;
        Pe = PE;
        fl = false;
    }

    internal static Student Parse(string v)
    {
        int[] input = Array.ConvertAll(v.Split(' '), int.Parse);
        return new Student(input[0], input[1], input[2], input[3], input[4]);
    }
    public override string ToString()
    {
        fl = true;
        return Id.ToString();
    }
    public int CompareTo(Student x)
    {
        if (fl)
        {
            if ((this.Pe > x.Pe) || (x.Pe == this.Pe && this.Height > x.Height))
            {
                return 1;
            }
        }
        else
        {
            if ((this.Math > x.Math) || (x.Math == this.Math && this.Eng > x.Eng))
                return 1;
        }
        return 0;
    }
}