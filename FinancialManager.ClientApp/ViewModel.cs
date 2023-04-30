using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManager.ClientApp
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private ObservableCollection<DailyCategoryExpense> _dailyCategoryExpenses = new ObservableCollection<DailyCategoryExpense>();

        public IEnumerable<DailyCategoryExpense> DailyCategoryExpenses => _dailyCategoryExpenses;

        public ViewModel()
        {
            _dailyCategoryExpenses.Add(new DailyCategoryExpense("Product"));
            _dailyCategoryExpenses.Add(new DailyCategoryExpense("House"));
            _dailyCategoryExpenses.Add(new DailyCategoryExpense("Pets"));
            _dailyCategoryExpenses.Add(new DailyCategoryExpense("Childs"));
        }

        public string Date  => DateTime.Now.ToString();

        public int NumberOfChanges = 1;

        public decimal Amount => GetAmount();

        private decimal GetAmount()
        { 
            decimal amount = 0;

            foreach (TestCategory c in _dailyCategoryExpenses)
            {
                foreach (var item in c.Items)
                {
                    amount += item.CostPlane;
                }
            }

            return amount;
        }

        public void SaveAmount()
        { 
            //Code for saving changes in DB
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class DailyCategoryExpense : TestCategory
    {
        public DailyCategoryExpense(string name) : base(name) { }

        public bool IsChecked { get; set; }

        public decimal Input { get; set; }

    }

    public class TestCategory
    {
        public TestCategory(string name)
        {
            Name = name;

            Items.Add(new TestItem("item1", 500));
            Items.Add(new TestItem("item2", 300));
            Items.Add(new TestItem("item3", 700));
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TestItem> Items { get; set; } = new List<TestItem>();
    }

    [AddINotifyPropertyChangedInterface]

    public class TestItem
    {
        public TestItem(string name, decimal cost)
        {
            Name = name;
            CostPlane = cost;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public decimal CostPlane { get; set; }

        public decimal CostSpent { get; set; }
    }
}
