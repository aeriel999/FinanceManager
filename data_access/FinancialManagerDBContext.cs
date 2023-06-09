﻿using data_access.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using data_access.Helpers;



namespace data_access
{
    public class FinancialManagerDBContext:DbContext
    {

        public DbSet<Category_for_expense> Categories_For_Expense { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<Income> Incomes { get; set; }
       
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=.;
                                           Initial Catalog = FinancialManager_Db;
                                           Integrated Security=True; Connect Timeout=30;
                                           Encrypt=False;TrustServerCertificate=False;
                                           ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category_for_expense>().HasKey(c => c.Id);
            modelBuilder.Entity<Category_for_expense>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Expense>().HasKey(c => c.Id);
            //modelBuilder.Entity<Expense>().Property(e=>e.Month).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Expense>().Property(e=>e.Year).IsRequired();
            modelBuilder.Entity<Expense>().ToTable(e => e.HasCheckConstraint("PlaneAmount", "PlaneAmount >= 0"));
            modelBuilder.Entity<Expense>().ToTable(e => e.HasCheckConstraint("CurrentAmount", "CurrentAmount >= 0"));
            modelBuilder.Entity<ExpenseItem>().HasKey(ei => ei.Id);
            modelBuilder.Entity<ExpenseItem>().Property(ei => ei.Name).HasMaxLength(100).IsRequired();
            //modelBuilder.Entity<ExpenseItem>().Property(ei=>ei.Amount).IsRequired();
            modelBuilder.Entity<ExpenseItem>().ToTable(ei => ei.HasCheckConstraint("Amount", "Amount>= 0"));
            modelBuilder.Entity<Income>().HasKey(i=>i.Id);
            modelBuilder.Entity<Income>().Property(i=>i.Name).HasMaxLength(50).IsRequired();
         
            //modelBuilder.Entity<Income>().ToTable(e => e.HasCheckConstraint("Amount", "Amount >= 0"));
            
           

            ////////Підключення по ключам
            modelBuilder.Entity<Category_for_expense>().HasMany(c=>c.Items).WithOne(c=>c.category).HasForeignKey(c=>c.CategoryId);


            modelBuilder.Entity<Category_for_expense>().Property(c=>c.PlaneExpense).HasColumnType("money");
            modelBuilder.Entity<Category_for_expense>().Property(c=>c.ActuallyExpense).HasColumnType("money");
            modelBuilder.Entity<ExpenseItem>().Property(e => e.Amount).HasColumnType("money");

            modelBuilder.Entity<Expense>().Property(e => e.PlaneAmount).HasColumnType("money");
            modelBuilder.Entity<Expense>().Property(e => e.CurrentAmount).HasColumnType("money");
            modelBuilder.Entity<Income>().Property(i => i.Amount).HasColumnType("money");


            modelBuilder.SeedCategory();
            modelBuilder.SeedExpenseItem();
            //modelBuilder.SeedIncome();

        }

    }
    
}
