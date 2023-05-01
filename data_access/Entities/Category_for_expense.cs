﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Category_for_expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExpenseItem> Items { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}