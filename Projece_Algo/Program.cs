using System;
using System.Text;

// single node in the LinkedList
class Node
{
    // It stores the Note object
    public Note Data { get; set; }
    // It stores the reference to the next note
    public Node Next { get; set; }

    // Constructor that initializes the new instance of the Node with the new data
    public Node(Note data)
    {
        Data = data;
        Next = null;
    }
}

// Realization of LinkedList
class LinkedList
{
    // Head of the LinkedList
    private Node head;

    // Constructor with an empty LinkedList
    public LinkedList()
    {
        // head is null because the new list doesn't have any connection with others
        head = null;
    }

    //Method of Adding the new Linked List
    public void Add(Note data)
    {
        //Creating a new Node with the provided data
        Node newNode = new Node(data);
        //Setting empty list at the head of the LinkedList
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            // Initializing the current position
            Node current = head;
            // It will run until it comes to the end of the list
            while (current.Next != null)
            {
                // Moving to the last Node
                current = current.Next;
            }
            // it points to the the end of the list
            current.Next = newNode;
        }
    }

    // Realization of Removing method. It deletes the note according to its Title.
    public bool Remove(string title)
    {
        // if the list is null - it will return false
        if (head == null)
        {
            return false;
        }

        if (head.Data.Title.Equals(title))
        {
            head = head.Next;
            return true;
        }

        Node current = head;
        while (current.Next != null && !current.Next.Data.Title.Equals(title))
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            return false;
        }

        current.Next = current.Next.Next;
        return true;
    }

    public bool Edit(string title, string newContent)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Title.Equals(title))
            {
                current.Data.Content = newContent;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Display()
    {
        Node current = head;
        int count = 1;
        while (current != null)
        {
            Console.WriteLine($"{count++}) {current.Data}");
            current = current.Next;
        }
    }

    public bool IsEmpty()
    {
        return head == null;
    }
}

class Note
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Note(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Content: {Content}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList notes = new LinkedList();

        while (true)
        {
            Console.WriteLine("\n1. Add");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Display");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                Console.Write("Choose: ");
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Write the title: ");
                    string title = Console.ReadLine();
                    Console.Write("Write the content: ");
                    string content = Console.ReadLine();
                    notes.Add(new Note(title, content));
                    Console.WriteLine("Successfully.");
                    break;

                case 2:
                    if (notes.IsEmpty())
                    {
                        Console.WriteLine("There are no notes.");
                    }
                    else
                    {
                        Console.Write("Write the title of the note to edit: ");
                        string oldTitle = Console.ReadLine();
                        Console.Write("Write new content: ");
                        string newContent = Console.ReadLine();
                        bool edited = notes.Edit(oldTitle, newContent);
                        if (edited)
                        {
                            Console.WriteLine("Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Not found.");
                        }
                    }
                    break;

                case 3:
                    if (notes.IsEmpty())
                    {
                        Console.WriteLine("No notes to delete.");
                    }
                    else
                    {
                        Console.Write("Write the title of the note to delete: ");
                        string deleteTitle = Console.ReadLine();
                        bool deleted = notes.Remove(deleteTitle);
                        if (deleted)
                        {
                            Console.WriteLine("Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Not found.");
                        }
                    }
                    break;

                case 4:
                    if (notes.IsEmpty())
                    {
                        Console.WriteLine("No notes to display.");
                    }
                    else
                    {
                        notes.Display();
                    }
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
