using data_access;
using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using ScottPlot;
using ScottPlot.Plottable;
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
        private ObservableCollection<Category_for_Income> _dailyCategory_for_Income;
        //private ObservableCollection<Income> _incomes;
        private decimal _amount;
       

        public ViewModel()
        {
            _dailyCategoryExpenses = new ObservableCollection<Category_for_expense>(_dBContext.Categories_For_Expense
                                                                                                .Include(c => c.Items));

            _dailyCategory_for_Income = new ObservableCollection<Category_for_Income>(_dBContext.Category_For_Incomes
                                                                                            .Include(i => i.Incomes));

            CountCurrentAmount();
        }

        public IEnumerable<Category_for_expense> DailyCategoryExpenses => _dailyCategoryExpenses;

        public IEnumerable<Category_for_Income> Category_for_Income => _dailyCategory_for_Income;

        public DateTime Date => DateTime.Now;

        public int NumberOfChanges { get; set; }

        public decimal Amount { get => GetAmount(); private set => _amount = value; }
        public decimal AmountIncome { get => GetAmountIncome(); private set => _amount = value; }
        

        public decimal CurrentAmount { get; set; }

        public decimal Balance { get; set; }

        private decimal GetAmount()
        {
            decimal amount = 0;

            foreach (var c in _dailyCategoryExpenses)
            {
                amount += c.PlaneExpense;
            }

            UpdateStatisticPlainResponse(amount);

            return amount;
        }
        private decimal GetAmountIncome()
        {
            decimal amount = 0;

            foreach (var c in _dailyCategory_for_Income)
            {
                amount += c.AmountIncome;
               /* foreach (var item in c.Incomes)
                {
                    amount += item.Amount;
                }*/
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

        
       


        private void UpdateStatisticPlainResponse(decimal amount)
        {
            try
            {
                if (_dBContext.Expenses.FirstOrDefault(e => e.Day.Day == Date.Day) != null)
                    _dBContext.Expenses.FirstOrDefault(e => e.Day.Day == Date.Day).PlaneAmount = amount;
                else
                    _dBContext.Expenses.Add(new Expense(amount, 0) { Day = Date });

                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        public void DeleteItem()
        {
            List<ExpenseItem> items = new List<ExpenseItem>();
            try
            {
                foreach (var c in _dailyCategoryExpenses)
                {
                    if (c.IsChecked)
                    {
                        foreach (var i in c.Items)
                        {
                            if (i.IsChecked)
                            {
                                items.Add(i);
                            }
                        }
                    }
                }

                for (int i = 0; i < items.Count; i++)
                {
                    _dailyCategoryExpenses.Single(c => c.IsChecked == true).Items.Remove(items[i]);
                    _dBContext.ExpenseItems.Remove(items[i]);
                    _dBContext.SaveChanges();
                }

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
                var category = _dailyCategoryExpenses.Single(c => c.IsChecked == true);

                _dailyCategoryExpenses.Remove(category);
                _dBContext.Categories_For_Expense.Remove(category);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountCurrentAmount()
        {
            decimal amount = 0;

            foreach (var item in _dailyCategoryExpenses)
            {
                amount += item.ActuallyExpense;
            }

            CurrentAmount = amount;
        }

        public void UpdateCurrentAmount()
        {
            foreach (var item in _dailyCategoryExpenses)
            {
                item.ActuallyExpense += item.DailyCostSpent;
            }

            CountCurrentAmount();

            _dBContext.SaveChanges();

            UpdateStatisticCurrentResponse();
        }

        private void UpdateStatisticCurrentResponse()
        {
            try
            {
                _dBContext.Expenses.SingleOrDefault(e => e.Day.Day == Date.Day).CurrentAmount = CurrentAmount;

                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MakePlaneAmounDiagram(WpfPlot plot)
        {
            int size = _dailyCategoryExpenses.Count;

            double[] values = new double[size];
            string[] sliceLabels = new string[size];
            string[] legendLabels = new string[size];

            for (int i = 0; i < size; i++)
            {
                values[i] = double.Parse(_dailyCategoryExpenses[i].PlaneExpense.ToString());
                sliceLabels[i] = _dailyCategoryExpenses[i].PlaneExpense.ToString();
                legendLabels[i] = _dailyCategoryExpenses[i].Name;
            }

            var pie = plot.Plot.AddPie(values);
            pie.SliceLabels = sliceLabels;
            pie.ShowLabels = false;

            pie.LegendLabels = legendLabels;
            plot.Plot.Legend();
            plot.Refresh();
        }
        public void SetEditingPropertyIncome(bool canEdit)
        {
            foreach (var c in _dailyCategory_for_Income)
            {
                c.CanEdit = canEdit;
                
            }
        }


        /// <summary>
        /// //////
        /// </summary>



        public void SaveChangesIncome()
        {
            try
            {
                _dBContext.SaveChanges();

                UpDateAmountIncome();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            NumberOfChanges = 0;
        }



        private void UpDateAmountIncome()
        {
            AmountIncome = GetAmountIncome();

            foreach (var c in _dailyCategory_for_Income)
            {
                c.UpdateAmountIncome();
            }
        }





        /// <summary>
        /// ///////
        /// </summary>

        public void DeleteCategoryIncome()
        {
            try
            {
                var category = _dailyCategory_for_Income.Single(c => c.IsChecked == true);

                _dailyCategory_for_Income.Remove(category);
                _dBContext.Category_For_Incomes.Remove(category);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void AddCateroryIncome(Category_for_Income i)
        {
            _dailyCategory_for_Income.Add(i);
            _dBContext.Category_For_Incomes.Add(i);
            _dBContext.SaveChanges();
        }


       /* public void AddItemIncome(ExpenseItem i)
        {
            try
            {
                _dailyCategory_for_Income.Single(d => d.Id == i.CategoryId).AddItenInCat(i);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/







        private Expense GetValuesForDiagram(int month)
        {
            return _dBContext.Expenses.Where(e => e.Day.Month == month).OrderByDescending(e => e.Day.Day).FirstOrDefault();
        }

        public void MakeResponseDiaram(WpfPlot plot)
        {
            int size = 13;

            Expense expense;

            double[] valuesA = new double[size];

            double[] valuesB =  new double[size];


            for (int i = 1; i < size; i++)
            {
                expense = GetValuesForDiagram(i);

                if (expense != null)
                {
                    valuesA[i] = double.Parse(expense.PlaneAmount.ToString());
                    valuesB[i] = double.Parse(expense.CurrentAmount.ToString());
                }
                else 
                {
                    valuesA[i] = 0;
                    valuesB[i] = 0;
                }
            }

            plot.Plot.AddBar(valuesA);
            plot.Plot.AddBar(valuesB);

            plot.Plot.SetAxisLimits(yMin:0, xMin:0, xMax: size);

            plot.Refresh();
        }

        public void Dispose()
        {
            _dBContext.Dispose();
        }
    }
}
