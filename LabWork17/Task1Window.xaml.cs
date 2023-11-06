using System;
using System.Linq;
using System.Windows;

namespace LabWork17
{
    /// <summary>
    /// Логика взаимодействия для Task1Window.xaml
    /// </summary>
    public partial class Task1Window : Window
    {
        ApplicationContext _context = new ApplicationContext();

        public Task1Window()
        {
            InitializeComponent();
            try
            {
                productsDataGrid.ItemsSource = _context.Products.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PriceSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products.OrderBy(p => p.Price).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TypePriceSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .OrderBy(p => p.Type)
                    .ThenBy(p => p.Price)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TypePriceDescSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .OrderBy(p => p.Type)
                    .ThenByDescending(p => p.Price)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PriceDescTypeSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .OrderByDescending(p => p.Price)
                    .ThenBy(p => p.Type)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
