using PropertyChanged;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;


namespace data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Category_for_expense 
    {
        private decimal _getPlaneExpense;

        public Category_for_expense(string name)
        {
            Name = name;
        }

        public Category_for_expense() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<ExpenseItem> Items { get; set; } = new List<ExpenseItem>();

        public List<Expense> Expenses { get; set; }

        public decimal ActuallyExpense { get; set; }

        public decimal PlaneExpense { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        [NotMapped]
        public bool CanEdit { get; set; }

        [NotMapped]
        public decimal GetPlaneExpense { get => GetPlaneAmount(); set => _getPlaneExpense = value; }

        public void AddItenInCat(ExpenseItem i)
        {
            Items.Add(i);
        }

        private decimal GetPlaneAmount()
        {
            decimal price = 0;

            foreach (var item in Items)
            {
                price += item.Amount;
            }

            return price;
        }

        public void UpdateAmount()
        {
            GetPlaneExpense = GetPlaneAmount();
        }
    }
}
