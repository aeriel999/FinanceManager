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

        private void SaveResponseChangesClick(object sender, RoutedEventArgs e)
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

        //private  void Button_Click(object sender, RoutedEventArgs e)
        //{
        //     _model.AddItem(new ExpenseItem() { Name = "ffffffffffffff", Amount = 300 });

        
        //}

        private void EditExpenseWindowBtnClick(object sender, RoutedEventArgs e)
        {
            _model.SetEditingProperty(true);
        }

        private void AddCategoryBtnClick(object sender, RoutedEventArgs e)
        {
            if (NewCategoryNamTB.Text.Length > 3)
                _model.AddCaterory(new Category_for_expense(NewCategoryNamTB.Text));
            else
                MessageBox.Show("Enter name for new category");
        }

        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddItemInCategoriesBtnClick(object sender, RoutedEventArgs e)
        {
            var itemWindow = new AddItemWindow();

            itemWindow.Show();

            this.Close();
        }
    }
}
