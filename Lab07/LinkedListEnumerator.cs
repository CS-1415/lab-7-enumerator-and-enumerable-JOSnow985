using System.Collections;

namespace Lab07;

public class LinkedListEnumerator<T> : IDisposable, IEnumerator, IEnumerator<T>
{
    // Properties
    public DNode<T>? FirstNode { get; }
    public DNode<T>? CurrentNode { get; private set; }

    // Constructor
    public LinkedListEnumerator(DNode<T>? node) => FirstNode = node;

    // Interface implementations
    public T Current
    {
        get
        {
            // Is it okay to use "!" here? We're returning the default for the type we're using
            // so it should be okay to expect a null if we're using a reference type?
            if (CurrentNode is null) 
                return default!;
            else
                return CurrentNode.Value;
        }
    }

    object IEnumerator.Current => Current!;     // Is it okay to use "!" here?

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

    public void Reset()
    {
        throw new NotImplementedException();
    }

    // Left empty as instructed
    public void Dispose(){}
}

/*
    // --- IEnumerator ---
    // Summary:
    //     Gets the element in the collection at the current position of the enumerator.
    // Returns:
    //     The element in the collection at the current position of the enumerator.
    //public object Current { get; }
    // Summary:
    //     Advances the enumerator to the next element of the collection.
    // Returns:
    //     true if the enumerator was successfully advanced to the next element; false if
    //     the enumerator has passed the end of the collection.
    // Exceptions:
    //   T:System.InvalidOperationException:
    //     The collection was modified after the enumerator was created.
    public bool MoveNext()
{
    return true;
}
    // Summary:
    //     Sets the enumerator to its initial position, which is before the first element
    //     in the collection.
    // Exceptions:
    //   T:System.InvalidOperationException:
    //     The collection was modified after the enumerator was created.
    //   T:System.NotSupportedException:
    //     The enumerator does not support being reset.
    public void Reset(){}

    // -- IEnumerator<T>
    //
    // Summary:
    //     Gets the element in the collection at the current position of the enumerator.
    //
    //
    // Returns:
    //     The element in the collection at the current position of the enumerator.
    public T Current { get; }

    // --- IDisposable ---
    // Summary:
    //     Performs application-defined tasks associated with freeing, releasing, or resetting
    //     unmanaged resources.
    public void Dispose() {}
*/