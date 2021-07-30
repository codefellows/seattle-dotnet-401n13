using System;
using System.Collections.Generic;

namespace DataStructures
{
  public class Node<T>
  {
    public T Value { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }

    // K-Ary Tree has a list of child nodes that you could maybe loop over ....
    // public List<Node<T>> Children { get; set; }

    // Node node = new Node(4);  (4) -> 

    public Node(T value)
    {
      Value = value;
    }
  }
}
