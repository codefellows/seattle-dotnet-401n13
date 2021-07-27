using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.interfaces
{
  public interface IBag<T> : IEnumerable<T>
  {
    /// <summary>
    /// Add an item to the bag. <c>null</c> items are ignored.
    /// </summary>
    void Pack(T item);

    /// <summary>
    /// Remove the item from the bag at the given index.
    /// </summary>
    /// <returns>The item that was removed.</returns>
    T Unpack(int index);
  }
}
