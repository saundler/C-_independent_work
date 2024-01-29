using System;
using System.Xml.Serialization;

[Serializable]
public class Pillow : Furniture
{
    [XmlElement("isRuined")]
    public string IsRuined { get; set; } = "No";
    public Pillow() : base(0) { }
    public Pillow(long id, bool isRuined) : base(id)
    {
        if (isRuined)
            IsRuined = "Yes";
        else
            IsRuined = "No";
    }
}