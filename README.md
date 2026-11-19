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
