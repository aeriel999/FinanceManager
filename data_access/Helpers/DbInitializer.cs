using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category_for_expense>().HasData(new Category_for_expense[]
            {
                new Category_for_expense()
                {
                    Id = 1,
                    Name="Utility payments",
                    PlaneExpense=5000,
                    ActuallyExpense=2500
                    
                },
                new Category_for_expense()
                {
                    Id = 2,
                    Name="Products",
                    PlaneExpense=3000,
                    ActuallyExpense = 2500

                },
                new Category_for_expense()
                {
                    Id = 3,
                    Name="Money for the road",
                    PlaneExpense=1500,
                    ActuallyExpense = 1200
                    

                }
            });
        }
        public static void SeedExpenseItem(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseItem>().HasData(new ExpenseItem[]
            {
                new ExpenseItem()
                {
                    Id=1,
                    Name="Electricity",
                    CategoryId=1,
                    //Amount=2500
                },
                new ExpenseItem()
                {
                    Id=2,
                    Name="Products for the home",
                    CategoryId=2,
                    //Amount=2500
                },
                new ExpenseItem()
                {
                    Id=3,
                    Name="Fuel for cars",
                    CategoryId=3,
                    //Amount=1200
                }
            });
        }
        public static void SeedCategoryIncome(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category_for_Income>().HasData(new Category_for_Income[]

            {
                new Category_for_Income()
                {
                    Id = 1,
                    Name="Salary",
                },
                new Category_for_Income()
                {
                    Id=2,
                    Name="Deposit"
                },
                new Category_for_Income()
                {
                    Id=3,
                    Name="Investment"
                }
            });
        }
        public static void SeedIncome(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Income>().HasData(new Income[]
            {
                new Income()
                {
                    Id = 1,
                    Month="March",
                    Year=2023,
                    Amount=20000,
                    Category_for_IncomeId=1
                },
                new Income()
                {
                    Id=2,
                    Month="March",
                    Year=2023,
                    Amount=5000,
                    Category_for_IncomeId=2
                },
                new Income()
                {
                    Id=3,
                    Month="March",
                    Year=2023,
                    Amount=10000,
                    Category_for_IncomeId=3
                }
            });
        }
     
    }
}
