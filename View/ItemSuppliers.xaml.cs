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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace secondExam.View
{
    /// <summary>
    /// Логика взаимодействия для ItemPartners.xaml
    /// </summary>
    public partial class ItemSuppliers : UserControl
    {
        public int SuppliersId {  get; set; }
        public ItemSuppliers(int suppliersId, string typeName, string namepostav, string INN, string rate,  DateTime Date)
        {
            InitializeComponent();
     
            SuppliersId = suppliersId; 
            TypeName.Text = $"{typeName} |ИНН {INN}";
            //Discount.Text = discount.ToString();
            DirectorName.Text = namepostav;
            Number.Text = $" {Date}";
            Rate.Text = $"Рейтинг: {rate}";
        }
    }
}
