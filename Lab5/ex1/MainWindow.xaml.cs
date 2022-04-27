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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamLib;

namespace WpfBookshelfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TeamSWithLinq<Members> _teamS = new TeamSWithLinq<Members>();

        public MainWindow()
        {
            InitializeComponent();

            _teamS += new Team<Members>("ABOBA", 2018,
                                              new Members() { Name = "Traf1ng"},
                                              new Members() { Name = "Zeiny"},
                                              new Members() { Name = "Domix"},
                                              new Members() { Name = "Tenzist"});
            _teamS += new Team<Members>("RUST", 2021,
                                              new Members() { Name = "fake"},
                                              new Members() { Name = "holla"});
            _teamS += new Team<Members>("CTR", 2019,
                                              new Members() {Name = "DareFox"});
                                              InitGrid();
        }
        void InitGrid()
        {
            DataGridBooks.ItemsSource = _teamS.Teams;
            DataGridBooks.CanUserAddRows = false;

            ColumnTitle.Binding = new Binding("Name");
            ColumnYear.Binding = new Binding("Year");

            ShowAuthors(DataGridBooks.Items.IndexOf(DataGridBooks.SelectedItem));
        }
        private void ShowAuthors(int index)
        {
            if (index < 0 || index >= _teamS.Teams.Count)
            {
                index = 0;
            }

            DataGridAuthors.ItemsSource = _teamS.Teams[index].Members;
            DataGridAuthors.CanUserAddRows = false;

            ColumnName.Binding = new Binding("Name");
        }
        private void DataGridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAuthors(DataGridBooks.Items.IndexOf(DataGridBooks.SelectedItem));
        }
        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            DataGridBooks.CommitEdit();
            _teamS += new Team<Members>()
            {
                Name = "",
                Members = new List<Members> { new Members() { Name = ""} }
            };
            InitGrid();
        }
        private void MenuAuthorAdd_Click(object sender, RoutedEventArgs e)
        {
            int index = DataGridBooks.SelectedIndex;
            DataGridBooks.CommitEdit();
            _teamS.Teams[index].Members.Add(new Members() {Name = ""});
            ShowAuthors(DataGridBooks.Items.IndexOf(index));
            InitGrid();
        }

        private void MenuItemRemove_Click(object sender, RoutedEventArgs e)
        {
            int index = DataGridBooks.SelectedIndex;
            DataGridBooks.CommitEdit();
            _teamS.Teams.RemoveAt(index);
            if (_teamS.Teams.Count == 0)
            {
                _teamS = new TeamSWithLinq<Members>();
                _teamS += new Team<Members>("", 0, new Members());
                InitGrid();
            }
            DataGridBooks.ItemsSource = null;
            InitGrid();
        }
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory; 
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML files (* .xml) | * .xml | All files (*. *) | *. *";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    _teamS.ReadBooks(dlg.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error reading from file");
                }
                InitGrid();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML files (* .xml) | * .xml | All files (*. *) | *. *";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    _teamS.WriteBooks(dlg.FileName);
                    MessageBox.Show("File saved");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error writing to file");
                }
            }
        }
        
        private void ButtonSortByTitle_Click(object sender, RoutedEventArgs e)
        {
            _teamS.SortByTitle();
            InitGrid();
        }

        private void ButtonSortByAuthorsCount_Click(object sender, RoutedEventArgs e)
        {
            _teamS.SortByAuthorsCount();
            InitGrid();
        }
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            string sequence = TextBoxSearch.Text;
            if (sequence.Length == 0)
            {
                return;
            }
            var found = _teamS.ContainsCharacters(sequence);

            string text = "";
            foreach (var team in found)
            {
                text += team + "\n";
            }
            MessageBox.Show(text);
        }
    }

    public class Members
    {
        public Members() { }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
        
        public override bool Equals(object obj)
        {
            Members members = (Members)obj;
            return  members.Name == Name;
        }

        public override string ToString()
        {
            return Name ;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    

}