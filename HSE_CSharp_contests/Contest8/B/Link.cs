internal class Link<T> 
{
    public T Value { get; set; }

    public Link<T>? Next { get; set; }

    public Link(T value, Link<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}