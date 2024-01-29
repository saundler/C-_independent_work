using System;
using System.Xml.Serialization;

[Serializable]
public class Ash : Tree
{
    [XmlElement("leafCount")]
    public int LeafCount { get; set; }
    public Ash() : base() { LeafCount = 0; }
    public Ash(int height, int age, int leafCount) : base(height, age)
    {
        LeafCount = leafCount;
    }
    public override string ToString()
    {
        return "Ash" + base.ToString() + $"leaf:{LeafCount}";
    }
}