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

        List<Product>? _products;

        public Task5Window()
        {
            InitializeComponent();

            LoadData();
            UpdateValues();
        }

        private void UpdateValues()
        {
            if (_products == null) return;

            var productsCount = _products.Count;
            _totalPages = (int)Math.Ceiling(1.0 * productsCount / _pageSize);

            pageSizeTextBlock.Text = _pageSize.ToString();
            pageTextBlock.Text = _currentPage.ToString();
                        
            UpdateDataGrid(_pageSize * (_currentPage - 1), _pageSize);

            var length = _currentPage * _pageSize;
            PrintLength(length > productsCount ? productsCount : length, productsCount);

            UpdateShowMoreButton();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _pageSize = Convert.ToInt32(pageSizeTextBlock.Text);

            var page = Convert.ToInt32(pageTextBlock.Text);
            _currentPage = page < 1 ? 1 : page;
            _currentPage = page > _totalPages ? _totalPages : page;

            UpdateValues();
        }

        private void ShowMoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage >= _totalPages) return;

            _currentPage++;
            UpdateValues();
            UpdateDataGrid(0, _pageSize * _currentPage);
        }

        private void LoadData() => _products = new DapperDataContext().Products;

        private void UpdateDataGrid(int skip, int take) => productsDataGrid.ItemsSource = _products.Skip(skip).Take(take);

        private void UpdateShowMoreButton() => showMoreButton.IsEnabled = _currentPage < _totalPages;

        private void PrintLength(int length, int total) => statusTextBlock.Text = $"Показано {length} из {total} записей.";
    }
}
