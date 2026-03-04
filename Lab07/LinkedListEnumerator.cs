using System.Collections;

namespace Lab07;

public class LinkedListEnumerator<T> : IDisposable, IEnumerator, IEnumerator<T>
{
    public LinkedListEnumerator(DNode<T> node)
    {
    }

    
    public T Current => throw new NotImplementedException();

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
