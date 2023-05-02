﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_access;

#nullable disable

namespace data_access.Migrations
{
    [DbContext(typeof(FinancialManagerDBContext))]
    [Migration("20230502084315_test10")]
    partial class test10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("data_access.Entities.Category_for_Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Category_For_Incomes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Salary"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Deposit"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Investment"
                        });
                });

            modelBuilder.Entity("data_access.Entities.Category_for_expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ActuallyExpense")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PlaneExpense")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Categories_For_Expense");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActuallyExpense = 0m,
                            Name = "Utility payments",
                            PlaneExpense = 0m
                        },
                        new
                        {
                            Id = 2,
                            ActuallyExpense = 0m,
                            Name = "Products",
                            PlaneExpense = 0m
                        },
                        new
                        {
                            Id = 3,
                            ActuallyExpense = 0m,
                            Name = "Money for the road",
                            PlaneExpense = 0m
                        });
                });

            modelBuilder.Entity("data_access.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses", t =>
                        {
                            t.HasCheckConstraint("Amount", "Amount >= 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1000m,
                            CategoryId = 3,
                            Day = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Month = "April",
                            Year = 2023
                        },
                        new
                        {
                            Id = 2,
                            Amount = 3000m,
                            CategoryId = 2,
                            Day = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Month = "April",
                            Year = 2023
                        },
                        new
                        {
                            Id = 3,
                            Amount = 2000m,
                            CategoryId = 1,
                            Day = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Month = "April",
                            Year = 2023
                        });
                });

            modelBuilder.Entity("data_access.Entities.ExpenseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExpenseItems", t =>
                        {
                            t.HasCheckConstraint("Amount", "Amount>= 0")
                                .HasName("Amount1");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 0m,
                            CategoryId = 1,
                            Name = "Electricity"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 0m,
                            CategoryId = 2,
                            Name = "Products for the home"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 0m,
                            CategoryId = 3,
                            Name = "Fuel for cars"
                        });
                });

            modelBuilder.Entity("data_access.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IncomeCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncomeCategoryId");

                    b.ToTable("Incomes", t =>
                        {
                            t.HasCheckConstraint("Amount", "Amount >= 0")
                                .HasName("Amount2");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 20000m,
                            IncomeCategoryId = 1,
                            Month = "March",
                            Year = 2023
                        },
                        new
                        {
                            Id = 2,
                            Amount = 5000m,
                            IncomeCategoryId = 2,
                            Month = "March",
                            Year = 2023
                        },
                        new
                        {
                            Id = 3,
                            Amount = 10000m,
                            IncomeCategoryId = 3,
                            Month = "March",
                            Year = 2023
                        });
                });

            modelBuilder.Entity("data_access.Entities.Expense", b =>
                {
                    b.HasOne("data_access.Entities.Category_for_expense", "category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("data_access.Entities.ExpenseItem", b =>
                {
                    b.HasOne("data_access.Entities.Category_for_expense", "category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("data_access.Entities.Income", b =>
                {
                    b.HasOne("data_access.Entities.Category_for_Income", "category")
                        .WithMany("Incomes")
                        .HasForeignKey("IncomeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("data_access.Entities.Category_for_Income", b =>
                {
                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("data_access.Entities.Category_for_expense", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
