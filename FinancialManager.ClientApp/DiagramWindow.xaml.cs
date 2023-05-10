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
        ViewModel _model = new ViewModel();
        public DiagramWindow()
        {
            InitializeComponent();
        }


        private void CircleDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            _model.MakeResponseDiaram((WpfPlot)sender);
        }

        class WeekInfo
        {
            public string NameCategory { get; set; }
            public int AmountMoney { get; set; }
        }
    }
}
