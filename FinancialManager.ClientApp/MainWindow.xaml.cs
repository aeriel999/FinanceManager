using data_access;

using data_access.Entities;
using Microsoft.EntityFrameworkCore;


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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FinancialManager.ClientApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    FinancialManagerDBContext dbcontext = new FinancialManagerDBContext();
    public static DiagramWindow? CircleWindow;
  
    private ViewModel _viewModel = new ViewModel();

    public MainWindow()
    {
        InitializeComponent();

        DataContext = _viewModel;
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (CircleWindow == null)
        {
            CircleWindow = new DiagramWindow();
            CircleWindow.Show();
        }
        else CircleWindow.Activate();
        
     }

    private void OpenResponseWindowBtnClick(object sender, RoutedEventArgs e)
    {
        var responseWindow = new ResponseWindow();

        responseWindow.Show();

        this.Close();
    }

    private void OpenIncomeWindowBtnClick(object sender, RoutedEventArgs e)
    {
        var incomeWindow = new IncomeWindow();

        incomeWindow.Show();
    }

    private void SaveAmountBtnClick(object sender, RoutedEventArgs e)
    {
        _viewModel.UpdateCurrentAmount();
 
    }

    private void formsPlot1_Loaded(object sender, RoutedEventArgs e)
    {
        _viewModel.MakePlaneAmounDiagram(formsPlot1);
    }

    private void ProgressBar_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        foreach (var item in _viewModel.DailyCategoryExpenses)
        {
            if (item.PlaneExpense < item.ActuallyExpense)
            {
                decimal Max = item.ActuallyExpense;
                decimal Value = item.PlaneExpense;
               ((ProgressBar)sender).Background= new SolidColorBrush(Colors.Red);
                ((ProgressBar)sender).Maximum = (int)Max;
                ((ProgressBar)sender).Value = (int)Value;
            }
        }

    }

    private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        foreach (var item in _viewModel.DailyCategoryExpenses)
        {
            if (item.PlaneExpense < item.ActuallyExpense)
            {
                decimal Max = item.ActuallyExpense;
                decimal Value = item.PlaneExpense;
                ((ProgressBar)sender).Background = new SolidColorBrush(Colors.Red);
                ((ProgressBar)sender).Maximum = (int)Max;
                ((ProgressBar)sender).Value = (int)Value;
            }
        }

    }
}

