## Stack/Heap
Both are stored on computers RAM

## Stack
1. Imagine it like a stack of shoe boxes
1. Keeps track of what is being executed in the code
1. Variables allocated to the stack are stored directly to the memory, making it very fast for access.
   1. Allocated at compile time
   1. Holds value types
   1. Self-maintaining -takes care of it's own memory management
   1. static memory allocation

## Heap
1. Dynamic memory allocation
1. Have their memory allocated at runtime.
1. Accessing is a bit slower than on the stack.
1. Heap size is only limited by the size of virtual memory.
1. No dependencies on one another and can always be randomly accessed.
   1. Imagine it like a bucket with a lot of 'things' in it
   1. Keeps track of objects / reference types / *sometimes* Value Types
   1. Relies on Garbage collection (GC) for memory management
   1. Reference Types usually go to the heap

You can use the stack if you know exactly how much data you need to allocate before compile time and it is not too big. You can use heap if you don't know exactly how much data you will need at runtime or if you need to allocate a lot of data
