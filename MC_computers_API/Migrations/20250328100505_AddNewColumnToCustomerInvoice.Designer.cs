﻿// <auto-generated />
using System;
using MC_computers_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MC_computers_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250328100505_AddNewColumnToCustomerInvoice")]
    partial class AddNewColumnToCustomerInvoice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MC_computers_API.Models.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cus_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MC_computers_API.Models.Entities.CustomerInvoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceID"));

                    b.Property<decimal?>("BalanceAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InvoiceID");

                    b.ToTable("CustomerInvoices");
                });

            modelBuilder.Entity("MC_computers_API.Models.Entities.InvoiceDetails", b =>
                {
                    b.Property<int>("InvoiceDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceDetailID"));

                    b.Property<int>("InvoiceID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceDetailID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ProductID");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("MC_computers_API.Models.Entities.Products", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MC_computers_API.Models.Entities.InvoiceDetails", b =>
                {
                    b.HasOne("MC_computers_API.Models.Entities.CustomerInvoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MC_computers_API.Models.Entities.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MC_computers_API.Models.Entities.CustomerInvoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
