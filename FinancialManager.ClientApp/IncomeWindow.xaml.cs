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
    public ObservableCollection<string> Products { get; set; }
    private ViewModel _model = new ViewModel();
    public IncomeWindow()
    {
        InitializeComponent();
        Products = new ObservableCollection<string> { "Product 1", "Product 2", "Product 3" };
        DataContext = this;
    }
}
