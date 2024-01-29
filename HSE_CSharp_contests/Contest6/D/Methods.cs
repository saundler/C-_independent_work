internal class Methods
{
    internal static Student GetBestInMath(Student[] students)
    {
        var bestInMath = students[0];

        foreach (var student in students)
        {
            if (student.CompareTo(bestInMath) > 0)
            {
                bestInMath = student;
            }
        }

        return bestInMath;
    }

    internal static Student GetBestInPE(Student[] students)
    {
        var bestInPe = students[0];

        foreach (var student in students)
        {
            if (student.CompareTo(bestInPe) > 0)
            {
                bestInPe = student;
            }
        }

        return bestInPe;
    }
}