using System;
using System.Collections.Generic;

internal class ArchaeologicalFind
{
    public static int TotalFindsNumber = 0;
    private static int _findСounter = 0;
    private static List<int> _findIndex =  new List<int>();
    private int _age;
    private int _weight;
    private string _name;

    public ArchaeologicalFind(int age, int weight, string name)
    {
        if (age <= 0)
        {
            throw new ArgumentException("Incorrect age");
        }
        else if (weight <= 0)
        {
            throw new ArgumentException("Incorrect weight");
        }
        else if (name.Contains("?"))
        {
            throw new ArgumentException("Undefined name");
        }
        _age = age;
        _weight = weight;   
        _name = name;
    }
     
    private static bool IsFind(ArchaeologicalFind a, ArchaeologicalFind b)
    {
        if(a._name == b._name && a._age == b._age && a._weight == b._weight)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Добавляет находку в список.
    /// </summary>
    /// <param name="finds">Список находок.</param>
    /// <param name="archaeologicalFind">Находка.</param>
    public static void AddFind(List<ArchaeologicalFind> finds, ArchaeologicalFind archaeologicalFind)
    {
        TotalFindsNumber++;
        foreach (ArchaeologicalFind find in finds)
        {
            if(IsFind(find, archaeologicalFind))
            {
                return;
            }
        }
        _findIndex.Add(TotalFindsNumber - 1);
        finds.Add(archaeologicalFind);
        
    }
    public override string ToString()
    {
        _findСounter++;
        return $"{_findIndex[_findСounter - 1]} {_name} {_age} {_weight}"; 
    }
}
