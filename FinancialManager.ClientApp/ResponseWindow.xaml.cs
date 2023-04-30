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
        public ResponseWindow()
        {
            InitializeComponent();

            DataContext = _model;
        }

        private void SaveResponseAmountClick(object sender, RoutedEventArgs e)
        {
            _model.SaveAmount();
        }
    }
}
