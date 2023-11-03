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

namespace LabWork16
{
    /// <summary>
    /// Логика взаимодействия для Task1Window.xaml
    /// </summary>
    public partial class Task1Window : Window
    {
        int _pageSize = 5;

        public Task1Window()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DapperDataContext dataContext = new DapperDataContext();

            List<Product>? firstPageProducts = dataContext.Products.Take(_pageSize).ToList();

            productsDataGrid.ItemsSource = firstPageProducts;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _pageSize = Convert.ToInt32(pageSizeTextBlock.Text);
            LoadData();
        }
    }
}
