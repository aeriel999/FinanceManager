using data_access.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        private ViewModel _viewModel = new ViewModel();
        private int _id;
        public AddItemWindow(int id)
        {
            InitializeComponent();
            ItemAmountTB.Text = "0";
            _id = id;
        }


        private decimal MakePrice()
        {
            decimal price = 0;

            try
            {
                price = decimal.Parse(ItemAmountTB.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return price;
        }
        private void AddINewtemBtnClick(object sender, RoutedEventArgs e)
        {
            decimal price = MakePrice();

            if (ItemNameTB.Text.Length > 3 && price >= 0)
                _viewModel.AddItem(new ExpenseItem() { Name = ItemNameTB.Text , Amount = price, CategoryId = _id});

            this.Close();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            var responseWindow = new ResponseWindow();
            responseWindow.Show();
        }
    }
}
