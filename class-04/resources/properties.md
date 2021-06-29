## Properties

### What are Properties

1. Properties look like fields from the outside, but internally they contain logic, like methods do.
1. A property is declared like a field, but with a get/set block added
1. A `get` property accessor is used to return the property value, and a `set` property accessor is used to assign a new value.
1. The value keyword is used to define the value being assigned by the `set` accessor.
1. Properties can be:
   1. read-write (they have both a `get` and a `set` accessor)
   1. read-only (they have a `get` accessor but no `set` accessor)
   1.  write-only (they have a `set` accessor, but no `get` accessor).
       1. Write-only properties are rare and are most commonly used to restrict access to sensitive data.
1. A backing field is just a field that is used by properties when you want to modify or use that private field data.  In other words, a property is just a reference to another private variable.

```csharp
class Person
    {
        private string name;  // the name field (called a 'backing store' note how it is private)
        public string Name    // the Name property
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }

    Person person = new Person();
    person.Name = "Joe";  // the set accessors is invoked here

    System.Console.Write(person.Name);  // the get accessor is invoked here
```

## Getters & Setters

Logic can exist in the Get/Set accessors. We have the ability to check/confirm values before
they get set into the object. we can do it like so below:


```csharp
        public class Date
        {
		    private int month = 7;  // Backing store

		        public int Month
                {
                    get
                    {
                        return month;
                    }
                    set
                    {
                        if ((value > 0) && (value < 13))
                        {
                            month = value;
                        }
                    }
                }
            }
```
```csharp
		class Employee
		{
			private string name;
			public string Name
			{
				get
				{
					return name != null ? name : "NA";
				}
			}
		}
```

### Not Good Practice

When getting the value from a property, don't let it be manipulated.

```csharp
	private int number;
	public int Number
	{
		get
		{
			return number++;   // Don't do this
		}
	}
```

### Value keyword

The `value` keyword is used to indicate the value that is supposed to be getting set.
For example:

```csharp
	Player player = new Player();
	player.Name = "Amanda"; // this "SETS" the players name in the Name property
	string name = player.Name; // This "Gets" the players age from the Name property

```

The property layout for the above code looks like this:

```csharp
private string name;

public string Name{
	get{
		return name;
	}
	set{
		name = value
	}
}


```

### Backing Fields

Whenever we have a property that gets or sets the value of a specific instance variable, that instance variable is called a backing field.

Backing fields are typically private. Backing fields are not required within properties, but are still sometimes used.

Here is what a property with a backing field looks like:

```csharp

Class Time
{
	private int seconds;
	public int Seconds{
		get{
			return seconds;
		}
		set{
			seconds = value;
		}
	}
}

```

## Auto-Implemented Properties

If you do not want to create a backing field, C# offers us an alternative to not including them when we create properties. This is called auto-implemented properties, and they look like this:

```csharp
	public string FirstName { get; set; } = "Jane";
```

Under the hood, a backing field is created anyway, we just don't have direct access to it. This is a nice shortcut we, as developers, can take advantage of.

If we plan on actually having logic in the getters or the setters, we must create our own backing store, as auto-implemented properties are not good options for these types of properties.

> Pro Tip: Typing `prop<tab><tab>` will auto-create your auto-implemented fields!


## Accessibility Levels
It is possible for you to have the `get` be one accessibility level, while the `set` is different. This will allow the getter to be accessible by anyone (public) and the set to only be changed from within the class (private)


### Resources:

- [Properties](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)
