using System;
using System.Collections.Generic;

[Serializable]
internal class Student
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int GroupNumber { get; set; }
    public List<int> Grades { get; set; }
    public Student(string name, string lastName, int groupNumber, List<int> grades)
    {
        Name = name;
        LastName = lastName;
        GroupNumber = groupNumber;
        Grades = grades;
    }
    public static Student ParseStudent(string str)
    {
        string[] strings = str.Split(' ');
        List<int> grades = new List<int>();
        for (int i = 3; i < strings.Length; i++)
            grades.Add(int.Parse(strings[i]));
        return new Student(strings[0], strings[1], int.Parse(strings[2]), grades);
    }
}