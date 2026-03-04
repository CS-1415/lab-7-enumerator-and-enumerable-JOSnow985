namespace Lab07;

public class DNode<T> 
{
    public T Value { get; set; }
    public DNode<T>? Previous { get; set; }
    public DNode<T>? Next { get; set; }

    // Basic Constructor
    public DNode(T value)
    {
        Value = value;
    }
}
