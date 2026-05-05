
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
using TimeExam.Module;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace secondExam.View
{
    /// <summary>
    /// Логика взаимодействия для AddingProduct.xaml
    /// </summary>
    public partial class AddingProduct : Window
    {
        appDbContext db;
        public AddingProduct()
        {
            InitializeComponent();
            //Uri iconUri = new Uri("Mozaika.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
        }
        void AddProduct()
        {
            db = new appDbContext();

            var type = new MaterialType() { TypeMaterial = typesProduct.Text };
            var materials = new Materials() { materialType = type, NameMaterial = NameMaterial.Text, countInBox = int.Parse(countmaterial.Text), count = int.Parse(countstorage.Text), minCount = decimal.Parse(MinPrice.Text), priceoneMaterial = decimal.Parse(priceOne.Text), unitofmeasurement = edChange.Text };
            db.AddRange(materials);
            db.SaveChanges();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Успешно добавлено!");
                AddProduct();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
