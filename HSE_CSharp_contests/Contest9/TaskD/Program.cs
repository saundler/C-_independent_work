﻿using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var xmlSerializer = new XmlSerializer(typeof(List<Tree>));
        
        using var fs = new FileStream("trees.xml", FileMode.OpenOrCreate, FileAccess.Read);
        var trees = (List<Tree>)xmlSerializer.Deserialize(fs);
        var maxTree = trees.Max();
        var allMax = trees.FindAll(t => t.CompareTo(maxTree) == 0);
        allMax.ForEach(Console.WriteLine);
    }
}