using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
  class Stack<T>
  {
    public Node<T> Top { get; set; }

    public bool Peek()
    {
      return Top != null;
    }

    public void Push(T value)
    {
      Node<T> node = new Node<T>(value);
      node.Next = Top;
      Top = node;
    }

    public Node<T> Pop()
    {
      Node<T> currentTop = Top;

      Top = currentTop.Next;

      return currentTop;
    }
  }
}
