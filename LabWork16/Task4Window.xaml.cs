using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabWork16
{
    /// <summary>
    /// Логика взаимодействия для Task4Window.xaml
    /// </summary>
    public partial class Task4Window : Window
    {
        int _pageSize = 5;
        int _currentPage = 1;
        int _totalPages = 1;

        public Task4Window()
        {
            InitializeComponent();
            LoadData();
            for (int i = 1; i <= _totalPages; i++)
            {
                Label label = new Label();
                label.Content = i;
                label.MouseDown += ToPageLabel_MouseDown;
                label.Cursor = Cursors.Hand;
                buttonsStackPanel.Children.Add(label);
            }
        }

        private void ToPageLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Label label) return;

            _currentPage = Convert.ToInt32(label.Content);
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
