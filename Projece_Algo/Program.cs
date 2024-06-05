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
