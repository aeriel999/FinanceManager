﻿using System;
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
    /// Логика взаимодействия для ExpensesIncomeWindow.xaml
    /// </summary>
    public partial class ExpensesIncomeWindow : Window
    {
        private ViewModel _viewModel = new ViewModel();
        public ExpensesIncomeWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }
        private void formsPlot1_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.MakeExpensesIncomeDiaram(CircleDiagram);
        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
