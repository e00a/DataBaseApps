using Microsoft.EntityFrameworkCore;
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

namespace LabWork17
{
    /// <summary>
    /// Логика взаимодействия для Task3Window.xaml
    /// </summary>
    public partial class Task3Window : Window
    {
        ApplicationContext _context = new ApplicationContext();
        public Task3Window()
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

        private void PriceSortRadioButton_Checked(object sender, RoutedEventArgs e)
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

        private void PriceDescSortRadioButton_Checked(object sender, RoutedEventArgs e)
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

        private void ModelSortRadioButton_Checked(object sender, RoutedEventArgs e)
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
