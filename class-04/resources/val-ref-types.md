# Value and Reference Types

## Value Types
A data type is a value type.
1. Value types hold the data within its own memory allocation. 
1. Examples include `int`s, `float`,`double`, `long`, enums, and structs
1. Value types only live on the stack. 
1. It is a copy, and can be changed/manipulated as want without it affecting anything else.
1. Created at compile time, and stored in stack memory. GC cannot access the stack.

## Reference Types 
A reference type is something that has a reference (address) to the object but not the object itself.
1. Because it only contains a reference, assigning a reference var to another var rather than the data itself doesn't copy the data.
Instead it creates a second reference, pointing to the same location on the heap.
1. reference types contains a pointer, located on the stack, and points to another memory location, on the heap, that holds the real data.
1. Mostly strings and objects, but also classes, arrays, indexers and interfaces
1. Ref types vars are stored in the HEAP.

```csharp
int[] myArray = new int[10];
```

The space required for the 10 integers that make up the array is allocated on the HEAP

## Example/Analogy
Digital Newspaper(reference type) vs Printed Newspaper (Value Type)
- You can make as many printed newspapers as you want, they are all independent from each other
- With a digital newspaper, when changes occur, everyone that has the reference (URL) can see the changes.
