using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LabWork16
{
    /// <summary>
    /// Логика взаимодействия для Task4Window.xaml
    /// </summary>
    public partial class Task4Window : Window
    {
        private int _pageSize = 5;
        private int _currentPage = 1;
        private int _totalPages = 1;

        private List<Product>? _products;

        private List<Label> _pageLabels;

        public Task4Window()
        {
            InitializeComponent();
            LoadData();
            _pageLabels = new List<Label>();
            UpdateValues();
        }

        private void UpdatePageLabels(int totalPages)
        {
            foreach (var label in _pageLabels)
            {
                label.MouseDown -= PageLabel_MouseDown;
                buttonsStackPanel.Children.Remove(label);
            }
            _pageLabels.Clear();

            for (int i = 1; i <= totalPages; i++)
            {
                Label pageLabel = new Label
                {
                    Content = i.ToString(),
                    Cursor = Cursors.Hand,
                    Foreground = Brushes.White,
                    Background = Brushes.DarkGray,
                };

                if (i == _currentPage)
                {
                    pageLabel.Foreground = Brushes.Red;
                    pageLabel.Background = Brushes.White;
                    pageLabel.Cursor = Cursors.Arrow;
                }

                pageLabel.MouseDown += PageLabel_MouseDown;
                buttonsStackPanel.Children.Add(pageLabel);
                _pageLabels.Add(pageLabel);
            }
        }

        private void PageLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string? pageNumber = (sender as Label)?.Content.ToString();

            if (pageNumber != null && int.TryParse(pageNumber, out int selectedPage))
            {
                _currentPage = selectedPage;
                UpdateDataGrid(_pageSize * (_currentPage - 1), _pageSize);
                UpdateTextBlock();
                UpdatePageLabelStyle();
            }
        }

        private void UpdatePageLabelStyle()
        {
            foreach (var label in _pageLabels)
            {
                int pageNumber = int.Parse(label.Content.ToString());
                if (pageNumber == _currentPage)
                {
                    label.Foreground = Brushes.Red;
                    label.Background = Brushes.White;
                    label.Cursor = Cursors.Arrow;
                }
                else
                {
                    label.Foreground = Brushes.White;
                    label.Background = Brushes.DarkGray;
                    label.Cursor = Cursors.Hand;
                }
            }
        }

        private void UpdateValues()
        {
            if (_products == null) return;

            _totalPages = (int)Math.Ceiling(1.0 * _products.Count() / _pageSize);
            UpdateTextBlock();
            UpdatePageLabels(_totalPages);
            UpdateDataGrid(_pageSize * (_currentPage - 1), _pageSize);
        }

        private void UpdateTextBlock()
        {
            pageSizeTextBlock.Text = _pageSize.ToString();
            pageTextBlock.Text = _currentPage.ToString();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _pageSize = Convert.ToInt32(pageSizeTextBlock.Text);

            var page = Convert.ToInt32(pageTextBlock.Text);
            _currentPage = page < 1 ? 1 : page;
            _currentPage = page > _totalPages ? _totalPages : page;

            UpdateValues();
        }

        private void LoadData() => _products = new DapperDataContext().Products;

        private void UpdateDataGrid(int skip, int take) => productsDataGrid.ItemsSource = _products.Skip(skip).Take(take);
    }
}
