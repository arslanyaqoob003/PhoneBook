Introduction :-

PhoneBook is Companies and Persons finder service. This Project is based on Lab task Abstract Data Types and Polymorphism Design Patterns and Fault Tolerance. 
The project is implemented in Onion Architecture where every service and repository is unit testable. 
We can use its services to develop desktop applications or expose an API.
I try to follow Domain Driven Design (DDD) as much as possible.

	Architecture:-
	 PhoneBook.Api            (Can expose API)
	 PhoneBook.Application    (Business Logic & Service Layer)
	 PhoneBook.Core           (Domain models, exceptions and interfaces)
	 PhoneBook.Infrastructure (Database, Files and other depencies)


Getting Started :-

Install Dotnet Core SDK (https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.101-windows-x64-installer)
Go to PhoneBook.Test directory of project using console
Enter "dotnet test" command in CMD to Run all 15 tests of use case


Contribute :-
Arslan Yaqoob (Arslanyaqoob003@gmail.com)

Dependencies :-

Microsoft.NET.Sdk
Entity Framework Core
Automapper
XUnit
Xunit.Priority
FluentAssertions
Asp.Net Core (optional)