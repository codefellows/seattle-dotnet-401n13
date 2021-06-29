#  SQL

## Intro to SQL
SQL stands for Structured Query Language.


## Intro to Relational Databases
relational databases consist of one or more tables where
each table consists of 0 or records/rows.

## Terminology of a Relational Database
- Relation: a table in a database
- Tuple: a row within the table
- Attribute: column of a table
- Null: Value does not exist or is unknown
- Primary Key : key in a relation that is unique.
- Foreign Key: a dependency that exists in another relation, that is also
a primary key in another table/relation

## Database Schema

A DB schema is a logical design of a database.

### Basic Column Types
1. char : fixed length character
1. varchar: variable length character.
1. int : integers
1. smallint
1. numeric
1. real, double precision
1. float


##### Basic Schema Definition

```
create table department (
  dept_name varchar(20))
  building	varchar(15)
  budget	numeric(12,2)
  primary key(dept_name)
);
```

The relation above has 3 attributes:
1. dept_name
1. building
1. budget (12 digits total, 2 of which are after the decimal point)

The dept_name is also specified as the primary key

The data for each row is organized into discrete units of information, known
as fields or columns.

Many of the tables in a database will have relationships between them.
The different types of relationships we can have are

1. one to one
1. one to many
1. many to one
1. many to many

The connection between tables is made by Primary Keys and Foreign Keys.

#### Primary Keys

This is the unique, external, primary identifier for our database table

- Usually called `id` or `_id`
- Often, this is hidden and/or readonly
- Many RDBMS' also use internal keys such as `rowid`, `_rowid`

#### Foreign Keys
1. Foreign Key: this is a primary key from another table.

#### Example of a one-to-many

Customers to Orders can be a great one-to-many example.
both tables of Customers and Orders could potentially have a `CustID` field.
this is a primary key of the Customers table and a FK of the Orders table.

#### Many : 1



## Intro of Sql Server

### Setup of a database

### SSMS and connection

## Basic Queries

## Single Relations
The basic structure of an SQL query consists of three clauses
1. Select : used to list the attributes desired in the result of a query
1. From: list of the relations to be accessed in the evaluation of the query
1. Where: filtering of the relation through attributes that meet certain requirements from
the `from` clause.

The skeleton of a basic SQL query

```
select a1, a2, ... an
from r1, r2, .... rn
where P;
```

A stands for Attribute
r stands for relation/table
p stands for true

### Select

To query on a single relation, you use a basic select command:

"Select name from instructors"

```
Select name
from instructor
```

1. `name` is the attribute that we are looking for
1. `instructor` is the relation/table we are searching

### Distinct
In the event we do not want duplicates, we would use the word `distinct` after
`select` to specify that we do not want any duplicates in our output from the query.

Example:
```
select distinct dept_name
from instructor
```

the above query will give us only one of each dept_name off of the
instructor table. Since there is reasonable possibility that more than one
instructor in the table could be working in the same department.

### And/OR
The logical connectives of
1. `and`
1. `or`
1. `not`

are allowed in the where clause. The comparison operators that are allowed are:
1. `<` (less than)
1. `>` (greater than)
1. `<=` (less than or equal to)
1. `>=` (greater than or equal to)
1. `=` (equal)
1. `<>` (not equal)

### Where
The `where` clause allows us to filter out more specifically within the relation of what exactly we want to see.

```
select name
from instructor
where dept_name = 'Comp Sci' and salary > 70000;
```

The above query will filter out the results from the instructor relation
where the dept_name is labeled "Comp Sci" and the instructor salary is greater than 70k.

## On Multiple Relations
Sometimes it is necessary to make queries across multiple relations/tables.
Here are some examples about how we would approach these types of queries:

"Retrieve the name of all the instructors, along with their department names and building names"

```
select name,instructor.dept_name,building
from instructor,department
where instructor.dept_name = department.dept_name
```

A few things to note about this query:
-  We can assume that by looking at this query that dept_name exists in both
- The department and the instructor relations. We know this because we had to "note" this above with the "instructor.dept_name" to specify exactly what relation we are referring too.

### Select => Where

### Joins

### Natural Joins

A natural join will output a result where
both relations that are being joined meet the criteria of specific attributes matching.

Example:

"For all the instructors in the university who have taught some course, find their names
and the course ID of all courses they have taught."

```
select name, course_id
from instructor, teaches
where instructor.ID = teaches.ID
```

is the same as

```
select name,course_id
from instructor natural join teaches;
```

### Inner Joins

### Outer Joins

### Right Inner

### Left Inner

## Misc Commands

### Count

### Min/Max

### Group By

### Alias/Rename

Within SQL queries, we have the ability to rename certain attributes and relations
to make it easier to decipher which relation we are talking about.

It is completely possible that different relations specified in the from clause have the
same attributes. Often, we want to be able to distinguish between which one is which. We do that
by using the `as` clause. the format for this is

`old-name as new-name`.

Example:

```
select name as instructor_name, course_id
from instructor, teaches
where instructor.ID = teaches.ID
```

The above query allows us to rename the output of "name" to be more specific to "instructor_name"

Another Example:

```
select T.name, S.course_id
from instructor as T, teaches as S
where T.ID = S.ID
```

In the above example, we are allowed to specify the new name of the attribute name before specifying the name in the from clause.


Another reason to rename is if we want to compare one tuple against the same table. The following query is an example

"Find the names of all instructors whose salary is greater than at least one instructor in the Biology department"
```
select distinct T.name
from instructor as T, instructor as S
where T.salary > S.salary and s.dept_name = "Biology"
```

Both `T` and `S` are considered Aliases. Each of these aliases represent
their appropriate relation as individual relations, even if they are the same.

### Sort/Order By

The `order by` allows us to display which tuples/rows appear first within our query.

```
select name
from instructor
where dept_name = 'Physics'
order by name;
```

if there is possibility of duplicates, we can say order duplicate by asc

```
select *
from instructor
order by salary desc, name asc
```
the above query will say to order by salary, but if there are multiple with the same salary order them by name asc.

### LIKE

1. %(Percent): matches any substring
1. _(Underscore): the _ character matches any character

Patterns are case sensitive. Here are some examples of pattern matching:
1. `Intro%` matches any string beginning with "Intro"
1. `%Comp%` matches any string containing "Comp" as a substring. Such as "Intro to Computer Science"
1. `_ _ _` matches any string of exactly 3 characters
1. `_ _ _ %`matches any string of at least 3 characters

The `like` operator is used for comparison.

"Find all the departments who are located in the Watson building"

```
select dept_name
from department
where building like '%Watson%';
```

The Escape (`\`) character is accepted within sql queries as well if any special characters exist in the data you are targeting.

### SubQueries

## Modifications to a DB
### Create Table

## Update Table
```
update instructor
set salary = salary*1.05;
```


### Alter Table

`alter table r add A D;` - r is the name of the existing relation. A is the attribute
and D is the data type.

`alter table r drop A;` - r is the name of the existing relation, A is the name of the attribute to be removed.


### Insert into Table

To insert, you specify what relation to insert into, and then the appropriate
attributes to insert.

```
insert into course
values ('CS-437', 'Database Systems', 'Comp.Sci', 4)
```

### Delete/Drop Table


`drop table r` - deletes not only all the tuples/rows of r, but also
the schema for r. After r is dropped, no tuples can be inserted into r unless
it is re-created with the "create table" command.

`delete from r` - retains the relation of r, but deletes all the tuples in r.


`Delete from r
where P`

Delete a specific row from the table r, where the P condition is met.


#### Indexing
Indexing is...

##### Query Optimization
Optimize Queries...
BTree



