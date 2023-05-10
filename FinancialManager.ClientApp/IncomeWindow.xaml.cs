using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialManager.ClientApp;

public partial class IncomeWindow : Window
{
    private bool _isBusy = true;
    private ViewModel _model = new ViewModel();
    public IncomeWindow()
    {
        InitializeComponent();
        DataContext = _model;
    }

    private void EditBtn_Click(object sender, RoutedEventArgs e)
    {
        _model.SetEditingPropertyIncome(true);
    }

   

    private void CategoryNameIn_LostFocus(object sender, RoutedEventArgs e)
    {
        _isBusy = true;
    }

    private void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("When deleted, all data will be deleted",
               "Confirmation", MessageBoxButton.YesNo);

        if (result == MessageBoxResult.Yes)
        {
            _model.DeleteCategoryIncome();
        }
    }

    private void AddBtn_Click(object sender, RoutedEventArgs e)
    {

        if (txtBoxNameIncome.Text.Length > 3)
        {
            _model.AddCateroryIncome(new Income(txtBoxNameIncome.Text));
        }
        else
        {
            MessageBox.Show("Enter name for new category");
        }
        txtBoxNameIncome.Clear();
    }

    private void closeBtn_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void CategoryNameIn_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        if (_isBusy)
        {
            _model.NumberOfChanges++;
            _isBusy = false;
        }

    }

    private void SaveBTN_Click(object sender, RoutedEventArgs e)
    {
        _model.SaveChanges();
        _model.SetEditingPropertyIncome(false);

    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isBusy)
        {
            _model.NumberOfChanges++;
            _isBusy = false;
        }
    }

    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        _isBusy = true;
    }
}
