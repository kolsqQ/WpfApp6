using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> product = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Addproduct_Click(object sender, RoutedEventArgs e)
        {
            string name = NameText.Text;
            int quantity = 0;

            if (string.IsNullOrEmpty(NameText.Text))
            {

                MessageBox.Show("введите название");
                return;

            }

            if (string.IsNullOrEmpty(PriceText.Text) || !float.TryParse(PriceText.Text, out float price))
            {
                MessageBox.Show("введите корректную цену");
                return;
            }

            if (string.IsNullOrEmpty(QuantityText.Text) || !int.TryParse(QuantityText.Text, out quantity))
                {
                 
                        MessageBox.Show("введите корректное количество");
                        return;
            
                }

                var product = new Product(name, price, quantity);
                ProductList.Items.Add(product);
                Clear();


            }

        private void Clear()
        {
            NameText.Clear();
            PriceText.Clear();
            QuantityText.Clear();
        }

        private void Showproduct_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product product in ProductList.Items) 
            {
                product.Deconstruct(out string name, out double price, out int quantity);
                MessageBox.Show($"Название: {name}\nЦена: {price}\nКоличество: {quantity}");
            }

        }
    }
}
