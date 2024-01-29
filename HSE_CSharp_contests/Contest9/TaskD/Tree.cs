using System;
using System.Xml.Serialization;

[XmlInclude(typeof(Ash))]
[XmlInclude(typeof(Oak))]
[Serializable]
public class Tree : IComparable
{
    [XmlElement("height")]
    public int Height { get; set; }
    [XmlElement("age")]
    public int Age { get; set; }
    public Tree () { Height = 0; Age = 0; }
    public Tree(int height, int age)
    {
        Height = height;
        Age = age;
    }
    public int CompareTo(object? obj)
    {
        return Height - ((Tree)obj).Height;
    }
    public override string ToString()
    {
        return $" with height:{Height} age:{Age} ";
    }
}