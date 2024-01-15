using Microsoft.EntityFrameworkCore;
using PractWork4.Data;
using PractWork4.Models;
using System.Windows;

namespace PractWork4.Windows
{
    /// <summary>
    /// Логика взаимодействия для Task2Window.xaml
    /// </summary>
    public partial class Task2Window : Window
    {
        public List<Product> Products { get; set; }

        public Task2Window()
        {
            DataContext = this;

            try
            {
                using (var context = new MarketContext())
                {
                    Products = context.Products.Include(p => p.Manufacturer).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var report = (sender as System.Windows.Controls.Button)?.DataContext as Product;
            var dataBase = new Task7Window(report);
            dataBase.ShowDialog();
        }
    }
}
