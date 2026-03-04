using Lab07;

DoublyLinkedList<string> list = new();
while (true)
{
    Console.Clear();
    PrintMenu();
    switch (Console.ReadKey(true).Key)
    {
        // Escape ends the program
        case ConsoleKey.Escape:
            return;
        case ConsoleKey.B:
            Console.WriteLine("Add to beginning");
            list.AddFirst(CollectString());
            break;
        case ConsoleKey.E:
            Console.WriteLine("Add to end");
            list.AddLast(CollectString());
            break;
        // If the list printing needs to be something the user prompts, use this instead
        // case ConsoleKey.P:
        //     if (list.Length is not 0)
        //     {
        //         Console.Clear();
        //         foreach(string s in list)
        //             Console.WriteLine(s);
        //         Console.ReadKey(true);
        //     }
        //     break;
        default:
            break;
    }
}

// --- Methods ---
void PrintMenu()
{
    // Print some kind of header
    Console.WriteLine("Header placeholder");
    // Print Controls
    Console.WriteLine("Controls placeholder");
    // If list is not empty, print the list
    if (list.Length is not 0)
        foreach(string s in list)
            Console.WriteLine(s);
}

string CollectString()
{
    while (true)
    {
        string? s = Console.ReadLine();
        if (s is not null) return s;
        else
            Console.WriteLine("null, try again placeholder");
    }
}