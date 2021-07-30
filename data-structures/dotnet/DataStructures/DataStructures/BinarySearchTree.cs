using System;
namespace DataStructures
{
  public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
  {

    public void Add(Node<T> node, T value)
    {
      // 1. Make a node out of that value

      // 2. If we don't have a root ... make that node the root and be done with it

      // 3. If the value is < the "node" I'm looking at ...
      // Try and add it to the left
      // If we don't have a left, just add it and be done
      // If we do have a left, Call this method again, with the left node ...

      // 4. If the value is > the "node" I'm looking at ...
      // Try and add it to the right
      // If we don't have a right, just add it and be done
      // If we do have a right, Call this method again, with the right node ...

      Node<T> newNode = new Node<T>(value);

      if(Root == null) {
        Root = newNode;
        return;  
      }

      if(newNode.Value.CompareTo(node.Value) < 0 )
      { 
        if(node.Left == null) { node.Left = newNode;  }
        else { Add(node.Left, value); }
      }

      else if ( newNode.Value.CompareTo(node.Value) > 0 )
      { 
        if(node.Right == null) { node.Right = newNode;  }
        else { Add(node.Right, value);  }
      }

    }
  }
}
