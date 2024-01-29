internal sealed class Task
{
    public int Id { get; }
    public string Text { get; }
    public bool IsResolved { get; set; }
    public string Answer { get; set; }

    public Task(int id, string text)
    {
        Id = id;
        IsResolved = false;
        Text = text;
    }

    public override string ToString() =>
        $"id: {Id}; text: {Text}; status: {(IsResolved ? "resolved" : "unresolved")}; answer: {Answer}";
}