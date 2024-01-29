using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

internal class SimpleFurnitureSerializer
{
    public void Serialize(List<Furniture> furniture, string outputPath)
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Furniture>));
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(sw, settings);
            sw.WriteLine("<?xml version=\"1.0\"?>");
            xml.Serialize(writer, furniture);
        }
    }
}