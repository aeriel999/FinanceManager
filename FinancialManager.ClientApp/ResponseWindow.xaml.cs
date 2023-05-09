using data_access.Entities;
using System;
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
            var window = new MainWindow();

            window.Show();

            this.Close();
        }

        private void AddItemInCategoriesBtnClick(object sender, RoutedEventArgs e)
        {
            int id = _model.GetCheckedId();

            if (id >= 0)
            {
                var itemWindow = new AddItemWindow(_model.GetCheckedId());

                itemWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Try againe");
            }
        }

        private void DeleteCategoriesBtnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you shure that you want delete category with all items?",
                "Confirmation",MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                _model.DeleteCategory();
            }
        }

        private void DeleteItemBtnClick(object sender, RoutedEventArgs e)
        {
            _model.DeleteItem();
        }

    }
}
