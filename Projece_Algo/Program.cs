using System;
using System.Text;

class Node
{
    public Note Data { get; set; }
    public Node Next { get; set; }

    public Node(Note data)
    {
        Data = data;
        Next = null;
    }
}
class LinkedList
{
    private Node head;

    public LinkedList()
    {
        head = null;
    }

    public void Add(Note data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public bool Remove(string title)
    {
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
                        Console.WriteLine("There is no notes.");
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
