using System;
using System.Collections.Generic;

internal class Map<Tkey, Tvalue>
{
    List<(Tkey, Tvalue)> dict;
    public Map()
    {
        dict = new List<(Tkey, Tvalue)>();
    }

    public void Add(Tkey key, Tvalue value)
    {
        if (dict.Exists(t => ((IComparable)t.Item1).CompareTo(key) == 0))
            throw new ArgumentException($"An item with the same key has already been added. Key: {key}");
        dict.Add((key, value)); 
    }

    public Tvalue this[Tkey key]
    {
        set
        {
            int i = dict.FindIndex(t => ((IComparable)t.Item1).CompareTo(key) == 0);
            if (i == -1)
                throw new ArgumentException($"The given key '{key}' was not present in the map.");
            dict[i] = (dict[i].Item1, value);
        }
        get
        {
            int i = dict.FindIndex(t => ((IComparable)t.Item1).CompareTo(key) == 0);
            if (i == -1)
                throw new ArgumentException($"The given key '{key}' was not present in the map.");
            return dict[i].Item2;
        }
    }

    public bool Remove(Tkey key)
    {
        int i = dict.FindIndex(t => ((IComparable)t.Item1).CompareTo(key) == 0);
        if (i == -1)
            return false;
        dict.RemoveAt(i);
        return true;
    }

    public int Count
    {
        get { return dict.Count; }
    }
    
    public bool ContainsKey(Tkey key)
    {
        return dict.Exists(t => ((IComparable)t.Item1).CompareTo(key) == 0);
    }
}