using System.Collections;

namespace Lab07;

public class LinkedListEnumerator<T> : IDisposable, IEnumerator, IEnumerator<T>
{
    // Properties
    public DNode<T>? FirstNode { get; }
    public DNode<T>? CurrentNode { get; private set; }
    // Constructor
    public LinkedListEnumerator(DNode<T>? node) => FirstNode = node;

    // Is it okay to use "!" for these two? We're returning the default for the type we're using
    // so it should be okay to expect a null if we're using a reference type?
    public T Current => CurrentNode is null ? default! : CurrentNode.Value;
    object IEnumerator.Current => Current!;

    // True if we make it to the next item, false if we run out of items to move to
    public bool MoveNext()
    {
        // If our current node is null, then we're starting out on FirstNode
        if (CurrentNode is null)
        {
            CurrentNode = FirstNode;
            return true;
        }
        
        // Our current node isn't null, if next isn't, that's the new current node
        if (CurrentNode.Next is not null)
        {
            CurrentNode = CurrentNode.Next;
            return true;
        }
        else
            return false;
    }

    // If I understand the definition correctly, this should "Reset" us to before the first element
    // If we try to MoveNext from here we will be at FirstNode.
    public void Reset() => CurrentNode = null;

    // Left empty as instructed
    public void Dispose(){}
}
