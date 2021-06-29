## Introduction to Web APIs

## What is a WEB API

## API
What does API mean? - Application Program Interface

#### HTTP Verbs
1. GET - Get a resource, should be repeatable w/o side effects
1. POST - "Do Some action" / create new resource/ super flexible
1. PUT - "Take a resource and put it somewhere" // If it doesn't exist, create it, if it does update it, should be repeatable w/o side effects
1. DELETE - Remove a resource

Stateless Request/reply protocol

What is an API?
1. An HTTP Service
1. APIs allow any platform to consume (anything that speaks http)
1. Accessible across the internet.

## REST

REST == Representational State Transfer <br />

How is data represented:
- JSON
- XML

What makes up an HTTP request?
1. Headers
1. Body - Can be any format (Json, XML, IMG, etc...)
1. Status Codes

Rules of HTTP are important and we can take advantage of everything else that the web contains within HTTP

**Status Codes**
- 200 - Ok
- 400 - Bad Request (Client Issue/Blame the client)
- 500 - Internal Server Error (Server Issue/ Blame the Server)


## Handling HTTP Requests in .NET Core
1. The server (Kestral) listens for the request
1. Middleware pipeline is invoked for each request
1. Use MVC to route requests to controller & Action
1. Responses flow back down the middleware pipeline.

## Key Terms
- Attribute Routing
- Route Templates
- Route Tokens
- Model Binding
- Model State
- Content Negotiations


## Get/POST

### Demo
- Create a new empty project.
- Add MVC Services in Startup
- Add Controllers Folder
- Create new API Controller/Class
----------
- Derive Controller from ControllerBase
- Cerate each of the actions by hand,
- Bring up `Attribute Routing` (Attribute Routes serve a purpose)
- Constrain which http methods/verbs that you want those action methods to handle
- Route template/pattern that should match the URI for any req that makes it to the action method
- create Get route
- Create Put route
- Create Post
- Create Delete

**Make sure to go over the key terms and how they integrate into the application**

- Create GET Action
- Talk about attribute routing
- model Binding
- Route constraints
- Create POST action
- Set up a database and DBContext to store data from API
