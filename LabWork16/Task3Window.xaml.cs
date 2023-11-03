using Azure;
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
using System.Windows.Shapes;

namespace LabWork16
{
    /// <summary>
    /// Логика взаимодействия для Task3Window.xaml
    /// </summary>
    public partial class Task3Window : Window
    {
        int _pageSize = 5;
        int _currentPage = 1;
        int _totalPages = 1;

        public Task3Window()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            pageSizeTextBlock.Text = _pageSize.ToString();
            pageTextBlock.Text = _currentPage.ToString();

            DapperDataContext dataContext = new DapperDataContext();

            List<Product>? products = dataContext.Products;

            productsDataGrid.ItemsSource = products
                .Skip(_pageSize * (_currentPage - 1))
                .Take(_pageSize);

            _totalPages = (int)Math.Ceiling(1.0 * products.Count() / _pageSize);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _pageSize = Convert.ToInt32(pageSizeTextBlock.Text);

            var page = Convert.ToInt32(pageTextBlock.Text);
            _currentPage = page == 0 ? 1 : page;

            LoadData();
        }

        private void ToStartButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            LoadData();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage == 1)
            {
                return;
            }
            _currentPage--; //
            LoadData();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage >= _totalPages)
            {
                return;
            }
            _currentPage++; //
            LoadData();
        }

        private void ToLastButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _totalPages;
            LoadData();
        }
    }
}
