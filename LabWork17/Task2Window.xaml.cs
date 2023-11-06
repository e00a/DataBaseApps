using System;
using System.Linq;
using System.Windows;

namespace LabWork17
{
    /// <summary>
    /// Логика взаимодействия для Task2Window.xaml
    /// </summary>
    public partial class Task2Window : Window
    {
        ApplicationContext _context = new ApplicationContext();

        public Task2Window()
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

        private void PriceSortComboBoxItem_Selected(object sender, RoutedEventArgs e)
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

        private void PriceDescSortComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .OrderByDescending(p => p.Price)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModelSortComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .OrderBy(p => p.Model)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
