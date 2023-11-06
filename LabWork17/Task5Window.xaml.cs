using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LabWork17
{
    /// <summary>
    /// Логика взаимодействия для Task5Window.xaml
    /// </summary>
    public partial class Task5Window : Window
    {
        ApplicationContext _context = new ApplicationContext();
        List<Product> _products;

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
            var products = _products ?? throw new Exception("Products is null");

            var sortOptions = new List<Func<Product, object>>();
            var descendingFlags = new List<bool>();

            if (firstComboBox.SelectedIndex >= 0)
            {
                sortOptions.Add(GetSortOptionByComboBoxIndex(firstComboBox.SelectedIndex));
                descendingFlags.Add(firstCheckBox.IsChecked.GetValueOrDefault());
            }
            if (secondComboBox.SelectedIndex >= 0)
            {
                sortOptions.Add(GetSortOptionByComboBoxIndex(secondComboBox.SelectedIndex));
                descendingFlags.Add(secondCheckBox.IsChecked.GetValueOrDefault());
            }
            if (thirdComboBox.SelectedIndex >= 0)
            {
                sortOptions.Add(GetSortOptionByComboBoxIndex(thirdComboBox.SelectedIndex));
                descendingFlags.Add(thirdCheckBox.IsChecked.GetValueOrDefault());
            }

            if (sortOptions.Any())
            {
                IOrderedEnumerable<Product> orderedProducts = null;

                for (int i = 0; i < sortOptions.Count; i++)
                {
                    if (i == 0)
                    {
                        orderedProducts = descendingFlags[i]
                            ? products.OrderByDescending(sortOptions[i])
                            : products.OrderBy(sortOptions[i]);
                    }
                    else
                    {
                        orderedProducts = descendingFlags[i]
                            ? orderedProducts.ThenByDescending(sortOptions[i])
                            : orderedProducts.ThenBy(sortOptions[i]);
                    }
                }

                products = orderedProducts.ToList();
            }

            return products;
        }

        private Func<Product, object> GetSortOptionByComboBoxIndex(int index) => index switch
        {
            0 => p => p.Type,
            1 => p => p.Price,
            2 => p => p.ProductionYear,
            _ => throw new ArgumentException("Invalid combobox index"),
        };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            productsDataGrid.ItemsSource = SortProducts().ToList();
        }
    }
}
