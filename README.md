# Quan Ly Quan Net

.NET Programming Exercise: Build a simple website using C# Programming Language, using ASP.NET Core and 3 Layer Model MVC (Model - View - Controller).
- Programming Language: C#
- ORM: Entity Framwork Core
- Database: SQL Server
- Framework: ASP.NET Core

About this project:
This is the learning project
... descriptions //

How to install:
- Download the project.
- Change the connection string that match your database in the file appsetting.json
- Run command: 
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet ef migrations add NewMigrationUpdate
    dotnet ef database update
    dotnet run
