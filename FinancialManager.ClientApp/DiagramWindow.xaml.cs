using System;
using ScottPlot;
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
using Color = System.Drawing.Color;

namespace FinancialManager.ClientApp
{
    /// <summary>
    /// Interaction logic for DiagramWindow.xaml
    /// </summary>
    public partial class DiagramWindow : Window
    {
        public static CategoryExpensesWindow? categoryExpensesDG;
        public static ExpensesIncomeWindow? ExpensesIncomeDG;
        public static IncomeCategoryWindow? IncomeDG;
        ViewModel _model = new ViewModel();

        string[] diagrams = { "Plane-Actually", "Expenses-Income", "Category expenses", "Category Income" };
        public DiagramWindow()
        {
            InitializeComponent();
            for (int i = 0; i < diagrams.Length; i++)
            {
                comboBox.Items.Add(diagrams[i]);
            }
            comboBox.SelectedIndex = 0;

        }


        private void CircleDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.MakeResponseDiaram((WpfPlot)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlaneAmounDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.MakePlaneAmounDiagram((WpfPlot)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        class WeekInfo
        {
            public string NameCategory { get; set; }
            public int AmountMoney { get; set; }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (comboBox.Text)
            {
                case "Plane-Actually":
                    break;
                case "Expenses-Income":
                    if (ExpensesIncomeDG == null)
                    {
                        ExpensesIncomeDG = new ExpensesIncomeWindow();
                        ExpensesIncomeDG.Show();
                    }
                    else ExpensesIncomeDG.Activate();
                    break;
                case "Category expenses":
                    if (categoryExpensesDG == null)
                    {
                        categoryExpensesDG = new CategoryExpensesWindow();
                        categoryExpensesDG.Show();
                    }
                    else categoryExpensesDG.Activate();
                    break;
                case "Category Income":
                    if (IncomeDG == null)
                    {
                        IncomeDG = new IncomeCategoryWindow();
                        IncomeDG.Show();
                    }
                    else IncomeDG.Activate();
                    break;
                default:
                    break;
            }
        }
    }
}
