using System;
using System.Collections.Generic;

namespace DataStructures
{
  public class LinkedList<T>
  {

    public Node<T> Head { get; set; }

    // LinkedList myList = new LinkedList();
    // LinkedList myList = new LinkedList();
    public LinkedList()
    {
    }


    public void Print()
    {
      Node<T> current = Head;
      while (current != null)
      {
        Console.Write($"({current.Value}) => ");
        current = current.Next;
      }

      Console.Write("NULL");

    }

    // LinkedList myList = new LinkedList();
    // LinkedList.Insert(7);
    public void Insert(T value)
    {

      Node<T> node = new Node<T>(value);
      if (Head != null)
      {
        node.Next = Head;
      }
      Head = node;

    }

    public void Append(T value)
    {

      Node<T> node = new Node<T>(value);

      if (Head == null)
      {
        Head = node;
        return;
      }

      Node<T> current = Head;
      while (current.Next != null)
      {
        current = current.Next;
      }

      current.Next = node;

    }
  }
}
