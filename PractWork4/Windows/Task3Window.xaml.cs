using Microsoft.EntityFrameworkCore;
using PractWork4.Data;
using PractWork4.Models;
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

namespace PractWork4.Windows
{
    /// <summary>
    /// Логика взаимодействия для Task3Window.xaml
    /// </summary>
    public partial class Task3Window : Window
    {
        public List<Product> Products { get; set; }

        public Task3Window()
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
    }
}
