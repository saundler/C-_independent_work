using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public class Bed : Furniture
{
    [XmlElement("pillow")]
    public List<Pillow> Pillows { get; set; } = new List<Pillow>();
    public Bed() : base(0) { } 
    public Bed(long id, List<Pillow> pillows) : base(id)
    {
        Pillows = pillows;
    }
}