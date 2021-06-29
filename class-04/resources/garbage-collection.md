# Garbage Collection

When you declare a variable in a .NET application, it allocates some chunk of memory in the RAM.
This memory has three things:

 1. the name of the variable
 1. the data type of the variable
 1. the value of the variable.

### GC Conditions

Garbage Collection occurs when one of the following conditions becomes true:

1. System has low physical memory
1. The memory that is used by allocated objects on the managed heap surpasses an acceptable
	threshold. This threshold is continuously adjusted as the process runs.
1. The `GC.Collect` method is called.

### Advantages of GC

1. You don't need to free up memory manually while developing your application
1. It allocates objects on the managed heap efficiently
1. When objects are no longer used then it will reclaim those objects by clearing their memory
    and keeps the memory available for future allocations
1. Managed objects automatically get clean content to start with, so their
	constructors do not have to initialize every data field.
1. It provides memory safely by making sure that an object cannot use the content
	of another object.

### GC Generations

The .NET Garbage Collector has 3 generations. Each
generation has it's own heap that is used for the storage of
allocated objects. There is a basic principle that most objects
are either short-lived or long-lived.

#### Generation First(0)

1. Objects are first allocated at Generation 0
1. Objects don't typically live past the first gen since
they are no longer in use (out of scope) by the time the next
garbage collection occurs
1. Gen 0 is quick to collect because it's association with the heap is small.

#### Generation Second(1)

1. In Gen 1, objects have a second chance space
1. Objects are short-lived but survive Gen 0 collection
1. Gen 1 collections are also quick because of its assoc. heap is also small
1. The first two heaps remain small because the objects are either collected or promoted to
the next generation

#### Generation Third(2)

1. Gen 2, all long objects are lived and its heap can grow very large
1. The objects in this generation can survive a long time and there is no next generation heap
to further promote objects.
1. The GC has an additional heap for large objects know as Large Object Heap(LOH)
1. LOH is reserved for objects that are 85k bytes or greater
1. Large objects are not allocated to the generational heaps, but directly to the LOH
1. Generation 2 and LOH collects can take noticeable
time for programs that have run for a long time or operate over large amounts of data.


