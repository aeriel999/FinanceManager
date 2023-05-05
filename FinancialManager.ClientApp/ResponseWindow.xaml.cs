using data_access.Entities;
using System.Windows;
using System.Windows.Controls;

namespace FinancialManager.ClientApp
{
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
            _model.SaveChanges();
            _model.SetEditingProperty(false);
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
             _model.AddItem(new ExpenseItem() { Name = "ffffffffffffff", Amount = 300 });

            //var vin = new AddItemWindow();

            //vin.Show();

            //this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditExpenseWindowBtnClick(object sender, RoutedEventArgs e)
        {
            // _model.AddCaterory(new Category_for_expense("New 5555555555555"));

            _model.SetEditingProperty(true);
        }

        private void EditCategoryNameBtnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
