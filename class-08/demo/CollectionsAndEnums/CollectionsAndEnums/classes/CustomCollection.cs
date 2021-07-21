using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndEnums.classes
{

  // CustomCollection<int> myThings = new CustomCollection<int>();
  class CustomCollection<T> : IEnumerable
  {

    // int[] iterms = new int[5];
    T[] items = new T[5];
    int count;

    public void Add(T item)
    {

      // Do we need to resize?
      if (count == items.Length)
      {
        // resize the array
        Array.Resize(ref items, items.Length * 2);
      }

      items[count++] = item;
      // count = count + 1 ...
      // items[++count]  ...

    }

    public IEnumerator<T> GetEnumerator()
    {
      for (int i = 0; i < count; i++)
      {
        yield return items[i];
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

  }
}
