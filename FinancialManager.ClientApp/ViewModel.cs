using data_access;
using data_access.Entities;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinancialManager.ClientApp
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel : IDisposable
    {
        private FinancialManagerDBContext _dBContext = new FinancialManagerDBContext();

        private ObservableCollection<Category_for_expense> _dailyCategoryExpenses;

        public ViewModel()
        {
            _dailyCategoryExpenses =
            new ObservableCollection<Category_for_expense>(_dBContext.Categories_For_Expense.Include(c => c.Items));
        }

        public IEnumerable<Category_for_expense> DailyCategoryExpenses => _dailyCategoryExpenses;

        public string Date => DateTime.Now.ToString();

        public int NumberOfChanges { get; set; }

        public decimal Amount => GetAmount();

        private decimal GetAmount()
        {
            decimal amount = 0;

            foreach (var c in _dailyCategoryExpenses)
            {
                foreach (var item in c.Items)
                {
                    amount += item.Amount;
                }
            }

            return amount;
        }

        public void SaveAmount()
        {
            try
            {
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            NumberOfChanges = 0;
        }

        public void AddCaterory(Category_for_expense i)
        {
            _dailyCategoryExpenses.Add(i);
            _dBContext.SaveChanges();
        }

        public void AddItem(ExpenseItem i)
        {
            _dailyCategoryExpenses.ElementAt(4).AddItenInCat(i);
            _dBContext.SaveChanges();
        }

        public void Dispose()
        {
            _dBContext.Dispose();
        }
    }
}
