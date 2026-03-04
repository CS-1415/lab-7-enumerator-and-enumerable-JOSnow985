using Lab07;

DoublyLinkedList<string> list = new();
bool hideList = false;
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
            Console.WriteLine("What string should we add to the beginning?");
            list.AddFirst(CollectString());
            break;
        case ConsoleKey.E:
            Console.WriteLine("What string should we add to the end?");
            list.AddLast(CollectString());
            break;
        // Hiding and showing the list is probably not necessary
        case ConsoleKey.H:
            hideList = !hideList;
            break;
        case ConsoleKey.P:
            Console.Clear();
            PrintList();
            Console.ReadKey(true);
            break;
        default:
            break;
    }
}

// --- Methods ---
void PrintMenu()
{
    // Print some kind of header
    Console.WriteLine("Demo of Jaden's Doubly Linked List\nToday's Special: Listing Strings\n");
    // Print Controls
    Console.WriteLine("B: Add a string to the [B]eginning of the list\n"
                    + "E: Add a string to the [E]nd of the list\n"
                    + "H: [H]ide list on this menu\n"
                    + "P: [P]rint list on it's own\n"
                    + "Esc: Exit the program\n"
                    );
    // Don't print the list on the menu if we're hiding it
    if (!hideList)
        PrintList();
}

void PrintList()
{
    Console.WriteLine($"Current List:{(list.Length is 0 ? " Empty!" : "")}");
    // If list is not empty, print the list
    if (list.Length != 0)
        foreach (string s in list)
            Console.WriteLine(s);
}

string CollectString()
{
    while (true)
    {
        string? s = Console.ReadLine();
        if (s is not null) return s;
        else
            Console.WriteLine("All we got was \"null\"! Give us a string!");
    }
}