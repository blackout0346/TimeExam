
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
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (
           !string.IsNullOrEmpty(MinPrice.Text) ||
           !string.IsNullOrEmpty(NameProduct.Text) ||
           !string.IsNullOrEmpty(TypeProduct.Text)
     )
            {
                MessageBox.Show("Успешно добавлен");
                AddProduct();
                TypeProduct.Text = "";
                MinPrice.Text = "";
       
                NameProduct.Text = "";
              
                return;
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

      
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
