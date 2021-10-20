# ContactManager
This Is a small application with minimal Implementation

I Use the following technologies on your project:

ASP.NET Core
Entity Framework (with Migrations)
SQL Server (+ Stored Procedure)
Unit of Work Pattern
Use microservice architecture; for example, on the online shop, each service should be implemented on its own Docker Image.

This sample application has 2 microservices:
## Contract microservice
this microservice implements CRUD operation using generic Repository and unit of work pattern.
I call store procedure using dapper/ADO.NET.
I use entity framework core Migration to capture all stages in creating tables and store procedures in a database.

## SocialMedia microservice
this microservice implements CRUD operation using generic Repository pattern and custom repository base on a unit-of-work pattern.
I use entity framework core for all operations.

I Used a Microsoft SQL server for both microservices.
I use swagger in each microservice to document my APIs in each microservice.

Do not forget to change  ConnectionStrings in the appsettings.json file for each microservice.
Each microservice has it,s own configuration, classes, files and has its own docker file.

To  create docker image file frim Docker file in the directory that has .sln file type:
```
docker build -f SocialMedia\Dockerfile -t contact_service_image
docker build -f Contact\Dockerfile -t socialmedia_service_image
```
to run your containers type :
```
docker run --rm -it -p 5000:80 contact_service_image:latest
docker run --rm -it -p 5001:80 socialmedia_service_image:latest
```
You can change the image names and paths base on your configuration.

