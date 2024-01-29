using System;

internal class Student
{
    public string name;
    public string grade;
    private Student(string name, string grade)
    {
        try
        {
            int.Parse(grade);
            if (name.Length < 3 || name[0].ToString() == name[0].ToString().ToLower())
            {
                throw new ArgumentException("Incorrect name");
            }
            if (int.Parse(grade) > 10 || int.Parse(grade) < 0)
            {
                throw new ArgumentException("Incorrect mark");
            }
        }
        catch (FormatException)
        {
            throw new ArgumentException("Incorrect input mark");
        }
        this.name = name;
        this.grade = grade;
        
    }
    
    public static Student Parse(string line)
    {
        string[] a = line.Split(' ');
        return new Student(a[0], a[1]);
    }
    public override string ToString()
    {
        return $"{name} got a grade of {grade}.";
    }
}