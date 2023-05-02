using data_access;
using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinancialManager.ClientApp
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private  FinancialManagerDBContext _dBContext  = new FinancialManagerDBContext();

        private IEnumerable<Category_for_expense> _dailyCategoryExpenses => _dBContext.Categories_For_Expense.Include(c => c.Items).ToList();

        public IEnumerable<Category_for_expense> DailyCategoryExpenses => _dailyCategoryExpenses;

        public string Date  => DateTime.Now.ToString();

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
    }
}
