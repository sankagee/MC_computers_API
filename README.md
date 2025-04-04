# MC Computers API Setup Guide

For ASP.NET Web API Backend :

.NET SDK 8.0

SQL Server

# 1. Setting Up the Backend (ASP.NET Web API) 

## Step 1 :

[Clone the Repository](https://github.com/sankagee/MC_computers_API.git)

## Step 2 : 
 Go to MC_computers_API folder : `cd MC_computers_API`

## Step 3 : 

Install Dependencies : `dotnet restore`
## Step 4: 

Build the Project : `dotnet build`

## Step 5 : Configure the Database
Open the `appsettings.json` file in the `MC_computers_API` folder.

Update the connection string to point to your SQL Server instance : Add Your Server Name in SQL Server

    `"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=McComputersDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }`

## Step 6: Apply Migrations

The backend uses Entity Framework Core to manage the database schema. 

To migrate the tables to your database: (Sample Data also Available (Seed Data))

	`dotnet ef migrations add InitialCreate`
 
	`dotnet ef database update`

## Step 7: Run the Web API

`dotnet run`


# Running Unit Tests

This project uses xUnit for unit testing. Follow these steps to run the tests:

## Step 1: Navigate to the Test Directory

Ensure you are in the root directory of the project:

`cd MC_computers_API`

## Step 2: Restore Dependencies

Restore dependencies for both the main project and test project:

`dotnet restore`

## Step 3: Build the Solution

Build the solution to ensure all projects compile successfully:

`dotnet build`

## Step 4: Run All Tests

Run all unit tests using the following command:

`dotnet test`
## Or Run Specific Tests

To run specific tests,

`dotnet test --filter "FullyQualifiedName~MC_computers_API.Tests.Controllers.ProductsControllerTests"`

Thank you.
