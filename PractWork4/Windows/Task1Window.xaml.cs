using PractWork4.Data;
using PractWork4.Models;
using System.Windows;

namespace PractWork4.Windows
{
    /// <summary>
    /// Логика взаимодействия для Task1Window.xaml
    /// </summary>
    public partial class Task1Window : Window
    {
        public List<Product> Products { get; set; }

        public Task1Window()
        {
            DataContext = this;

            try
            {
                using (var context = new MarketContext())
                {
                    Products = context.Products.ToList();
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
