# Classes

## What is Object Oriented Programming?
Object oriented programming is mimicking real world objects in code.
Everything in C# is essentially a class, and we can instantiate objects from classes that we can manage at a smaller level.

## What are Classes?
A class is a blueprint for a specific type or category of object.
This means that the class will outline what exactly each object will have in regards to
properties, methods, and general behavior.

## Nested Classes
Nested classes are a possibility. typically Nested classes are used to help restrict and scope classes.
Public nested classes are not recommended. You should only use them when declaring private nested classes.


### What is an Object?

1. Use the `new` keyword to create an object

```csharp
Customer amanda = new Customer();
```

1. When an instance of a class is created, a reference to the object is created
1. 'amanda' is a reference to an object based on `Customer`.

```csharp
Customer belle = new Customer();
Customer kitty = belle;
```
The above example creates two object references that both refer to the same object.
You *can* create an object reference and assigning it to an existing object

- ***Because objects that are based on classes are referred to by reference, classes are known as reference types***

### What is the difference between a class and an object?

**An Object is an instance of a class**

### Constructors

1. What are constructors?
      1. A constructor is defined like a method, except that the method name and return type are reduced to the name of the enclosing type:
      1. Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read.
      1. **Default Constructors**
         - if you don't provide a constructor, one is automatically made for you that sets the member variables to their default values
      ```csharp
       public class Person
       {
         private string last;
         private string first;

         public Person(string lastName, string firstName)
         {
           last = lastName;
           first = firstName;
         }

         // Remaining implementation of Person class.
      }
      ```


### Object Initializers

```csharp
	public class Bunny
	{
	  public string Name;
	  public bool LikesCarrots;
	  public bool LikesHumans;

	  public Bunny () {}
	  public Bunny (string n) { Name = n; }
	}


	// Using object initializers, you can instantiate Bunny objects as follows:
	// Note parameterless constructors can omit empty parentheses
	Bunny b1 = new Bunny { Name="Bo", LikesCarrots=true, LikesHumans=false };
	Bunny b2 = new Bunny ("Bo")     { LikesCarrots=true, LikesHumans=false };

```

### The static keyword
If something is marked static, it means that it belongs to the class as a whole, not the individual objects.
It is shared across all instances.
If you change something in the class that is static, it will affect all instances of the class.


## Properties
*See Properties.md*
