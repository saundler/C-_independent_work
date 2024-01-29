internal class Program
{
    private static void Main(string[] args)
    {
        UserDb.ReadData("db.txt");
        Server.ProcessAuthorization("input.txt", "output.txt");
    }
}