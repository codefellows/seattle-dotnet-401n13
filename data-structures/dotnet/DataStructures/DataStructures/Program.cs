using System;

namespace DataStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      StackIterative();
      StackRecursive();
      QueueIterative();
      QueueRecursive();
    }

    static void StackIterative()
    {

      Console.WriteLine("------ STACK: Iterative --------");

      Stack<string> myFamily = new Stack<string>();
      myFamily.Push("John");
      myFamily.Push("Cathy");
      myFamily.Push("Zach");
      myFamily.Push("Allie");

      while (myFamily.Peek())
      {
        Node<string> person = myFamily.Pop();
        Console.WriteLine(person.Value);
      }
    }

    static void StackRecursive() {

      Console.WriteLine("-------- STACK: Recursive ----------");

      Stack<string> myFamily = new Stack<string>();
      myFamily.Push("John");
      myFamily.Push("Cathy");
      myFamily.Push("Zach");
      myFamily.Push("Allie");
      IterateStackRecursively(myFamily);
    }

    static void IterateStackRecursively(Stack<string> stack)
    {
      // Base Case ... stops recursion
      if (!stack.Peek()) { return; }

      Node<string> person = stack.Pop();
      Console.WriteLine(person.Value);

      IterateStackRecursively(stack);

    }

    static void QueueIterative()
    {

      Queue<string> myFamily = new Queue<string>();
      myFamily.Enqueue("John");
      myFamily.Enqueue("Cathy");
      myFamily.Enqueue("Zach");
      myFamily.Enqueue("Allie");

      Console.WriteLine("-------- QUEUE: Iterative ----------");

      while (myFamily.Peek())
      {
        Node<string> person = myFamily.Dequeue();
        Console.WriteLine(person.Value);
      }

    }

    static void QueueRecursive() {

      Console.WriteLine("-------- QUEUE: Recursive ----------");

      Queue<string> myFamily = new Queue<string>();
      myFamily.Enqueue("John");
      myFamily.Enqueue("Cathy");
      myFamily.Enqueue("Zach");
      myFamily.Enqueue("Allie");
      IterateQueueRecursively(myFamily);
    }

    static void IterateQueueRecursively(Queue<string> queue)
    {
      // Queue Base Case
      if (!queue.Peek()) { return; }
      Node<string> person = queue.Dequeue();
      Console.WriteLine(person.Value);

      IterateQueueRecursively(queue);
    }

  }
}
