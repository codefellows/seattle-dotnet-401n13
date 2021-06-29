# Intro to C#

Welcome to class! Today we will learn about C# and how to handle errors and exceptions within our code. 

## Learning Objectives

### Students will be able to

#### Describe and Define

- What and how to use exception handling
- Best practices when implementing exception handling
- Where to start when encountering an error 

#### Execute

- The student will successfully request user input and output a response to the console.
- The student will implement try-catch statements as a form of exception handling within their code.
- Set-up a debugger within Visual Studio

## Today's Outline

## Review
1. Syllabus
1. Grade Break down
1. Coding Challenges and Expectations
1. Due Dates

### C# Basics
- What is C#
  - Where did it come from?
	- Currently on C# 7
		- Updates to the language are always in the works to make it better
- What is .NET
- What is ASP.NET
- What is ASP.NET Core
	
- Why do we use it?
	- Statically Typed
		- Type checking occurs at compile time (C#)
	- Dynamically Typed
		- Type checking occurs at Run time (JS)
	- Object Oriented

### Microsoft Platform:
  - C# depends on a runtime equipped with a host of features such as automatic memory management and exception handling. 
  The design of C# closely maps to the design of Microsoft’s Common Language Runtime (CLR), which provides these runtime 
  features (although C# is technically independent of the CLR).

  - The CLR is the runtime for executing managed code. C# is one of several managed languages that get compiled into managed code. 
  Managed code is packaged into an assembly, in the form of either an executable file (an .exe) or a library (a .dll), 
  along with type information, or meta-data.

  - Managed code is represented in intermediate language or IL. When the CLR loads an assembly, it converts the IL into the 
  native code of the machine, such as x86. This conversion is done by the CLR’s JIT (just-in-time) compiler. An assembly retains 
  almost all of the original source language constructs, which makes it easy to inspect and even generate code dynamically.

  - CLR is in charge of taking the managed code, compiling it into machine code and then executing it. 
  On top of that, runtime provides several important services such as automatic memory management, security boundaries, 
  type safety etc.


### Exception Handling

- What is Exception Handling?
- Why do we use it?
- What does it consist of? 
	- try{}
	- catch{}
	- finally{}
	- throw


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

### Different types of Exceptions:

There are many different types of exceptions included in the C# language. Here is just a few...

1. **NotImpelemtedException** - Indicates that a method has not yet been implemented. 
1. **IndexOutOfRangeException** - Indicates that an index outside the range of a collection has been referenced.
1. **InvalidCastException** -  Indicates that a cast has been attempted on the incorrect object type.
1. **FormatException** - Text was not in the correct format when converting it to something else.
1. **NotSupportedException** - An action was attempted that was not supported.
1. **NullReferenceException** - Reference type was null, instead of an object.
1. **StackOverflowException** - Indicates that there is no more room left on the call stack. 
1. **DivideByZeroException** - You can't divide by zero....
1. **ArgumentNullException** - A required non-null argument provided was null.
1. **ArguementOutOfRangeException** - Argument contained a value that was out of range then what it was expecting. 


### Debugging

- Why do you need debugging?
- How do you debug in Visual Studio?
	- Step over
	- Step into
	- Step through


## Error Handling while during Lab:
   - What do you do if you encounter an error (whiteboard // draw it)
   - 15 minute rule
   - Take a deep breath, step away, break it down
   - Documentation
   - Look at the lecture
   - Online Research
   - Ask a TA
   - Ask the instructor
