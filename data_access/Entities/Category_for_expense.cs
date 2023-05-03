using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Category_for_expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExpenseItem> Items { get; set; }
        public List<Expense> Expenses { get; set; }
        public decimal PlaneExpense { get; set; }
        public decimal ActuallyExpense { get; set; }

        public Category_for_expense()
        {
            Items = new List<ExpenseItem>();
        }

        public void AddItenInCat(ExpenseItem i)
        {
            Items.Add(i);
        }
    }
}
