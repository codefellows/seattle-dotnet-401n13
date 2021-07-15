using System;
namespace DataStructures
{
  public class Node
  {
    public int Value { get; set; }
    public Node Next { get; set; }

    // Node node = new Node(4);  (4) -> 

    public Node( int value )
    {
      Value = value;
    }
  }
}
