using System;
namespace DataStructures
{
  public class LinkedList
  {

    public Node Head { get; set; }

    // LinkedList myList = new LinkedList();
    // LinkedList myList = new LinkedList();
    public LinkedList()
    {
    }


    public void Print() 
    {
      Node current = Head;
      while ( current != null )
      {
        Console.Write($"({current.Value}) => ");
        current = current.Next;
      }

      Console.Write("NULL");

    }

    // LinkedList myList = new LinkedList();
    // LinkedList.Insert(7);
    public void Insert(int value ) {

      Node node = new Node(value);
      if (Head != null ) {
        node.Next = Head;
      }
      Head = node;
    
    }

    public void Append(int value) 
    {

      Node node = new Node(value);

      if (Head == null) 
      {
        Head = node;
        return;
      }

      Node current = Head;
      while (current.Next != null)
      {
        current = current.Next;
      }

      current.Next = node;

    }
  }
}
