# ContactManager
This Is a small application with minimal Implementation

I use the following technologies on this project:

- ASP.NET Core
- Entity Framework (with Migrations)
- SQL Server (+ Stored Procedure)
- Unit of Work Pattern
- Use microservice architecture; for example, on the online shop, each service should be implemented on its own Docker Image.

This sample application has 2 microservices:
## Contract microservice
This microservice implements CRUD operation using generic Repository and unit of work pattern.
Use [Dapper](https://dapper-tutorial.net/) as Micro ORM to call store procedures and work with the database.
Use Entity Core Migration to Initial database with related tables and store procedures.

## SocialMedia microservice
This microservice implements CRUD operation using generic Repository and custom repository base on a unit-of-work pattern Using Entity framework core.

I Use Microsoft SQL Server as database for both microservices,
also use [swagger](https://swagger.io/) in each microservice to document my APIs.

Do not forget to change  ConnectionStrings in the appsettings.json file for each microservice.
Each microservice has it,s own configuration, classes, files and has its own docker file.

To  create docker image file on the directory that has .sln file type following commands:
```
docker build -f [PhysicalPath] -t [ImageName]
```
To run your containers use following commands:
```
docker run --rm -it -p 5000:80 [ImageName]:latest
```
