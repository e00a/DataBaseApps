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
    /// Логика взаимодействия для Task2Window.xaml
    /// </summary>
    public partial class Task2Window : Window
    {
        int _pageSize = 5;
        int _currentPage = 1;

        public Task2Window()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            pageSizeTextBlock.Text = _pageSize.ToString();
            pageTextBlock.Text = _currentPage.ToString();

            DapperDataContext dataContext = new DapperDataContext();

            List<Product>? products = dataContext.Products
                .Skip(_pageSize * (_currentPage - 1))
                .Take(_pageSize)
                .ToList();

            productsDataGrid.ItemsSource = products;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            _pageSize = Convert.ToInt32(pageSizeTextBlock.Text);

            var page = Convert.ToInt32(pageTextBlock.Text);
            _currentPage = page == 0 ? 1 : page;

            LoadData();
        }
    }
}
