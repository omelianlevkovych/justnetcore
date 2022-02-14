# getting started
## asp.net core and reverse proxies
You can expose .net core app directly to the internet, so that Kestrel receives requests directly from the network. However, it is more common to use a reverse proxy between the raw network and your app. Hosted in Windows, the reverse proxy will typically be IIS, on Linux or macOS it migh be NGINX, HAProxy or Apache.

**Reverse proxy** is software responsible for receiving requests and forwarding them to the appropriate web server. The reverse proxy exposed directly to the internet, whereas the underlying web server is exposed only to the proxy. This setup has several benefits, primarly security and performance for the web server.

Some benefits:
* Why just not have reverse proxy or web server as one unit? The main benefit here is the decoupling of your application from the underlying operating system. The same ASP.NET Core web server, Kestrel, can be cross platform and used behind a variety of proxies without putting any constraints on a particular implementation.
* Another benefit of reverse proxy, it can be hardened against some potential treats from the public internet. They are often responsible for additional aspects, such as restarting process that has crashed. Kestrel can remain a simple HTTP server not having to worry about these extra features when it's used behind a reverse proxy. Think of it as simple separation of concerns: Kestrel is concerned with generating HTTP responses; the reverse proxy is concerned with handling the connection to the internet.

## Overview of an asp.net core app
page. 59 drawing

**The HttpContext** object is constructed by asp.net core web server (kestrel) and used by the app as a sort of a storage box for a single request. Anything specific for this particular request and the future response can be associated with it and stored in it. This could include properties of the request, request-specific services, data that's benn loaded, or errors that have occured. 
The web server fills the initial HttpContext with details of the original HTTP request and other configuration details and passes it to the rest of application.

By the way, the Kestrel is not the only HTTP server available there, but its most performant and also cross-platform. The main alternative is HTTP.sys, only runs on Windows and can't be used with IIS.

### Getting your app up and running
To start follow this simple steps:
* generate - create the basic app from a template
* restore - restore all the packages and dependencies to the local project folder using NuGet
* build - compile the app and generate the neccessary assets
* run - run the compiled app

E.g to create a new razor page app with CLI:
```sh
dotnet new sln -n WebApplication1
dotnet new webapp -o WebApplication1
dotnet sln add WebApplciation1
```
after that you can build and run the app:
```sh
dotnet restore
dotnet build
dotnet run
```
Each of this commands should be run inside your project folder and will act on that project alone.
#### dotnet restore
Most .net core apps have dependencies on various external libraries, which are managed through the NuGet package manager. This dependencies are listed in the project, but the files of the libraries themselves aren't included. Before you can build and run your app, you need to ensure there are local copies of each dependency in your project folder. This command _dotnet restore_ ensures that your apps NuGet dependencies are copied to your project folder.

In most cases, you don't need to explicitly use the _dotnet restore_ command, since a NuGet restore is run implicitly if necessary when you run the following commands:
```sh
dotnet new
dotnet build
dotnet build-server
dotnet run
dotnet test
dotnet publish
dotnet pack
```
Sometimes, it might be inconvenient to run the implicit NuGet restore with these commands. For example, some automated systems, such as build systems, need to call dotnet restore explicitly to control when the restore occurs so that they can control network usage. To prevent the implicit NuGet restore, you can use the --no-restore flag with any of these commands to disable implicit restore.

ASP.NET Core projects list their dependencies in the project’s .csproj file. This is an XML file that lists each dependency as a PackageReference node. When you run dotnet restore, it uses this file to establish which NuGet packages to download and copy to your project folder. Any dependencies listed are available for use in your application.
