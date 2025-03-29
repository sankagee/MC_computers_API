using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MC_computers_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "CreatedAt", "Cus_Name", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St, City, LK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nimal", "Nimal@example.com", "123-456-7890" },
                    { 2, "123 Main St, City, LK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamal", "Kamal@example.com", "987-654-3210" },
                    { 3, "123 Main St, City, LK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amal", "Amal@example.com", "555-123-4567" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 3);
        }
    }
}
