using LINQDemo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BasicLINQ();
            MethodCalls();
            // GroupingBy();
        }

        static void BasicLINQ()
        {
            Person[] persons =
            {
                new Person ("Kate", "Austin", 33),
                new Person ("Jack", "Shepard", 39),
                new Person ("James", "Ford", 30),
                new Person ("Ben", "Linus", 23),
                new Person ("Hugo", "Reyes", 20),

            };
            /*
             * SQL QUERY:
             SELECT FirstName, LastName --> "Projection"
             FROM persons --> Data Source
             WHERE Age > 21 --> Filter
             Order By Age DESC; --> Sorting
             */

            var query = from person in persons
                        select person;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            // anonymous objects
            // only first and last name will be present
            var query2 = from person in persons
                         select new { person.FirstName, person.LastName };

            // Filtering
            // Note the anonymous object here has custom key names
            var filter = from person in persons
                          where person.Age > 21
                          select new { fn = person.FirstName, ln = person.LastName };

            // sorting
            var sorting = from person in persons
                          where person.Age > 21
                          orderby person.Age descending
                          select new { person.FirstName, person.LastName };


        }

        static void MethodCalls()
        {
            // Projection is through the "Select"
            // mapping is defined through delegates, using a lambda expression/function

            Person[] persons =
{
                new Person ("Kate", "Austin", 33),
                new Person ("Jack", "Shepard", 39),
                new Person ("James", "Ford", 30),
                new Person ("Ben", "Linus", 23),
                new Person ("Hugo", "Reyes", 20),

            };

            // method call with the select projection
            var query = persons.Select(p => new { p.FirstName, p.LastName });

            // The LINQ equivelant:
            var equiv = from p in persons
                        select new { p.FirstName, p.LastName };

            // possible Chaining:
            var chain = persons
                        .Where(person => person.Age > 21)
                        .Select(person => new { person.FirstName, person.LastName });

            // we can order by....
            var orderby = persons
                        .Where(person => person.Age > 21)
                        .OrderByDescending(person => person.Age)
                        .Select(person => new { person.FirstName, person.LastName });

            // technically, select can be present anywhere in a method call.
            // methods execute in the order they are listed though...so be careful with ordering.

            // in query syntax...select is required, a method calls, the select statemetn is not requried if no modifications are being done.

            var noSelect = persons.Where(person => person.Age > 21);

            // Query syntax is shorter and easier to understand
            // method syntax is C# code. and easier to see the overall operations
            // There are some methods that can only be done through methods


            //.Take and .Skip are some of them
            var example = persons
                        .Where(person => person.Age > 21)
                        .OrderByDescending(person => person.Age)
                        .Skip(2)
                        .Take(1)
                        .Select(person => new { person.FirstName, person.LastName });

            var examp = (from person in persons
                         where person.Age > 21
                         orderby person.Age descending
                         select new { person.FirstName, person.LastName })
                        .Skip(2).Take(1);


        }

        static void GroupingBy()
        {
            var words = new[] { "cat", "dog", "coffee", "phone", "apple" };
            // Query Syntax
            var query = from word in words
                        group word by word.Length;

            // Method Syntax
            var query2 = words.GroupBy(word => word.Length);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var blah in item)
                {
                    Console.WriteLine($"* {blah}");
                }
            }
        }

        static void SetOperatends()
        {
            var list1 = new[] { 1, 2, 3 };
            var list2 = new[] { 3, 4, 5 };

            // Union means items that exist in both sets
            var union = list1.Union(list2); // {1,2,3,4,5}

            // intersect itesm that appear in both collections
            var inter = list1.Intersect(list2);

            // Except kdips any itesm whic also appear in the second list
            var exctp = list1.Except(list2); // {1,2}

            // distinct removes all duplciates
            var list = new[] { 4, 8, 15, 16, 23, 42, 42, 8, 1, 2, 4 };
            var disti = list.Distinct();
        }

        static void Performance()
        {
            // Deferred Execution =
            /*
             * Deffered execution is when items are not loaded up until they are needed. This distributes the perforamce across the whole traversal and not all at once (foreach loop)
             */


            // Eager loading (immediate) = All items are loaded up right away. performance is frontloaded to the initial load. (To list)


            // .WHERE does not execute unit we access it in a loop
            // .SUM() executes immediatly.
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var sum = list.Sum(); // executes immediatly
        }

        #region extensionmethod
        //public static int Sum(this IEnumerable<int> list)
        //{
        //    var sum = 0;
        //    foreach (var item in list)
        //    {
        //        sum += item;
        //    }
        //    return sum;
        //}

        #endregion
    }
}
