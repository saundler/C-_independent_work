using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var students = new List<Student>(n);

        for (int i = 0; i < n; i++)
        {
            try
            {
                students.Add(Student.Parse(Console.ReadLine()));
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        Group studentGroup;

        try
        {
            studentGroup = new Group(students.ToArray());
        }
        catch (ArgumentException argumentException)
        {
            Console.WriteLine(argumentException.Message);
            return;
        }

        Console.WriteLine(studentGroup[studentGroup.IndexOfMinGrade()]);
        Console.WriteLine(studentGroup[studentGroup.IndexOfMaxGrade()]);
    }
}