using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFGraph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonRedraw_Click(object sender, RoutedEventArgs e)
        {
            canvasGraph.Children.Clear();
            try
            {
                if (RadioButton1.IsChecked == true)
                {
                    canvasGraph.Children.Add(new Ellipse()
                    {
                        Width = 250,
                        Height = 200,
                        Margin = new Thickness(100, 100, 0, 0),
                        Fill = Brushes.Black
                    });
                }
                if (RadioButton2.IsChecked == true)
                {
                    canvasGraph.Children.Add(new Ellipse()
                    {
                        Width = 200,
                        Height = 200,
                        Margin = new Thickness(100, 100, 0, 0),
                        Fill = Brushes.Black
                    });
                }
                if (RadioButton3.IsChecked == true)
                {
                    canvasGraph.Children.Add(new Rectangle()
                    {
                        Width = 200,
                        Height = 200,
                        Margin = new Thickness(100, 100, 0, 0),
                        Fill = Brushes.Black
                    });
                }
                if (RadioButton4.IsChecked == true)
                {
                    canvasGraph.Children.Add(new Rectangle()
                    {
                        Width = 300,
                        Height = 200,
                        Margin = new Thickness(100, 100, 0, 0),
                        Fill = Brushes.Black
                    });
                }
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
        }

    }
}