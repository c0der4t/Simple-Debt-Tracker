using mainModules;
using Microsoft.EntityFrameworkCore;
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

namespace Simple_Debt_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly databaseContext _contextDB =
            new databaseContext();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO : Always ensure the DB folder exists
            _contextDB.Database.EnsureCreated();

            //_contextDB.Sales.Load();
        }

        private void tbctrlMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tbctrlMain.SelectedIndex)
            {
                case 0:
                    LoadTab_Sales();
                    break;
                case 1:
                    LoadTab_Stock();
                    break;
                case 2:
                    LoadTab_SalesReports();
                    break;
                case 3:
                    LoadTab_Faculty();
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        private void LoadTab_Sales()
        {
            _contextDB.Stock.Load();
            _contextDB.Faculty.Load();

            CollectionViewSource facultyViewSource =
               (CollectionViewSource)FindResource(nameof(facultyViewSource));

            facultyViewSource.Source =
                _contextDB.Faculty.Local.ToObservableCollection();
        }

        private void LoadTab_Stock()
        {
            _contextDB.Stock.Load();

            // find the collectionsource, then bind table to it

            CollectionViewSource stockViewSource =
               (CollectionViewSource)FindResource(nameof(stockViewSource));

            stockViewSource.Source =
                _contextDB.Stock.Local.ToObservableCollection();

        }

        private void LoadTab_Faculty()
        {
            _contextDB.Faculty.Load();

            // find the collectionsource, then bind table to it

            CollectionViewSource facultyViewSource =
               (CollectionViewSource)FindResource(nameof(facultyViewSource));

            facultyViewSource.Source =
                _contextDB.Faculty.Local.ToObservableCollection();

        }

        private void LoadTab_SalesReports()
        {
            _contextDB.Sales.Load();

            // find the collectionsource, then bind table to it

            CollectionViewSource salesreportsViewSource =
               (CollectionViewSource)FindResource(nameof(salesreportsViewSource));

            salesreportsViewSource.Source =
                _contextDB.Sales.Local.ToObservableCollection();

        }

        private void cmbbxFacultyMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO : Get Account Balance of selected Faculty Member
        }
    }
}
