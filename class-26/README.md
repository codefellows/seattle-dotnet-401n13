# Intro to MVC

## Learning Objectives

### Students will be able to

#### Describe and Define

- MVC Application Architecture
- The Azure Dev Ops Ecosystem

#### Execute

- Creation of a basic MVC Application
- Code management through ADO
- Azure Deployment using Pipelines

## Today's Outline

<!-- To Be Completed By Instructor -->

## Notes

### MVC
MVC is an architectural pattern used in web applications.
MVC is extremely helpful when it comes to separation of concerns.
This allows us to make changes to the front-end (view) without
affecting the business logic or the routes.

#### Model
The model holds the business logic. This is where
we will create new classes and "models" for any objects
we wish to use within our web application

#### View
This is our front-end. HTML and CSS is displayed on
the views. In addition, on the View, we reference the "Model" that was sent to the view from the controller.

A really cool feature in Views is that we can display the information
from the model on the .cshtml page by using very basic C# syntax.
This "Razor Syntax" allows us to use foreach loops and if statements
to manipulate how to display the information sent from the controller.

#### Controller

The controller is the routing part of MVC. A controller contains
Actions, that maps to specific views. Each unique action is it's own
view page.

### Azure Dev Ops

Azure Dev Ops is a popular tool that is used amongst
many developer teams to manage source code and tasks of projects.

We wil use Azure Dev Ops for the entirety of the E-Commerce project.
You will become comfortable with the environment and the tooling.
You will learn how to make User Story cards, manage them through the
KanBan board provided through weekly sprints.

Resources:
1. [Azure Dev Ops](https://dev.azure.com/)
1. [Team Explorer Reference](https://docs.microsoft.com/en-us/azure/devops/user-guide/work-team-explorer?view=azure-devops)

