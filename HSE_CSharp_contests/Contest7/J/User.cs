internal class User
{
    public string UserName { get; set; }
    public int Index;

    public User(string userName)
    {
        UserName = userName;
    }

    public void IncreaseIndex(int count)
    {
        Index += count;
    }

    public override string ToString()
    {
        return UserName;
    }
}