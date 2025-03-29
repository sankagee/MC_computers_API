# MC_computers_API Running the Application

# 1. Setting Up the Backend (ASP.NET Web API) 

## Step 1 : [Clone the Repository](https://github.com/sankagee/MC_computers_API.git)
## Step 2 : `cd MC_computers_API`
## Step 3 : Install Dependencies : `dotnet restore`
## Step 4 : Configure the Database
Open the `appsettings.json` file in the `MC_computers_API` folder.
Update the connection string to point to your SQL Server instance : Add Your Server Name in SQL Server

`"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=McComputersDB;Trusted_Connection=True;TrustServerCertificate=True;"
}`

## Step 5: Apply Migrations
The backend uses Entity Framework Core to manage the database schema. 

To migrate the tables to your database: (Sample Data also Available (Seed Data))

	`dotnet ef migrations add InitialCreate`
 
	`dotnet ef database update`

## Step 6: Run the Web API
