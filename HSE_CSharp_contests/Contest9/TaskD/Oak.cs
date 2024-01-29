using System;
using System.Xml.Serialization;

[Serializable]
public class Oak : Tree
{
    [XmlElement("acornCount")]
    public int AcronCount { get; set; }
    public Oak() : base() { AcronCount = 0; } 
    public Oak(int height, int age, int acornCount) : base(height, age)
    {
        AcronCount = acornCount;
    }
    public override string ToString()
    {
        return "Oak" + base.ToString() + $"acorn:{AcronCount}";
    }
}