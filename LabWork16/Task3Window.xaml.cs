using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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

        List<Product>? _products;

        public Task3Window()
        {
            InitializeComponent();

            LoadData();
            UpdateValues();
        }


        private void UpdateValues()
        {
            if (_products == null) return;

            _totalPages = (int)Math.Ceiling(1.0 * _products.Count() / _pageSize);

            pageSizeTextBlock.Text = _pageSize.ToString();
            pageTextBlock.Text = _currentPage.ToString();

            UpdateDataGrid(_pageSize * (_currentPage - 1), _pageSize);
            DisableButtons();
        }

        private void DisableButtons()
        {
            nextButton.IsEnabled = toEndButton.IsEnabled = _currentPage < _totalPages;
            previousButton.IsEnabled = toStartButton.IsEnabled = _currentPage > 1;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _pageSize = Convert.ToInt32(pageSizeTextBlock.Text);
            var page = Convert.ToInt32(pageTextBlock.Text);
            _currentPage = page < 1 ? 1 : page;
            _currentPage = page > _totalPages ? _totalPages : page;

            UpdateValues();
        }

        private void ToStartButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            UpdateValues();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage <= 1) return;
            _currentPage--;
            UpdateValues();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage >= _totalPages) return;
            _currentPage++;
            UpdateValues();
        }

        private void ToLastButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _totalPages;
            UpdateValues();
        }
        private void LoadData() => _products = new DapperDataContext().Products;

        private void UpdateDataGrid(int skip, int take) => productsDataGrid.ItemsSource = _products.Skip(skip).Take(take);
    }
}
