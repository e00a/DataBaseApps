using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LabWork17
{
    /// <summary>
    /// Логика взаимодействия для Task5Window.xaml
    /// </summary>
    public partial class Task5Window : Window
    {
        ApplicationContext _context = new ApplicationContext();
        List<Product> _products;

        List<Func<Product, object>> _sortOptions = new List<Func<Product, object>>();
        List<bool> _descendingFlags = new List<bool>();

        public Task5Window()
        {
            InitializeComponent();
            try
            {
                _products = _context.Products.ToList();
                productsDataGrid.ItemsSource = _products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IEnumerable<Product> SortProducts()
        {
            var products = _products;
            _sortOptions.Clear();
            _descendingFlags.Clear();

            AddSortOption(firstComboBox.SelectedIndex, firstCheckBox);
            AddSortOption(secondComboBox.SelectedIndex, secondCheckBox);
            AddSortOption(thirdComboBox.SelectedIndex, thirdCheckBox);

            if (_sortOptions.Any()) 
            {
                IOrderedEnumerable<Product> orderedProducts = null;

                for (int i = 0; i < _sortOptions.Count; i++)
                {
                    if (i == 0)
                    {
                        orderedProducts = _descendingFlags[i]
                            ? products.OrderByDescending(_sortOptions[i])
                            : products.OrderBy(_sortOptions[i]);
                    }
                    else
                    {
                        orderedProducts = _descendingFlags[i]
                            ? orderedProducts.ThenByDescending(_sortOptions[i])
                            : orderedProducts.ThenBy(_sortOptions[i]);
                    }
                }
                products = orderedProducts.ToList();
            }
            return products;
        }

        void AddSortOption(int comboBoxIndex, CheckBox checkBox)
        {
            if (comboBoxIndex >= 0)
            {
                _sortOptions.Add(GetSortOptionByComboBoxIndex(comboBoxIndex));
                _descendingFlags.Add(checkBox.IsChecked == true);
            }
        }

        private Func<Product, object> GetSortOptionByComboBoxIndex(int index) => index switch
        {
            0 => p => p.Type,
            1 => p => p.Price,
            2 => p => p.ProductionYear,
            _ => throw new ArgumentException("Invalid combobox index"),
        };

        private void UpdateSort(object sender, RoutedEventArgs e)
        {
            productsDataGrid.ItemsSource = SortProducts();
        }

        private void thirdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productsDataGrid.ItemsSource = SortProducts();
        }
    }
}
