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
using System.Data;
using DataArrays;

namespace WpfMatrixApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataArray a;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 2; i <= 10; i++)
            {
                comboBoxN.Items.Add(i);
                comboBoxM.Items.Add(i);
            }
            InitTable(2, 2);
        }

        private void InitTable(int n, int m)
        {
            a = new DataArray(n,m);
            dataGridA.ItemsSource = a.Data.DefaultView;
            for (int i = 0; i < a.M; i++)
                for (int j = 0; j < a.N; j++)
                    a[i][j] = 0;
            dataGridA.CanUserAddRows = false;
        }

        private void ItemRunCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                int sum = 0;
                for (int i = 0, trace; i < a.M; i++)
                {
                    trace = 1;
                    for (int j = 0; j < a.N; j++)
                        trace *= Convert.ToInt32(a[i][j]);
                    sum += trace;
                }
                // Виводимо результат:
                if (checkBoxWindow.IsChecked ?? true)
                    MessageBox.Show("Result: " + sum, "Result");
                else
                    textBoxTrace.Text = sum + ""; 
            }
              
            }
            catch (Exception)
            {
                MessageBox.Show("Check data", "ERROR");
            }
        }


        private void ItemFileNew_Click(object sender, RoutedEventArgs e)
        {
            comboBoxN.SelectedIndex = 0;
            InitTable(2,2);
            checkBoxWindow.IsChecked = false;
            textBoxTrace.Text = "";
        }

        private void ItemRunRandom_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < a.M; i++)
                for (int j = 0; j < a.N; j++)
                    a[i][j] = rand.Next(-1000, 1000);;
        }

        private void ItemHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("КН-421с\n\nПахомов Олег", "About");
        }

        private void ItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dataGridA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void ButtonDo_Click(object sender, RoutedEventArgs e)
        {
            InitTable(int.Parse(comboBoxN.SelectedItem + ""), int.Parse(comboBoxM.SelectedItem + ""));
            textBoxTrace.Text = "";
        }


    }

}