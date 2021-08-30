# Lab: Create an API for the Salmon Cookies Application

## Overview

Your job is to create an API suitable for handling the CRUD operations for the Pat's Salmon Cookie Stand operation

## Feature Tasks and Requirements

1. Create and work in a new repository at GitHub, called: `cookie-stand-api`
1. Create and setup a Web App and Database at Azure
   - Use the Free Tier!
1. Create an API, backed by a database with the following requirements:

### API

1. **POST**: `/api/cookiestand`
   - Accepts an object with the following shape:

     ```json
     {
        "location": "Barcelona",
        "description": "",
        "minimum_customers_per_hour": 3,
        "maximum_customers_per_hour": 7,
        "average_cookies_per_sale": 2.5,
        "owner": null
     }
     ```

1. **GET**: `/api/cookiestands`
   - Returns a JSON object with the following shape:

     ```json
     [
       {
         "id": 336,
         "location": "Barcelona",
         "description": "",
         "hourly_sales": [
           17,
           7,
           7,
           7,
           15,
           17,
           7,
           7,
           12,
           7,
           7,
           10,
           17,
           17
         ],
         "minimum_customers_per_hour": 3,
         "maximum_customers_per_hour": 7,
         "average_cookies_per_sale": 2.5,
         "owner": null
       }, ...
     ]
     ```

1. **GET**: `/api/cookiestand/{id}`
   - Returns an object formatted as above, for a single cookie stand with the given ID
1. **DELETE**: `/api/cookiestand/{id}`
   - Deletes a cookie stand with the given ID
   - Returns no content
1. **PUT**: `/api/cookiestand{id}`
   - Accepts a JSON Object formatted as a POST object.
   - Note: Requires the ID to be included in the object
   - Return the cookie stand object as saved in the database

### Notes and Open Questions

1. Where are the values (hourly sales) coming from?

### Tests

No testing required.

## Submission Instructions

- Provide a README with proper documentation for the usage of your app
  - Include your ERD and UML
- Prove the URL to your deployed API Swagger Documentation

### Stretch Goals

- Add authentication to the API
- Add a register and a login route to allow users to create accounts and login
- Require that only users in the Administrative group can perform any of the above actions
  - The API will need to accept a JWT Token in the headers of all requests
- TESTS
