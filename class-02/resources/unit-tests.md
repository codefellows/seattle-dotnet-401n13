# Unit Testing

## What is Unit Testing

Unit tests are used to verify that the code written is working as expected. The "unit" part of 
unit tests are referring to each individual unit of code or method() that is written. 
Unit tests help developer with confirmation that their code is behaving exactly as they expect.

The expectation with unit tests is that you have multiple tests for each method to confirm
the code can handle different conditions. 

## Red/Green/Refactor

Within Test Driven Development (TDD), you should follow the "Red/Green/Refactor" rule.
This rule breaks down to the following requirements:

1. When your test is in **Red** (it is not passing), the only thing you can do is to make it pass. Create 
some sort of condition within your code to make your test pass. This can be as simple as hardcoding a string
into the return value if necessary.

1. When your test is **Green** (it is passing), you have 2 options, you can write another passing test, or you can
**refactor** the code so that it is more efficient. You should only ever refactor while you are in the green. Once you write 
a refactored test that turns red, you must go back to the **red** condition and make the test pass.

By following these simple rules of TDD, you will find analyzing and breaking down problems 
a bit easier because of how you are approaching the problem.

TDD can be difficult to start out with, but with a bit of practice, it will soon become second nature. 

## Facts

A `[Fact]` is one of the attributes that are required above a test method. 
This attribute indicates that the method below is supposed to be run by 
the test runner. 

A Fact is something that is **always** true. You will use Facts when testing your code
to confirm that any and all values that go through that method will always be true. 

## Theories

A `[Theory]` is the other attribute that is required above a test method. 
A Theory is something that is sometimes true, dependent on it's parameters. 

You will use theories when testing your code when confirming that different values will 
still provide the desired output. 

## Assertions

Assertions are what the test conditions are based off of. You use assertions to
test the expected value against the actual value. If the expected and actual match, the test is a pass.

One thing to note with unit tests is that even a expected failure of a condition, is still a failed test. 
You must structure your tests so that it will always complete as a "green" test.


## Demo

Incrementally build out your code following the Red/Green/Refactor technique. Start with Facts, then after a while working with facts and following TDD, then show the students Theories and how they can make the process go a bit quicker when we have parametrized data.

Your final code should look like so:


## Example Fizzbuzz Tests

```csharp

 public class UnitTest1
    {
        [Fact]
        public void ReturnsFizzFor3()
        {
            Program.FizzBuzz(3);
            Assert.Equal("Fizz", "Fizz");
        }

        [Theory(5, "Buzz")]
        [Theory(20, "Buzz")]
        [Theory(25, "Buzz")]
        [Theory(50, "Buzz")]

        public void ReturnsBuzzFor5(int number, string expected)
        {
            Program.FizzBuzz(5);
            Assert.Equal(expected, "Buzz");
        }

        [Theory(15, "FizzBuzz")]
        [Theory(30, "FizzBuzz")]
        [Theory(45, "FizzBuzz")]
        [Theory(60, "FizzBuzz")]

        public void ReturnsFizzBuzzFor15(int number)
        {
            Program.FizzBuzz(15);
            Assert.Equal("FizzBuzz", "FizzBuzz");
        }

        [Fact]
        public void ReturnsInteger()
        {
            Program.FizzBuzz(11);
            Assert.Equal("11", "11");
        }
    }

```

