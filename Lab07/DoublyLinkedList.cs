namespace Lab06;

public class DoublyLinkedList<T> : IDoubleEndedCollection<T> 
{
    private DNode<T>? _head = null;
    private DNode<T>? _tail = null;
    public int Length { get; private set; } = 0;
    // Throwing an exception if we try to get First or Last on an empty list, not sure if this is correct.
    public T First => Length == 0 ? throw new InvalidOperationException("List Empty!") : _head!.Value;
    public T Last => Length == 0 ? throw new InvalidOperationException("List Empty!") : _tail!.Value;

    public void AddLast(T value)
    {
        DNode<T> newNode = new(value);

        // If our list is empty, newNode is now both head and tail
        if (Length == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Not empty, our previous tail's new next is newNode, newNode's previous is current tail, new tail is newNode
        else
        {
            _tail!.Next = newNode;      // If our list isn't empty, _tail shouldn't be null
            newNode.Previous = _tail;
            _tail = newNode;
        }
        Length++;
    }
    public void AddFirst(T value)
    {
        DNode<T> node = new(value);
        if (Length == 0)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            _head!.Previous = node;
            node.Next = _head;
            _head = node;
        }
        Length++;
    }
    public void RemoveFirst()
    {
        if (Length == 0)
            return;

        if (Length == 1)
            NullList();
        else
        {
            _head!.Next!.Previous = null; // If our list isn't empty or one node, _head and _head.Next shouldn't be null
            _head = _head.Next;
            Length--;
        }
    }     
    public void RemoveLast()
    {
        if (Length == 0)
            return;

        if (Length == 1) 
            NullList();
        else
        {
            _tail!.Previous!.Next = null;
            _tail = _tail.Previous;
            Length--;
        }
    }
    private void NullList()
    {
        _head = null;
        _tail = null;
        Length = 0;
    }
    public void InsertAfter(DNode<T> node, T value)
    {
        if (node == null)
            return;

        if (Length == 0)
        {
            AddFirst(value);
            return;
        }

        // Setting up our new node
        DNode<T> insertNode = new(value);
        insertNode.Previous = node;
        insertNode.Next = node.Next;

        if (node.Next == null)
            _tail = insertNode; // If the node doesn't have a next, it was the tail
        else
            node.Next.Previous = insertNode;

        node.Next = insertNode;

        Length++;
    }
    public void RemoveByValue(T value)
    {
        DNode<T> currentNode = _head!;

        while (currentNode != null) // Don't need a length check because if it's null, the loop terminates anyway
        {
            if (currentNode.Value!.Equals(value))
            {
                if (currentNode.Previous != null)
                    currentNode.Previous.Next = currentNode.Next;
                else
                    _head = currentNode.Next;       // If we removed the head, update it

                if (currentNode.Next != null)
                    currentNode.Next.Previous = currentNode.Previous;
                else
                    _tail = currentNode.Previous;   // Same for the tail
                
                Length--;

                return;
            }

            currentNode = currentNode.Next!;
        }
    }
    public void ReverseList()
    {
        if (Length < 2) throw new InvalidOperationException("List can't be reversed without enough entries!");

        DNode<T> current = _head!;

        while (current != null)
        {
            // Swap the values
            (current.Next, current.Previous) = (current.Previous, current.Next);
            // New current node is the previous node, because we reversed them.
            current = current!.Previous!;
        }

        (_head, _tail) = (_tail, _head);
    }
}
