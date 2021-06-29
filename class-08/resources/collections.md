# Collections

What is a collection?

There are two ways to create and manage a group of related objects
    1. Create an array of objects
    2. Creating a collection of objects

1. What is a collection?
   - Collections provide a more flexible way to work with groups of objects. Unlike arrays, the group of objects you work with can grow and shrink dynamically as the needs of the application change.
   - For some collections, you can assign a key to any object that you put into the collection so that you can quickly retrieve the object by using the key.
    - A collection is a class, so you must declare an instance of the class before you can add elements to that collection.
    - If your collection contains elements of only one data type, you can use a Generic.

#### Generics
   1. One type of generic collection is a List<T>;
	- `T` represents the type that will be stored in the Collection. In this case, it's a list.
   2. Example of a List:

      ```csharp
	    var princesses = new List<\string>();

      princesses.Add("Snow White");
      princesses.Add("Cinderella");
      princesses.Add("Aurora");
      princesses.Add("Repunzel");
      princesses.Add("Ariel");
      ```

You can ues a foreach loop to traverse through a collection

```csharp
foreach(var princess in princesses)
{
   Console.WriteLine($"Princess: {princess}");
}
```

 To add values directly to a collection upon instantiation, use a *collection initializer*

```csharp
var princes = new List<string>{"Eric", "Charming", "Aladdin"};

foreach(string p in prince)
{
   Console.WriteLine($"Prince: {p}");
}
```

If you want to use a for loop, you can. Here is the alternative:

```csharp
 var princess = new List<strings> {"Jasmine","Moana","Merida", "Anna", "Elsa"}

 for (var index = 0; index < princess.Count; index++)
 {
    Console.Write(princess[index] + " ");
}
```


To remove an item from a list, simply `Remove()` it.

```csharp
//(same as above)
princess.Remove("Elsa");

// Iterate through the list.
foreach (var p in princess)
{
    Console.Write(p + " ");
}
```

You can also use a for loop to decrement a collection/list. The below example removes an item from the list without the built in remove method.

```csharp
var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Remove odd numbers.
for (var index = numbers.Count - 1; index >= 0; index--)
{
    if (numbers[index] % 2 == 1)
    {
        // Remove the element by specifying
        // the zero-based index in the list.
        numbers.RemoveAt(index);
    }
}

// Iterate through the list.
// A lambda expression is placed in the ForEach method
// of the List(T) object.
numbers.ForEach(
    number => Console.Write(number + " "));
// Output: 0 2 4 6 8
```



1. For the type of elements in the List<T>, you can also define your own class, you do not only have to use string,int,bool etc...Any data type can be used.

```csharp
private static void IterateThroughList()
{
    var snowWhiteDwarves = new List<Dwarves>
        {
            new Disney() { Name="Doc", age=400},
            new Disney() { Name="Happy", age=25},
            new Disney() { Name="Dopey", age=100},
            new Disney() { Name="Grumpy", age=53}
        };

    foreach (Disney dwarf in snowWhiteDwarves)
    {
        Console.WriteLine(snowWhiteDwarves.Name + "  " + snowWhiteDwarves.Age);
    }

}

public class Disney
{
    public string Name { get; set; }
    public int age { get; set; }
}

```

#### ***Demo** - Let's create our own Generic Collection (List<T>):*

To start us out, we don't actually have to use `T`. We can use whatever letter we want. It just has to stay consistent through the whole class.

```csharp

class NumberList<Y>
{
    Y[] items = new Y[5];
    int count;
    public void Add(Y item)
    {
        if(count == items.Length)
        {
            Array.Resize( ref items, items.Length * 2);
        }
        items[count++] = item;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        NumberList<int> numberList = new NumberList<int>();

        numberList.Add(10);
        numberList.Add(15);
        numberList.Add(25);
        numberList.Add(28);
    }
}
```


### `GetEnumerator()`?
 If you attempt to iterate through your custom collection with a `foreach`, you will get the following error:
 ```
Error	CS1579	foreach statement cannot operate on variables of type 'NumberList<string>' because 'NumberList<string>' does not contain a public instance definition for 'GetEnumerator'
 ```
This means that you need to add the `GetEnumerator` method into your custom generic class.

 You need `GetEnumerator` in your custom generic class to iterate through with a foreach loop. Add the following code to your collection:

 ```
 public IEnumerator<Y> GetEnumerator()
 {
     for (int i = 0; i < count; i++)
     {
        yield return items[i];
     }
 }
 ```

 The above code will essentially "Enumerate" through the collection and do a `yield return` on each item and return it one by one.

 With a foreach loop, we can "pause" and do something with each individual index of the internal array of the collection.


#### Yield Return

- You use a `yield return` statement to return each element one at a time.
- 'pauses' and returns the next value

#### Yield Break**

You use a `yield break` statement to end an iteration
    - Clean way to end a loop from executing

**There is much more to `yield return` and `yield break` then what we may go over.
  - if there is time in class we can go over the details of whats 'under the hood'
   of the `yield` statements, or just direct the student to do some self research on it.


#### Collection Initializers

Much like object initializers, you can also do what's called collection initializers. (You will get an error! Read below :) )

```csharp

	Library<string> secondLib = new Library<string>
	{
	  "The Great Gatsby",
	  "Where the Red Fern Grows",
	  "Of Mice and Men"
	};

```
If you attempt to conduct a collection initializer with the current state of the program, you will get the following error:

```
Error	CS1922	Cannot initialize type 'Library<string>' with a collection initializer because it does not implement 'System.Collections.IEnumerable'
```

You must then implement the `IEnumerable` interface onto your custom collections generic. This will inevitably require you to implement the non-generic version of `GetEnumerator`.

```csharp
  IEnumerator IEnumerable.GetEnumerator()
  {
      throw new NotImplementedException();
  }
```

The return type of this implementation should simply just call your already existing generic `GetEnumerator`.


```csharp
  IEnumerator IEnumerable.GetEnumerator()
  {
      return GetEnumerator();
  }
```

#### Why

The non-generic IEnumerable is actually from C# 1.0. It is present purely for legacy code purposes. The IEnumerable interface requires it to be used, and the IEnumerable is what is used to allow us to use a collection initializer. Because of this requirement/dependency we must include it in our collection and simply have it call our other generic GetEnumerator to allow us to use the foreach loop.

- IEnumerable
- Foreach does not require IEnumerable
- only requires a IEnumerator GetEnumerator();

- *Enumerable* - means it can be iterated through
- *Enumerator* - that actual 'thing' that walkthroughs and sequences through the list


```csharp

	class NumberList<Y> : IEnumerable<T>
    {
        Y[] items = new Y[5];
        int count;
        public void Add(Y item)
        {
            if(count == items.Length)
            {
                Array.Resize( ref items, items.Length * 2);
            }
            items[count++] = item;
        }

        public IEnumerator<Y> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

    }

  static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NumberList<int> numberList = new NumberList<int>() {4, 8, 15, 16, 23, 42};

            foreach (int i in numberList)
            {

            }
        }

```

- By adding the implementation of IEnumerable, it allows your program to support the 'new' syntax.
- As the other example before this shows, it is not necessarily required, but good practice
- When you build the above example, when you implement the interface, have VS auto implement it for you.
- Because the interface of IEnumerable requires the non-generic GetEnumerator, VS will auto add what is missing. Here is the after result:

```csharp
 class NumberList<Y> : IEnumerable<Y>
 {
      Y[] items = new Y[5];
      int count;
      public void Add(Y item)
      {
          if(count == items.Length)
          {
              Array.Resize( ref items, items.Length * 2);
          }
          items[count++] = item;
      }

      public IEnumerator<Y> GetEnumerator()
      {
          for (int i = 0; i < count; i++)
          {
              yield return items[i];
          }
      }

      //This is new, but GetEnumerator will call the Generic GetEnumerator above.

      IEnumerator IEnumerable.GetEnumerator()
      {
          return GetEnumerator();
      }

      //Can create Custom Enumerator Method here that the GetEnumerator returns
 }
```





### Generics vs. Non-Generics

#### Generics
- List<T>
- Dictionary<T>
- SortedList<T>
- Queue<T>
- IEnumerable<T>
- IList<T>
- Collection<T>
- LinkedList<T>

#### Non-Generics

*are not really used much anymore*

- ArrayList
- Hashtable
- SortedList
- Queue
- Stack
- IEnumerable
- ICollection
