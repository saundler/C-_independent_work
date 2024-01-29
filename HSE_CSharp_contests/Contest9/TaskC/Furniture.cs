using System;
using System.Xml.Serialization;

[XmlInclude(typeof(Lamp))]
[XmlInclude(typeof(Bed))]
[XmlInclude(typeof(Pillow))]
[Serializable]
public abstract class Furniture
{
    [XmlElement("id")]
    public long Id { get; set; } = 0;
    protected Furniture(long id)
    {
        Id = id;
    }
}