# Introduction to Databases and ERDs

Description Here

## Learning Objectives

### Students will be able to

#### Describe and Define

- SQL and Relational Databases
- Table Relations
- Keys (Primary and Foreign)

#### Execute

- Construct an ERD to describe a problem domain

## Today's Outline

- Overview: Anatomy of a web application in .net
- Deep Dive: Database Design

## Notes

### What is a Database

A database is used to persist and store data across applications. We use databases to save information such as logins, user data, and any other information that is required to persist across the site.

### Different Kinds of Databases

1. Relational
	- SQL Server
1. Non-Relational
	- SQLLite

### Relational vs Non-Relational

1. Relational
	- Relational databases are databases where each table can hold a relationship with another. This is usually done through some sort of unique identifier that can require a row of each table to stay unique even after the many different transactions that process through. This allows for separation of concerns within a database and ability to manipulate individual parts of a grouped together information

1. Non-Relational
	- Non-Relational databases don't depend on relationships or keys between tables. NoSQL is an example, and all the information is stored in one "document" that makes it potentially easier to group together information without having to join tables.
	Examples: Big Data, and Real Time Applications

### Representation
We can represent a relational database through a database schema.

1. 1:1
1. Many:Many
1. 1:Many
1. Many:1

### Keys
1. Primary Keys
1. Foreign Keys
1. Composite Keys (New!)

	- Primary Keys
	  - A unique identifier for a specific table. Usually named `Id`.
	  - Each row of the table will have it's own unique primary key.
	- Foreign Key
		- The unique identifier from another table.
		- Often used to join tables within a query and associate table data.
		- Naming convention is the name of the table plus the word Id. Example: BookId is a foreign key in the Library Table. In the Book table, it is simply `Id`.
	- Composite Key
		- A combination of columns that make up a unique identifier for a table.
		- Composite keys usually consist of multiple foreign keys combined together. No Primary key needs to be included in the combination.
		- You do not necessarily need to include a primary key in a table that utilizes a composite key.

### Create a Database Schema

Together, in class, create a database schema given a problem domain.
