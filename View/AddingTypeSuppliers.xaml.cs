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

namespace TimeExam
{
    /// <summary>
    /// Логика взаимодействия для TypeSuppliers.xaml
    /// </summary>
    public partial class AddingTypeSuppliers : Window
    {
        public AddingTypeSuppliers()
        {
            InitializeComponent();
            //Uri iconUri = new Uri("Mozaika.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
