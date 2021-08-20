using System;
using System.Collections.Generic;

namespace DataStructures
{
  public class HashMap
  {

    private LinkedList<KeyValuePair<string,string>>[] Map { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size">Number of Buckets</param>
    public HashMap(int size)
    {
      // Create a list of the size
      Map = new LinkedList<KeyValuePair<string, string>>[size];
    }

    private int Hash(string key) {

      int hashValue = 0;

      char[] letters = key.ToCharArray();

      for(int i = 0; i < letters.Length; i++ )
      {
        hashValue += letters[i];
      }

      hashValue = (hashValue * 599) % Map.Length;

      return hashValue;
       
    }

    public void Set(string key, string value)
    {
      // hash the key
      int hashKey = Hash(key);

      // Add it to the list that's at the correct position in our buckets
      if( Map[hashKey] == null )
      {
        Map[hashKey] = new LinkedList<KeyValuePair<string, string>>();
      }

      KeyValuePair<string, string> entry = new KeyValuePair<string, string>(key, value);
      Map[hashKey].Insert(entry);

    }

    public bool Contains(string key)
    {

      int hashKey = Hash(key);

      if(Map[hashKey !] != null) 
      { 
        Node<KeyValuePair<string,string>> current = Map[hashKey].Head;

        while(current != null)
        { 
          if(current.Value.Key == key) { return true;  }
          current = current.Next;
	      }
      }

      return false;
    }

    public string Get(string key)
    {
      return "";
    }

    public void Print()
    {
      for(int i = 0; i<Map.Length; i++)
      {
        Console.Write($"{i} -- ");
        if(Map[i] != null)
        {
          Node<KeyValuePair<string, string>> current = Map[i].Head;
          while(current != null)
          {
            Console.Write($"[{current.Value.Key}:{current.Value.Value}] => ");
            current = current.Next;
	        }
	      }
        Console.WriteLine();
      }
    }

  }
}
