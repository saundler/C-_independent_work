using System;
using System.Collections.Generic;

public class Grassland
{
    public List<Sheep> sheeps;
    public Grassland(List<Sheep> sheep)
    {
        sheeps = sheep;
    }
    
    public List<Sheep> GetEvenSheep()
    {
        List<Sheep> result = new List<Sheep>();
        for (int i = 0; i < sheeps.Count; i++)
        {
            if (sheeps[i].id % 2 == 0)
            {
                result.Add(sheeps[i]);
            }
        }
        return result;
    }
    
    public List<Sheep> GetOddSheep()
    {
        List<Sheep> result = new List<Sheep>();
        for (int i = 0; i < sheeps.Count; i++)
        {
            if (sheeps[i].id % 2 != 0)
            {
                result.Add(sheeps[i]);
            }
        }
        return result;
    }

    public List<Sheep> GetSheepByName(string name)
    {
        List<Sheep> result = new List<Sheep>();
        for (int i = 0; i < sheeps.Count; i++)
        {
            if (sheeps[i].name.Contains(name))
            {
                result.Add(sheeps[i]);
            }
        }
        return result;
    }
}