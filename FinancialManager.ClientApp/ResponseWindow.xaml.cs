﻿using data_access.Entities;
using System;
using System.Collections.Generic;
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

namespace FinancialManager.ClientApp
{
    /// <summary>
    /// Interaction logic for ResponseWindow.xaml
    /// </summary>
    public partial class ResponseWindow : Window
    {
        private ViewModel _model = new ViewModel();
        private bool _isBusy = true;
        public ResponseWindow()
        {
            InitializeComponent();
            DataContext = _model;
        }


        private void SaveResponseAmountClick(object sender, RoutedEventArgs e)
        {
            _model.SaveAmount();
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

        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            // _model.AddItem(new ExpenseItem() { Name = "ffffffffffffff", Amount = 300 });

            var vin = new AddItemWindow();

            vin.Show();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _model.AddCaterory(new Category_for_expense() { Name = "New 5555555555555" });
        }
    }
}
