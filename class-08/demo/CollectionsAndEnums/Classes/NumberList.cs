using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionsAndEnums.Classes
{
  class NumberList<T> : IEnumerable
  {
    // Define an initial size of the array
    T[] items = new T[5];
    // create a counter to keep track of the current numbers of books
    int count;

    // Add will put books into our above array. Keep the name "Add" because it will assist us in collection initializers
    public void Add(T item)
    {
      // Check if you need to resize your array
      if (count == items.Length)
      {
        Array.Resize(ref items, items.Length * 2);
      }
      // add the book to the array, and increment the counter
      items[count++] = item;
    }

    /// <summary>
    /// This is required for the use of a foreach loop with the collection
    /// </summary>
    /// <returns>individual elements of the array</returns>
    public IEnumerator<T> GetEnumerator()
    {
      for (int i = 0; i < count; i++)
      {
        // Yield return pauses at each item in the array before moving to the next
        yield return items[i];
      }
    }

    // Here for legacy code purposes from C# 1.0. This is required for the
    // IEnumarable interface.
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }


  }
}
