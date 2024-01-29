using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal static class Analytics
{
    public static void WriteStudentsWithGpaNoLessThanAverage(List<Student> students, string pathToOutputFile, double gpa)
    {
        using (StreamWriter sw = new StreamWriter(pathToOutputFile))
        {
            sw.WriteLine($"{gpa:f2}");
            foreach (Student student in students)
            {
                if (student.GPA >= gpa)
                {
                    sw.WriteLine(student);
                }
            }
        }
    }

    public static double FindGpa(List<Student> students)
    {
        double sum = 0;
        foreach (Student student in students)
            sum += student.GPA;
        return sum / students.Count;
    }
}