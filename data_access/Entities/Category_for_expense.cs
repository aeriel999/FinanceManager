using PropertyChanged;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;


namespace data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Category_for_expense
    {
        private decimal _planeExpense;

        public Category_for_expense(string name)
        {
            Name = name;
        }

        public Category_for_expense() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<ExpenseItem> Items { get; set; } = new List<ExpenseItem>();

        public decimal ActuallyExpense { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        [NotMapped]
        public bool CanEdit { get; set; }

        [NotMapped]
        public decimal DailyCostSpent { get; set; }

        public decimal PlaneExpense { get => GetPlaneAmount(); set => _planeExpense = value; }

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
            PlaneExpense = GetPlaneAmount();
        }
    }
}
