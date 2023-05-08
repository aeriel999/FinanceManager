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
        public DiagramWindow()
        {
            InitializeComponent();
        }


        private void CircleDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            List<WeekInfo> Info = new List<WeekInfo>()
        {
            new WeekInfo()
            {
                 NameCategory = "Transport",
                 AmountMoney = 500

            },
            new WeekInfo()
            {
                 NameCategory = "Food",
                 AmountMoney = 1000

            },
            new WeekInfo()
            {
                 NameCategory = "Clothers",
                 AmountMoney = 2000

            }
        };

            Random rand = new(0);
            List<ScottPlot.Plottable.Bar> bars = new();
            for (int i = 0; i < Info.Count; i++)
            {
                int value = Info[i].AmountMoney;
                ScottPlot.Plottable.Bar bar = new()
                {
                    Value = value,
                    Position = i,
                    FillColor = Palette.Category10.GetColor(i),
                    Label = Info[i].NameCategory
                };
                bars.Add(bar);
            }
            CircleDiagram.Plot.AddBarSeries(bars);
            CircleDiagram.Plot.SetAxisLimitsY(0, 120);
            CircleDiagram.Refresh();
        }

        class WeekInfo
        {
            public string NameCategory { get; set; }
            public int AmountMoney { get; set; }
        }
    }
}
