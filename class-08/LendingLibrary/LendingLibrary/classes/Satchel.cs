using LendingLibrary.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.classes
{
  class Satchel<T> : IBag<T>
  {
    private readonly List<T> stuff = new List<T>();

    public void Pack(T item)
    {
      stuff.Add(item);
    }

    public T Unpack(int index)
    {
      T thing = stuff[index];
      stuff.RemoveAt(index);
      return thing;
    }

    // React has a thing called "thunk"
    public IEnumerator<T> GetEnumerator()
    {
      foreach (T thing in stuff)
      {
        yield return thing;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
