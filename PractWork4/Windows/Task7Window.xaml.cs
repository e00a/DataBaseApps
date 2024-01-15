using PractWork4.Data;
using PractWork4.Models;
using System.Security.AccessControl;
using System.Windows;

namespace PractWork4.Windows
{
    /// <summary>
    /// Логика взаимодействия для Task7Window.xaml
    /// </summary>
    public partial class Task7Window : Window
    {
        public List<Manufacturer> Manufacturers { get; set; }
        public Product? Product { get; set; }

        public Task7Window(Product? product = null)
        {
            Product ??= product;
            DataContext = this;
            try
            {
                using var context = new MarketContext();
                Manufacturers = context.Manufacturers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
            //ManufacturersComboBox.SelectedItem = Product.Manufacturer;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct();
            SaveProduct();
        }

        private void SaveProduct()
        {
            if (Product == null) return;
            try
            {
                using (var context = new MarketContext())
                {
                    context.Update(Product);

                    context.SaveChanges();
                }
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception)
            {
                MessageBox.Show("Проблема с сохранением.");
            }
        }

        private void CreateProduct()
        {
            if (Product != null) return;
            
            var model = ModelTextBox.Text;
            var type = TypeTextBox.Text;
            var description = DescriptionTextBox.Text;
            if (ManufacturersComboBox.SelectedItem is null
                || string.IsNullOrWhiteSpace(model)
                || !decimal.TryParse(PriceTextBox.Text, out var price)
                || !short.TryParse(ProductionYearTextBox.Text, out var productionYear)
                || !decimal.TryParse(WeightTextBox.Text, out var weight) 
                || !byte.TryParse(QuantityTextBox.Text, out var quantity)
                )
            {
                MessageBox.Show("Ошибка при заполнении данных");
                return;
            }
            var manufacturer = ManufacturersComboBox.SelectedItem as Manufacturer;

            Product ??= new Product();
            Product.Model = model;
            Product.Price = price;
            Product.Manufacturer = manufacturer;
            Product.Type = type;
            Product.Weight = weight;
            Product.Quantity = quantity;
            Product.ProductionYear = productionYear;
            Product.Description = description;
        }
    }
}
