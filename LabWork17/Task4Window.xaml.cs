using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace LabWork17
{
    /// <summary>
    /// Логика взаимодействия для Task4Window.xaml
    /// </summary>
    public partial class Task4Window : Window
    {
        ApplicationContext _context = new ApplicationContext();

        public Task4Window()
        {
            InitializeComponent();
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .Include(m => m.Manufacturer)
                    .Select(p => new
                    {
                        p.ProductId,
                        p.Manufacturer.Title,
                        p.Model,
                        p.Price,
                        p.Description,
                        p.ProductionYear,
                        p.Type,
                        p.Weight,
                        p.IsDeleted,
                        p.Quantity
                    }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManufactorerTitleSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .Include(m => m.Manufacturer)
                    .Select((p) => new
                    {
                        p.ProductId,
                        p.Manufacturer.Title,
                        p.Model,
                        p.Price,
                        p.Description,
                        p.ProductionYear,
                        p.Type,
                        p.Weight,
                        p.IsDeleted,
                        p.Quantity
                    })
                    .OrderBy(m => m.Title)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManufactorerTitleModelSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productsDataGrid.ItemsSource = _context.Products
                    .Include(m => m.Manufacturer)
                    .Select((p) => new
                    {
                        p.ProductId,
                        p.Manufacturer.Title,
                        p.Model,
                        p.Price,
                        p.Description,
                        p.ProductionYear,
                        p.Type,
                        p.Weight,
                        p.IsDeleted,
                        p.Quantity
                    })
                    .OrderBy(m => m.Title)
                    .ThenBy(p => p.Model)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
