using PractWork4.Data;
using PractWork4.Models;
using System.Windows;

namespace PractWork4.Windows
{
    /// <summary>
    /// Логика взаимодействия для Task7Window.xaml
    /// </summary>
    public partial class Task7Window : Window
    {
        public List<Manufacturer> Manufacturers { get; set; }
        public Product Product { get; set; } = new Product();

        public Task7Window(Product? product = null)
        {
            if (product != null)
                Product = product;
            
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
            ManufacturersComboBox.SelectedItem = Manufacturers.FirstOrDefault(m=> m.ManufacturerId == Product.ManufacturerId);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckData())
            {
                MessageBox.Show("Ошибка при заполнении данных");
                return;
            }; 
            SaveProduct();
        }

        private void SaveProduct()
        {
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

        private bool CheckData()
        {
            return ManufacturersComboBox.SelectedItem is not null
            && !string.IsNullOrWhiteSpace(ModelTextBox.Text)
            && decimal.TryParse(PriceTextBox.Text, out _)
            && short.TryParse(ProductionYearTextBox.Text, out _)
            && decimal.TryParse(WeightTextBox.Text, out _)
            && byte.TryParse(QuantityTextBox.Text, out _);
        }
    }
}
