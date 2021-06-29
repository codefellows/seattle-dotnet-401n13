# Relational Databases & ERDs

### Three Take-a-ways
1. What is the purpose of an ERD
1. What types of relationships are there?
1. Three different types of keys that exist in a relational database...

## What is a Database

### Different Kinds of Databases
1. Relational
	- SQL Server
1. Non-Relational
	- SQLLite

### Relational vs Non-Relational

1. Relational
	- Relational databases are databases where each table can hold a relationship with another. This is usually done through some sort of unique identifier that can require a row of each table to stay unique even after the many different transactions that process through. This allows for separation of concerns within a database and ability to manipulate individual parts of a grouped together information

1. Non-Relational
	- Non Relational databases don't depend on relationships or keys between tables. NoSQL is an example, and all the information is stored in one "document" that makes it potentially easier to group together information without having to join tables.
	Examples: Big Data, and Real Time Applications

## Representation
We can represent a relational database through an Entity Relationship Diagram.

### Database ERD

It may be helpful to pull up this article and show the example DB ERD [HERE](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model?view=aspnetcore-2.0)

About halfway down the page is a "complex" ERD model. Review it with the class and break it down if possible.

### Relations
1. 1:1
1. Many:Many
1. 1:Many
1. Many:1

### Keys
1. Primary Keys
1. Foreign Keys
1. Composite Keys (New!)

### Dissect an ERD

#### Tables
Each "box" in an ERD represents a table in the database. With each table you want to identify it's individual properties, and it's relationship to other tables in the ERD.

#### Properties
Within each individual table, properties exist. The properties represent the characteristics of the entity you are modeling within the table. Each property traditionally is a column header. Some properties of a table may be a key that exists in another table, such as a Foreign Key, or Composite Key. Each table may also have a unique identifier called a Primary key, usually just named `Id`.

#### Keys
1. Primary Keys
	 - Unique identifier for a specific table. Usually named `Id`.
	 - Each row of the table will have it's own unique primary key.
1. Foreign Key
	- Unique identifier from another table.
	- Often used to join tables within a query and associate table data.
	- Naming convention is the name of the table plus the word Id. Example: BookId is a foreign key in the Library Table. In the Book table, it is simply `Id`.
1. Composite Key
	- A combination of columns that make up a unique identifier for a table
	- Composite keys usually consist of multiple foreign keys combined together. No Primary key needs to be included in the combination.
	- You do not necessarily need to include a primary key in a table that utilizes a composite key.


### Many-to-Many in an ERD

1. Join Tables
	- With Payload
		- Has a primary key, and additional properties
	- Pure Join Tables (w/o Payload)
		- Composite keys. No additional properties.

1. Navigation Properties
	- Link to other entities that are related to the current
    entity.
	- Mostly seen in 1:Many and Many:1 relationships


## Resources:
- [Relational vs NonRelational](https://www.jamesserra.com/archive/2015/08/relational-databases-vs-non-relational-databases/)
