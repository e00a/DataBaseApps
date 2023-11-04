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
    /// Логика взаимодействия для Task5Window.xaml
    /// </summary>
    public partial class Task5Window : Window
    {
        int _pageSize = 5;
        int _currentPage = 1;
        int _totalPages = 1;

        DapperDataContext _dataContext;
        List<Product>? _products;

        public Task5Window()
        {
            InitializeComponent();

            _dataContext = new DapperDataContext();
            LoadData();
        }

        private void LoadData()
        {
            pageSizeTextBlock.Text = _pageSize.ToString();
            pageTextBlock.Text = _currentPage.ToString();

            _products = _dataContext.Products;
            if (_products == null) return;

            productsDataGrid.ItemsSource = _products
                .Skip(_pageSize * (_currentPage - 1))
                .Take(_pageSize);

            _totalPages = (int)Math.Ceiling(1.0 * _products.Count() / _pageSize);

            var productsCount = _products.Count;
            var length = _currentPage * _pageSize;
            PrintLength(length > productsCount ? productsCount : length, productsCount);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _pageSize = Convert.ToInt32(pageSizeTextBlock.Text);

            var page = Convert.ToInt32(pageTextBlock.Text);
            _currentPage = page < 1 ? 1 : page;
            _currentPage = page > _totalPages ? _totalPages : page;

            LoadData();
        }

        private void ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage >= _totalPages) return;
            _currentPage++;
            LoadData();

            productsDataGrid.ItemsSource = _products
               .Take(_pageSize * _currentPage);
        }

        private void PrintLength(int length, int total)
        {
            statusTextBlock.Text = $"Показано {length} из {total} записей.";
        }
    }
}
