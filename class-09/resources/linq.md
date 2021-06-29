# LINQ?

Language Integrated Query

- Imperative vs Declarative
   - What is Imperative
      - Foreach Loop
   - What is Declarative
      - LINQ statement

   - What is a 'query'?
   - A query is an expression that, when enumerated, transforms sequences with query operators.
   - The standard query operators are implemented as *extension methods*, so we can call 'Where' directly onto names

ALL LINQ query operations consist of three distinct actions:
1. Obtain the data source
1. Create the query
1. Execute the query

### Deferred Execution
The query variable that holds the query command doesn't actually execute until you iterate over it. An example would be a foreach loop.

The variable does not hold the result, only the command. So you can keep iterating over it and potentially get different answers.

## References

- [Official Docs](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [LINK Tutorials](https://www.tutorialsteacher.com/linq/what-is-linq)

