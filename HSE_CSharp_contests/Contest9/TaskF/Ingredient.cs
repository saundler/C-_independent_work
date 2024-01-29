using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

[DataContract]
[KnownType(typeof(Meat))]
[KnownType(typeof(Vegetable))]
internal class Ingredient : IComparable
{
    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public int TimeToCook { get; set; }
    public Ingredient(string name, int timeToCook)
    {
        Name = name;
        TimeToCook = timeToCook;
    }
    public int CompareTo(object? obj)
    {
        return ((Ingredient)obj).TimeToCook - TimeToCook;
    }
    public override string ToString()
    {
        return Name;
    }
}