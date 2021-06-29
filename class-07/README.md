# Class 07: Interfaces

## Learning Objectives
1. The student will understand the difference between inheritance and interfaces.
1. The student will be able to set up a hierarchy of classes that both inherit from a base class and implement at least one interface. 

## Lecture Outline

### Interfaces

Interfaces are traditionally used on more than one class, or better yet, have the ability to be used on more than one class. Interfaces
tell a class what it can do, versus inheritance, which tells a class what it has. 

Most commonly, in the development world, when working across teams, your team will receive an interface that must be implemented in your code. The interface defines what exactly this other team is expecting, and it is your job to define the functionality for each of those methods and properties. 

Why do you need interfaces?

- Sometimes you need to group your objects together based on the **things they can do** rather than the classes they inherit from. That is where interfaces come in, Interfaces let us work with any class that can do the job. Any class that implements an interface must promise to 'fulfill it's obligations' or the compiler will get upset. 
- Think of interfaces like 'actions' or 'protocols' that can be implemented on other classes

### Interfaces vs Inheritance
- Review inheritance
    - no multiple inheritance
- Review Polymorphism
- Implementing an interface
    - naming conventions
    - properties
    - methods
