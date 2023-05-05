using data_access;
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
    private ViewModel _model = new ViewModel();
    //FinancialManagerDBContext dBContext = new FinancialManagerDBContext();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = _model;
        //var win = new ResponseWindow();

        //win.Show();

        //this.Close();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        
        IncomeWindow incomeWindow = new IncomeWindow();
        incomeWindow.Show();
    }
}

