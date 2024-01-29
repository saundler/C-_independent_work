internal class Program
{
    private static void Main(string[] args)
    {
        var students = Deserializer.DeserializeStudents("input.bin");
        Analytics.WriteStudentsWithGpaNoLessThanAverage(students, "output.txt", Analytics.FindGpa(students));
    }
}