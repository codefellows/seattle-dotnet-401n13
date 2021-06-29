# Object Oriented Programming Principles

## Procedural Programming vs OOP Programming

### Procedural Programming (imperative programming)
Procedural programming is a list of instructions that tells program what to do step by step.

Procedural relies on a series of computational steps to be carried to completion.

This is usually done telling the program what to do first at the beginning, and what to do at the end. it is a bit more intuitive and simple to read from top to bottom. Procedural programming languages are also called "top down "


### What is Object Oriented Programming?
Object oriented programming is mimicking real world objects in code. Everything in C# is essentially a class, and we can instantiate objects from classes that we can manage at a smaller level.

OOP objects are created to interact with other elements of the program regardless of where the command is being called from.

## Inheritance

Inheritance can be described as a vital principle in the Object Oriented Programming principles. Inheritance can be described as the ability to pass along certain behaviors and properties to "derived" classes. This means that a `Cat` can be derived from an `Animal`, and so can a `Fish`. Both a Cat and a fish are very different animals, but both can be categorized as an animal.

Inheritance allows us to "share" behavior and properties to it's derived classes meaning we can follow that DRY principle. If you find yourself making the same methods and properties on multiple classes, that means that you may be able to implement inheritance into the class structure.

Inheritance is heavily used in OOP development. it is vitally important that you are able to decide when you need to use inheritance vs just adding the methods and properties individually into a class.


## Abstraction

Abstraction is the 2nd OOP principle. Abstraction can defined and looked at as a template for future classes that will soon be derived and instantiated.

There are 2 types of classes in Object Oriented Programming:
1. Abstract classes
1. Concrete classes

This means that a class can be one or the other...not both.

A concrete class can be instantiated...or made into an object.

You are not able to instantiate an abstract class....because it's sole purpose is to be used as a template for future class usages.

A good way to describe it is to use the example of buying a vehicle.

If someone you know states "I just bough a new car!", usually the first question that gets asked is "Oh, What kind?".

By simply asking "what kind" means that more information is needed in order to determine the end result of the vehicle.

> *If more information is required for that object to be instantiated, the class is likely abstract.*

## Polymorphism

Polymorphism is the ability to be able to change/manipulate the behavior of the
classes that it is derived from.

Breaking down polymorphism...poly means many. Morphism means to change. Putting this together solidifies the ability to change certain methods and properties as needed or required.

Polymorphism usually targets methods specifically. There are 3 different types of methods:
1. concrete - cannot be overridden, contains functionality for the class
1. abstract - just a method signature, and required to override
1. virtual - optional to override

In addition to being able to override behavior from base classes....Polymorphism also allows us the ability to see if a class `is a` another type. For example, Is a cat an Animal? If Cat is derived from Animal, then the answer is yes.


## Encapsulation

Encapsulation is C#'s way of access control. This allows us to determine what external classes have access to specific methods and properties.

Encapsulation breaks down to 3 most common access modifiers:
1. Public - Everyone has access to it
1. Private - only the class it is located in has access to it
1. Protected - only the class itself and it's derived classes have access
