# 401 ASP.NET Core Curriculum Overview

The ASP.NET curriculum is broken up into three main modules:
1. Intro to C#
1. ASP.NET Web Development
1. E-Commerce Project

## Module 1 - Into to C#
This module consists of introduction to C#. You will spend the next 10 classes
teaching the students C# and getting them ready to go into ASP.NET Core web development. ASP.NET Core assumes
an intermediate knowledge of C#, so we have 10 classes to get the students to that level. The focus
on these 2 weeks is primarily computer-science related and does not work with the web. The lab assignments are all
console apps and focus on practicing the c# concepts taught daily.

### Week 1 - Fundamentals
1. Exception Handling
   - LAB: About Me
1. Unit Testing
   - LAB: ATM
1. System.IO
   - LAB: Word Guess Game
1. Classes, Stack/Heap, Garbage Collector
   - LAB: Tic-Tac-Toe
1. OOP Principles
   - LAB: Zoo Part 1

Data Structures: 
	- How to Approach a DS
	- String & Array manipulation
1. Quiz 1

### Week 2 - Advanced Concepts

1. Interfaces
   - LAB: Zoo Part 2
1. Collections (Generic) & Enums
   - LAB: Deck of Cards
1. LINQ & Lambda Expressions
   - LAB: LINQ in Manhattan
1. Design Patterns
   - LAB: Design Patterns
1. Stacks & Queues // Recursion
   - LAB: None

Data Structure: Linked Lists

Quiz 2

## Module 2 - ASP.NET Web Development
Weeks 3 & 4 introduce the concept of web development. The students
will dive into MVC and learn what an MVC application consists of. They will 
model a database with an ERD and create a hotel asset management system through the course
of the 2 weeks using ASP.NET MVC Core and Dependency Injection. They will end this module
with an intro to REST APIs in ASP.NET and building out their own API server. 

### Week 3 - MVC & Entity Framework Core
1. MVC Intro
   - TIME person of the year MVC App
1. Relational Databases & schemas
   - Lab: System Design//Design a schema
1. CRUD Intro to Entity Framework
   - Lab: `AsyncInn` Hotel Project Part 1
	- Create Models from DB schema
	- Identify Primary Keys/Foreign Keys/Composite Keys
1. Entity Framework part 2
   - LAB: EFCore Seeding/View Models/Tag Helpers
1. Career Coaching

Data Structure: Stacks/Queues

Quiz 3

### Week 4 - Repository Design Pattern & APIs
1. Dependency Injection & Repository Design Pattern
   - Incorporate the Repository Design Pattern into lab
   - Introduce Singleton Design Pattern
1. Azure Deployment & Unit Tests
	- Deploy app to Azure and write basic tests
1. API Introduction
   - TODO List Part 1
1. API - API part 2
   - LAB: Making a call out to an API
1. Midterm Project Kickoff

Data Structures: Trees (Binary, BST, K-ary)

Quiz 4

### Week 5 - Midterm Project
Midterm Project week
1. Build a Full CRUD web app
1. Build a custom API
1. Make the Web app call out to the API

## Module 3: E-Commerce Project

The second half of the class focuses on one major project. The students
and a partner work together to build out an E-Commerce store. The second half
is broken up into (3) 1-week sprints. Each week is broken into daily milestones. 
Each milestone consists of 3-5 user stories that are divided amongst all developers
in a team. 

Each day, the developers will complete their respective user stories. Each day builds
off the prior, so it is important that all user stories from one day is completed
before the next. 

*Projects are only submitted at the end of each sprint* - This allows for
students to progress towards an "end of week sprint" goal instead of feeling rushed
everyday to complete the given tasks. This is also intentional to emulate a real-world
team where in an agile environment, they are given until the end of the sprint to complete all the 
tasks that are assigned to them each day. 

Students will use Azure Dev Ops (ADO) as their project management tool and Azure Repos as their source control. They will 
use the ADO kanban board to create and manage user stories. 


### Week 6 - Sprint 1: Authentication/Authorization
1. Intro to E-Com project and PM Tool "Azure DevOps"
	- Beginning of Sprint 1: Create a basic MVC app with database
1. Intro to Identity: Setup & Registration
	- Implement Identity API and create use registration
1. Login and Claims
	- Add Login page to E-Com and capture specific claims
1. Custom Policies
	- Create policies to customize access across the site with previous claims
	- END OF SPRINT 1
1. Career Coaching

Data Structure: Hash Tables

Quiz 5

#### Azure Dev Ops
1. Sprint Backlog
1. Create User stories with tasks and Acceptance tests
1. Task Branching
1. Time estimation
1. PRs within Azure Dev Ops
1. Peer Reviews
1. Weekly Goals and Retrospectives

### Week 7: Sprint 2  
1. View Components
	- SPRINT 2 START
	- Add a "Basket" component to E-Com site
	- System Design exercise - Integrate basket capabilities into the site with DB tables
1. OAUTH
	- Add 2 3rd party providers as login to project
1. AUTH.NET (How to read 3rd party Docs)
	- Incorporate "fake" payment processing into project
1. Razor Pages 
	- Add in user profile & admin dashboard page as Razor Page
	- END OF SPRINT 2
1. Review Day

Data Structure: Graphs 

Quiz 6

### Week 8 - Sprint 3: Azure
1. Sass//SCSS
	- SPRINT 3 START
1. Email Services
	- LAB: Incorporate SendGrid into project 
1. Azure Blob Storage
	- LAB: Save all product images in Azure Blob Storage
1. Web Security
	- OWASP security Requirements
	- HTTP and SSL 
	- GDPR
	- LAB: Vulnerability Report
	- END OF SPRINT 3
1. Career Coaching

Data Structure: Sorting Algorithms


Quiz 7

### Week 9 - MISC.
1. .NET 4.8 MVC & Web Forms
1. General Overall Review
1. Ethics in Technology
1. Open Source Contribution 
	- Learn, Investigate, and Contribute to an open source project
1. Final Project Kickoff

Data Structures: Mock Interviews

Quiz 8

### Week 10 - Final Project Week
Final Project Week

1. Build a full-stack app with ASP.NET Core
1. Collaborate as a team with git and VSTS
1. Present on completed project: test coverage, performance, security, and privacy 

