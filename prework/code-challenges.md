# Code Challenges 
For each of the challenges below, create a new method in a single Console application. All of your code should live in the `Program.cs`
file. Utilize the `Main()` method to call each challenge method, you may create additional external methods as appropriate.

Each challenge should be it's own branch. Practice using your git work flow during the construction of this project. Refer to the git work flow doc as a reference. 

## Problem 1: Array Max Result

#### Problem Statement
Given an array select a number that exists, and output the computated "score". The method you create should take in
both an array of integers and the integer the user selected.

Create a Console application that requests 5 numbers between 1-10 from the user. Output the array to the console and ask the user to
select a number. After the selection, output the "score" of the number chosen.

#### Selection and Scoring Algorithm
You can select any number from the list, however your scoring will be depend on the frequency of that number in the list. 
E.g for [2,2,3,5,4] if you pick 2 your score will be 4 (2 * 2) but if you pick 5 your score will be 5 (5 * 1)

#### Input Format
An array of integers, and the number chosen.

#### Sample Input
[6,4,4,1,3] , 4

#### Sample Output
8

#### Readme
A section of your readme should contain basic information outlining the requirements for the challenge
1. Name of Challenge
2. Instructions of Challenge
3. Screen capture of successful output. 



<hr />

## Problem 2: Leap Year Calculator

#### Problem Statement
Given a year, report if it is a leap year.

The tricky thing here is that a leap year in the Gregorian calendar occurs:

```
on every year that is evenly divisible by 4
  except every year that is evenly divisible by 100
    unless the year is also evenly divisible by 400

```

For example, 1997 is not a leap year, but 1996 is. 1900 is not a leap year, but 2000 is.

Want to know more about Leap Year? Watch this 4 minute video [HERE](https://www.youtube.com/watch?v=xX96xng7sAE){:target="_blank"} 

Note: This is not a trick problem. Edge cases do not need to be taken into consideration when creating a solution.

#### Readme
A section of your readme should contain basic information outlining the requirements for the challenge
1. Name of Challenge
2. Instructions of Challenge
3. Screen capture of successful output. 

<hr />

## Problem 3: Perfect Sequence

#### Problem Statement
Given an array, return "Yes" if the sequence is considered a perfect sequence. Otherwise, return "No"

#### Perfect Sequences
A perfect sequence is a sequence such that all of its elements are non-negative integers and the product of all of them is equal to their sum. 
For example: [2,2], [1,3,2] and [0,0,0,0] are perfect sequences and [4,5,6] and [0,2,-2] are not perfect sequences. Negative numbers of any kind are not valid in a perfect sequence

#### Input Format
An array of integers (may not be sorted)

#### Sample Input
[1,3,2]

#### Sample Output
Yes

#### Explanation
1 * 3 * 2 = 6 && 1 + 3 + 2 = 6

#### Readme
A section of your readme should contain basic information outlining the requirements for the challenge
1. Name of Challenge
2. Instructions of Challenge
3. Screen capture of successful output. 


<hr />

## Problem 4: Sum of Rows

#### Problem Statement
Given a matrix of integers. Return the sum of each row in a single dimensional array. 

#### Input Format
a multidimensional array with the dimensions of **m x n** (m = rows, n = columns).

1. duplicate integers are possible.
2. Negative numbers are possible
3. both **m** and **n** can vary in length

The user should specify the length and the width of the array within the console. To populate the numbers, you may randomly generate them, or have the user input one by one.

***The method should take in the multidimensional array and return the single dimensional array with the sums***

#### Sample Input
```csharp
int[,] myArray = new int[3, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 } };
```

^^ The actual input would just be `myArray`, but the above code shows the pre-initialization before the method is called. 

#### Sample Output

{15,40,65} <-- an integer array

#### HINTS
- for loops are your best friend
- GetLength() is a method you should look into
	- i.e. in the array above myArray.GetLength(0) is equal to 3
	- myArray.GetLength(1) is equal to 5
	

#### Readme
A section of your readme should contain basic information outlining the requirements for the challenge
1. Name of Challenge
2. Instructions of Challenge
3. Screen capture of successful output. 

