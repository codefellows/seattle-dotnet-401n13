# Exception Handling

## What is Exception Handling

When an application or a program encounters a problem/error, the C# CLR has the ability to package up that error and put into something called an Exception.

Typically, when an exception gets thrown, the rest of that method does not get run, instead the catch block is triggered, and the finally block (if present) finishes out the execution of the program. 
The C# language comes with many built in exceptions, but you are not bound to those exception, you actually have the ability to create your own Exceptions by deriving the custom class from the `Exception` class if you wish. For now, let's just look at the built in exceptions. 


## Real World Examples:
1. [Therac-25](https://en.wikipedia.org/wiki/Therac-25) was a computer controlled radiation therapy machine in 1982 after the Therac-6 and Therac-20 units. 
* At least 6 accidents between 1985 - 1987 patients were given massive overdoses of radiation. 
* reasoning was due to errors of giving patients radiation doses that were hundreds of times greater than normal..resulting in death or serious injury. 
* Engineers were overconfident in their initial work and did not handle exception handling for lethal doses
* They reused code from the previous versions without checking it first
* The issue only happened when a sequence of keystrokes occurred within a short period of time (8 seconds). Which made it difficult to catch

*The software set a flag variable by incrementing it, rather than by setting it to a fixed non-zero value. Occasionally an *arithmetic overflow* occurred, causing the flag to return to zero and the software to bypass safety checks. 

2. [Ariane 5](https://en.wikipedia.org/wiki/Ariane_5) Launch of 1996
* Rocket self destructed 37 seconds after launch becuase of a software malfunction.
* data conversion from 64-bit floating point to a 16-bit signed int value failed b/c the floating point value was too large to be represented into a 16-bit signed integer. 
* This code was originally used for the Ariane 4 but was not protected because the way the Ariane 4 was written, the engineers "assumed" it was impossible for the value to get that large....when upgrading the system, they did not update the error handling either causing the issue. 

## Different types of Exceptions:

1. **NotImpelemtedException** - Indicates that a method has not yet been implemented. 
1. **IndexOutOfRangeException** - Indicates that an index outside the range of a collection has been referenced
1. **InvalidCastException** -  Indicates that a cast has been attempted on the incorrect object type
1. **FormatException** - Text was not in the correct format when converting it to something else.
1. **NotSupportedException** - An action was attempted that was not supported.
1. **NullReferenceException** - Reference type was null, instead of an object
1. **StackOverflowException** - Indicates that there is no more room left on the call stack. 
1. **DivideByZeroException** - You can't divide by zero....
1. **ArgumentNullException** - A required non-null argument provided was null.
1. **ArguementOutOfRangeException** - Argument contained a value that was out of range then what it was expecting. 

### Try

 A `try` is a code block that is executed under the preparation that an error may potentially be thrown. 
 Each try should be accompanied by a 
 `catch` . 

If there is no catch, and an exception is thrown, the CLR throws an unhanded error and stops the execution of the program. 
Generally, it is not recommended to not have a catch block, although you can have an empty catch block or a catch block without an exception. 

Here is an example of what a `try` block would look like:

```csharp
		string number = "twenty";
		try
		{
			int twenty = Convert.ToInt32(number); //Error
		}
		catch(FormatException e)
		{
			Console.WriteLine("{number} is not an integer");
		}
```

### Catch

A catch block actually catches the error and then handles it. Like in the `try` example above, You *must* have a catch block after each try, or the CLR will thrown
an error and stop the execution of the program.

A cool thing about catch blocks is that you are not required to only have one....you can have as many `catch` blocks as you. The catch blocks are run from top to bottom and executes
the first valid/applicable catch block it finds. 

If you are unsure of what type of exception will be thrown, there is a very general exception called `Exception` that you can use. If you choose to use
this exception class as your choice in your `catch` block, make sure it is the very last catch block because that block will always run if an exception is caught. 
By having it at the bottom, this allows for a more valid/appropriate exception to potentially be run instead. 

Here is an example:

```csharp

	try
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int result = num1 / num2;

            Console.WriteLine("{0} / {1} = {2}", num1, num2, result);
        }
        catch(DivideByZeroException ex)
        {
            Console.Write("Cannot divide by zero. Please try again.");
        }
        catch(InvalidOperationException ex)
        {
            Console.Write("Not a valid number. Please try again.");
        }
        catch(FormatException  ex)
        {
            Console.Write("Not a valid number. Please try again.");
        }

```

### Finally

Finally blocks are structured to be placed right after a try/catch block. The finally will always be executed whether or not an exception is thrown. 
The finally block is generally used for cleaning up code, disposing unmanaged objects, etc...

```csharp
    int zero = 0;    
    
    try
    {
        int result = 5/zero;  // this will throw an exception       
            
    }
    catch(Exception ex)
    {
        Console.WriteLine("Inside catch block. Exception: {0}", ex.Message );
    }
    finally
    {
        Console.WriteLine("Inside finally block.");

    }

```

### Throw

A `throw` allows you to force an exception to be thrown. This can be done in either a `catch` block or a regular code block.
The advantages to this is if you have a custom exception that you would like to throw in replacement to the exception that was caught, or
you want an exception to be thrown, given a certain condition being met. 


```csharp
    if (original == null)
    {
        throw new System.ArgumentException("Parameter cannot be null", "original");
    }

```
When your method throws an exception, that method is not required to handle it. If it chooses, it can just pass it back up the call stack and let the preceeding methods
handle it. The exception will keep moving up the call stack until it either finds a catch statement OR reaches the last point. 

### CallStack

The call stack ...

- What is the call stack?
- Exception Handling outside of methods

```
Main() --> MethodA()
MethodA() --> MethodB()
MethodB() --> MethodC()
MethodC() encounters an exception -> No catch in MethodC();
Looks in MethodB() -> No catch in B either 
Looks in MethodA() -> No catch found
Looks in Main() -> No catch
Program Terminates. 

```

Another Example:

```csharp
static void Main()
{
	try{
		WriteLine("Trying in Main() Method");
		MethodA();
	} catch(Exception ae)
	{
		WriteLine($"Caught in Main() Method  -- {ae.Message}");
	}

	WriteLine("Main() MEthod is done");
}

private static void MethodA()
{
	try{
	WriteLine("In Method A");
	MethodB();
	
	}catch{
		WriteLine("Caught in MethodA");
		throw;
	}
}

private static void MethodB()
{
	try{
	WriteLine("In Method B");
	MethodB();
	
	}catch{
		WriteLine("Caught in MethodB");
		throw;
	}
}

private static void MethodC()
{
		WriteLine("Caught in MethodC");
		throw(new Exception("This is from Method C");
}
```

The whole point of this example is to prove the call stack and the ordering of the messages being thrown. You should see run this bit of code in VS and "prove" to the students that each method gets run as it gets pushed and popped off of the stack.