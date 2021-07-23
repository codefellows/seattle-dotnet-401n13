using System;
using System.Collections.Generic;

namespace DataStructures
{
  public class Node<T>
  {
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    // Node node = new Node(4);  (4) -> 

    public Node(T value)
    {
      Value = value;
    }
  }
}
