using System;

internal class Group
{
    public Student[] students;
    public Student this[int index]
    {
        get
        {
            return students[index];
        }
    }


    public Group(Student[] students)
    {
        if(students.Length < 5)
        {
            throw new ArgumentException("Incorrect group");
        }
        this.students = students;
    }

    public int IndexOfMaxGrade()
    {
        int max = -1,
            index = 0;
        for(int i = 0; i < students.Length; i++)
        {
            if (int.Parse(students[i].grade) > max)
            {
                max = int.Parse(students[i].grade);
                index = i;
            }
        }
        return index;
    }
    
    public int IndexOfMinGrade()
    {
        int min = 11,
            index = 0 ;
        for (int i = 0; i < students.Length; i++)
        {
            if (int.Parse(students[i].grade) < min)
            {
                min = int.Parse(students[i].grade);
                index = i;
            }
        }
        return index;
    }
}