using data_access;
using data_access.Entities;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FinancialManager.ClientApp
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel : IDisposable
    {
        private FinancialManagerDBContext _dBContext = new FinancialManagerDBContext();

        private ObservableCollection<Category_for_expense> _dailyCategoryExpenses;

        private decimal _amount;

        public ViewModel()
        {
            _dailyCategoryExpenses = new ObservableCollection<Category_for_expense>(_dBContext.Categories_For_Expense
                                                                                                .Include(c => c.Items));

            DailyCategoryExpenses = _dailyCategoryExpenses;
        }

        public IEnumerable<Category_for_expense> DailyCategoryExpenses { get; set; }

        public string Date => DateTime.Now.ToString();

        public int NumberOfChanges { get; set; }

        public decimal Amount { get => GetAmount(); private set => _amount = value; }

        private decimal GetAmount()
        {
            decimal amount = 0;

            foreach (var c in _dailyCategoryExpenses)
            {
                amount += c.GetPlaneExpense;
            }

            return amount;
        }

        private void UpDateAmount()
        {
            Amount = GetAmount();

            foreach (var c in _dailyCategoryExpenses)
            {
                c.UpdateAmount();
            }
        }

        public void SaveChanges()
        {
            try
            {
                _dBContext.SaveChanges();

                UpDateAmount();
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
            _dailyCategoryExpenses.ElementAt(1).AddItenInCat(i);
            _dBContext.SaveChanges();
        }

        private Category_for_expense GetChecked()
        {
            var category = new Category_for_expense();

            foreach (var item in _dailyCategoryExpenses)
            {
                if (item.IsChecked)
                    return item;
            }

            return category;
        }

        public void SetEditingProperty(bool canEdit)
        {
            foreach (var c in _dailyCategoryExpenses)
            {
                c.CanEdit = canEdit;

                foreach (var item in c.Items)
                {
                    item.CanEdit = canEdit;
                }
            }
        }

        public void Dispose()
        {
            _dBContext.Dispose();
        }
    }
}
