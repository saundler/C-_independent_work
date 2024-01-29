using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

internal static class Deserializer
{
    public static List<Student> DeserializeStudents(string pathToFile)
    {
        List<Student> students;
        using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate, FileAccess.Read))
        {
            students = (List<Student>)new BinaryFormatter().Deserialize(fs);
        }
        return students;
    }
}