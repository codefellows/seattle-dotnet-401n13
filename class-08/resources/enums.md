
### Enums

1. What are enums?
   - Enumeration types ("also called enums"), provide an
   efficient way to define a set of named integral constants that may be assigned to a variable.

```csharp
    enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    };

    enum Months : byte
    {
        Jan,
        Feb,
        Mar,
        Apr,
        May,
        Jun,
        Jul,
        Aug,
        Sep,
        Oct,
        Nov,
        Dec
    };
```
   - Count starts at 0, if you do not specify a value.
   - default type of enum is int, but you can specify alt with a :type (such as byte);

```csharp

    Days today = Days.Monday;
    int dayNumber =(int)today;
    Console.WriteLine("{0} is day number #{1}.", today, dayNumber);

    Months thisMonth = Months.Dec;
    byte monthNumber = (byte)thisMonth;
    Console.WriteLine("{0} is month number #{1}.", thisMonth, monthNumber);

    // Output:
    // Monday is day number #1.
    // Dec is month number #11.

```

 - You can create and set your custom values

```csharp
    enum MachineState
    {
        PowerOff = 0,
        Running = 5,
        Sleeping = 10,
        Hibernating = Sleeping + 5
    }

```
