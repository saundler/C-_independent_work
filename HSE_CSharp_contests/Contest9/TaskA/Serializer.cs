using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

internal static class Serializer
{
    static List<Student> students = new List<Student>();
    public static void ReadStudents(string pathToInputFile)
    {

        using (StreamReader sr = new StreamReader(pathToInputFile))
        {
            while (!sr.EndOfStream)
                students.Add(Student.ParseStudent(sr.ReadLine()));
        }

    }

    public static void SerializeStudents(string pathToOutputFile)
    {
        using (FileStream fs = new FileStream(pathToOutputFile, FileMode.OpenOrCreate, FileAccess.Write))
        {
            new BinaryFormatter().Serialize(fs, students);
        }
    }
}