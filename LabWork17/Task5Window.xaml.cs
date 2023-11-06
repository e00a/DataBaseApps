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

            if (firstComboBox.SelectedIndex == 0) 
            { 
                products = firstCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.Type).ToList() : products.OrderBy(p => p.Type).ToList();
            }
            else if (firstComboBox.SelectedIndex == 1)
            {
                products = firstCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.Price).ToList() : products.OrderBy(p => p.Price).ToList();
            }
            else if (firstComboBox.SelectedIndex == 2) 
            { 
                products = firstCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.ProductionYear).ToList() : products.OrderBy(p => p.ProductionYear).ToList();
            }

            if (secondComboBox.SelectedIndex == 0)
            {
                products = secondCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.Type).ToList() : products.OrderBy(p => p.Type).ToList();
            }
            else if (secondComboBox.SelectedIndex == 1)
            {
                products = secondCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.Price).ToList() : products.OrderBy(p => p.Price).ToList();
            }
            else if (secondComboBox.SelectedIndex == 2)
            {
                products = secondCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.ProductionYear).ToList() : products.OrderBy(p => p.ProductionYear).ToList();
            }

            if (thirdComboBox.SelectedIndex == 0)
            {
                products = thirdCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.Type).ToList() : products.OrderBy(p => p.Type).ToList();
            }
            else if (thirdComboBox.SelectedIndex == 1)
            {
                products = thirdCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.Price).ToList() : products.OrderBy(p => p.Price).ToList();
            }
            else if (thirdComboBox.SelectedIndex == 2)
            {
                products = thirdCheckBox.IsChecked.Value ? products.OrderByDescending(p => p.ProductionYear).ToList() : products.OrderBy(p => p.ProductionYear).ToList();
            }

            return products;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            productsDataGrid.ItemsSource = SortProducts().ToList();

            var l = _products;
            l = l.OrderBy(p => p.Type).ToList();
            l = l.OrderByDescending(p => p.Price).ToList();
            productsDataGrid.ItemsSource = l;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            productsDataGrid.ItemsSource = _products.OrderBy(p => p.Type).ThenByDescending(p => p.Price).ToList(); ;
        }
    }
}
