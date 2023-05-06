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
        }

        public IEnumerable<Category_for_expense> DailyCategoryExpenses => _dailyCategoryExpenses;

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
            _dBContext.Categories_For_Expense.Add(i);
            _dBContext.SaveChanges();
        }

        public void AddItem(ExpenseItem i)
        {
            try
            {
                _dailyCategoryExpenses.Single(d => d.Id == i.CategoryId).AddItenInCat(i);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int GetCheckedId()
        {
            int id = -1;

            foreach (var item in _dailyCategoryExpenses)
            {
                if (item.IsChecked)
                    return item.Id;
            }

            return id;
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

        public void DeleteCategory()
        {
            try
            {
                var category = _dailyCategoryExpenses.Single(c => c.Id == GetCheckedId());

                _dailyCategoryExpenses.Remove(category);
                _dBContext.Categories_For_Expense.Remove(category);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Dispose()
        {
            _dBContext.Dispose();
        }
    }
}
