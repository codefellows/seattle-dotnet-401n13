# C# Delegates

Delegation allows us to delegate functionality ... in other words, we can pass methods as params to other methods and run them there

## Why Delegates?

Delegates allows us to parametrize our code. We can pass code, not just ints, or strings, or class types.  Delegates allow us to pass references to some code since delegates are essentially references to some code (method)

Note: When creating a delegate, C# creates a class behind the scenes. Since it's a class, it can be instantiated.

```csharp
delegate void MyDelegate();
```

The delegate declaration above will prompt the compiler to create a new class, behind the scenes called MyDelegate.

```csharp
class MyDelegate{ }
```

Since the delegate is a class, this means we can instantiate it!

```csharp
MyDelegate del = new MyDelegate();
```

The constructor for this delegate will be a method call that has the same return type as the delegate declaration as well as accepting the arguments that we declared within the delegates parameters.  Essentially, since this is a void return type with no parameters, it wants us to send it a method with a void return type that has no parameters.

```csharp
static void MyMethod(){}
MyDelegate del = new MyDelegate(MyMethod);
```

We are not invoking our method, we are just passing it into the constructor.

*WE ARE PASSING A METHOD ADDRESS INTO OUR CONSTRUCTOR!!!!*

This is a pretty cool ability that we have within the language!

If we want to now invoke/call this method we can do so by either

```csharp
del();
```
OR

```csharp
del.Invoke();
```

These both do the same things. The compiler is just helping us in the first.

let's take a look at our "instantiation" of our hidden class

```csharp
MyDelegate del = new MyDelegate(MyMethod);
```

Essentially, del is referencing our method "MyMethod". We can shorthand this by saying

```csharp
// Del reference MyMethod. Del is a delegate. and MyMethod is a method.
MyDelegate del = MyMethod;
```

The compiler is our best friend. It is helping us immensely. When we do the above reference to a method, it is essentially doing what we had before, just shorthand, and we don't have to worry about it.

The method is now essentially an "Object" and we can invoke it like a method.

### Passing Delegates

We can pass delegates as well.

```csharp
static void Main(){
	MyDelegate del = MyMethod;
	PassingADelegate(del);
}

static void PassingADelegate(MyDelegate delly)
{
	delly();
}
```

i can also remove the delegate instantiation completely and just do this:

```csharp
static void Main(){

	PassingADelegate(MyMethod);
}

static void PassingADelegate(MyDelegate delly)
{
	delly();
}
```

Since our method requires a delegate we can just pass th method name in to make equal to that delegate reference without having to explicitly say `new`.



#### Another Example:

1. Create a new method that returns an `IENumerable<int>` that says GetAllEvenNumbers

1. once in the method, do a foreach and check if each number is even. do a yield return number

```csharp
IEnumerable<int> result = GetAllEvenNumbers(new[] {1,3,4,2,7,6,8});

foreach(int i in result){cwl(i)}
```

But What if we needed something to get odd numbers?

We could copy/paste and redo it to change the logic, but that isn't effective because the only thing we are doing is changing the inner logic of the if statement.


What we need to do is parametrize the code of that if statement so that we have the flexibility to have this method do w/e we want, or by having it call these  external methods that are essentially the same thing, but with small logic changes.

1. We need to create a delegate outside the class. Set the return type a bool and have it with a parameter of some number.

1. Create the methods that are going to do the logic for us (GetAllEven, GetAllOdd, GetAllFives)

```csharp
static bool GetAllEven(int n){ return n%2 ==0;}

static bool GetAllOdd(int n){ return n%2 ==1;}
```

1. We can now have our Method named `GenerateNumbers` that takes in an IEnumerable of ints, and a delegate reference.

We can call this GenerateNumbers now by passing it the number we are generating and the method we want to run it through the delegate.

```csharp
static IEnumerable<int> GenerateNumbers(IENumerable<int> numbers, MyDelegate action)
{
    foreach(int number in numbers)
    {
	     if(action(number))
	     {
	 	     yield return number
	     }
    }
}
```

### Generic Delegates

If we decide that we don't want to make our own delegates but use generic delegates we can do so.
Ths is where `Action` and `Func` come into the picture.

#### Func
You use action, as a generic delegate if you want to have specific parameters for a method, with one specific data type returning. These can hold up to 16 parameters, with one data type/variable returning.

```csharp
Func<int, int, bool> myFunc = ThisTakesInTwoIntsAsArgumentsAndReturnsABool;

static bool ThisTakesInTwoIntsAsArgumentsAndReturnsABool(int a, int b){return true;}
```

#### Action

Action return void and can take 0 - 16 arguments.
Funcs do not have return arguments. Other than that, they are essentially the same as Funcs.









