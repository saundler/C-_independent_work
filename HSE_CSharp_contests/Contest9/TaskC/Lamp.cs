using System;
using System.Xml.Serialization;

[Serializable]
public class Lamp : Furniture
{
    [XmlElement("lifeTime")]
    public double LifeTime { get; set; } = 0;
    public Lamp() : base(0) { }
    public Lamp(long id, TimeSpan lifeTime) : base(id)
    {
        LifeTime = lifeTime.TotalSeconds;
    }
}