# Simple app using .NET as a backend, postgresql db, react and native react client

## .NET setup

Make sure that .NET sdk is installed in your system

> which dotnet && dotnet --version

If you dont have it install

> sudo snap install dotnet-sdk-100

Or

> sudo apt install dotnet-sdk-10.0

### Skip this part

To start a new .NET solution:

> dotnet new sln --name <your-new-app-name>
> dotnet new webapi --use-controllers -n <your-new-app-name> -o apps/api
> dotnet sln <your-new-app-name>.slnx add apps/api/<your-new-app-name>.api.csproj

### .NET packages

Probably you dont really need any packages to start building your app, however i like to keep it productive and use ef and postgresql packages that allow us to build effective and simple apps:

> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version '10._'
> dotnet add package Microsoft.EntityFrameworkCore.Design --version '10._'
> dotnet add package DotNetEnv

## PostgreSQL setup

Again make sure you have installed postgresql and you can use psql cli

> which psql && psql --version

If you dont have install

> apt install postgresql

Connect with postgres user and create new role owner

> sudo -u postgres psql
> CREATE ROLE <owner> WITH LOGIN PASSWORD <my_db_password>

Create a new database

> CREATE DATABASE <name> OWNER <owner>

Connecting to db through cli. Host and port could be changed as well, however default is localhost:5432

> psql "postgres://<owner>:<my_db_password>@localhost:5432/<name>"

Create .env file and place the db parameters:

> DEVELOPMENT_DB_NAME ="Host=localhost;Port=5432;Database=<name>;Username=<owner>;Password=<my_db_password>"

We read this parameter witht the help of DotNetEnv package inside Program.cs

```
using DotNetEnv
Env.TraversePath().Load()
var connectionString = Environment.GetEnvironmentVariable("DEVELOPMENT_DB_NAME")
```

Define the database context calcalc/apps/api/Data/AppDbContext.cs

```
using Microsoft.EntityFrameworkCore;
using calcalc.api.entities;

namespace calcalc.api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

        public DbSet<User> Users => Set<User>();

}
```

We then include this AppDbContext to the Program.cs

```
using calcalc.api.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
```

Install the db migration tool

> dotnet tool install --global dotnet-ef --version '10.\*'

Generate migration files describing the tables

> dotnet ef migrations add InitialCreate

Execute the migration against your developement db. So in general it checks the entities (sometimes its called models aswell) and based on that it creates columns.

> dotnet ef database update

You can check your db directly if the columns/tables has been created

> calcalc=> SELECT \* FROM "Users";
> Id | Email | PasswordHash | IsActive | IsVerified | CreatedAt | UpdatedAt
> ----+-------+--------------+----------+------------+-----------+-----------
> (0 rows)

To see if the project builds

> dotnet build

To build and run at the same time

> dotnet run

Test the api

> curl -i http://<host>:<port>/api/users/42
