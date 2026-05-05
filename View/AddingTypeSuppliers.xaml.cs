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

namespace TimeExam
{
    /// <summary>
    /// Логика взаимодействия для TypeSuppliers.xaml
    /// </summary>
    public partial class AddingTypeSuppliers : Window
    {
        appDbContext db;
        public AddingTypeSuppliers()
        {
            InitializeComponent();
            //Uri iconUri = new Uri("Mozaika.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
        }
        void add()
        {
            db = new appDbContext();
            var TypeOrgs = new TypeOrg() {  Name = typeOrg.Text };
            var typePostavhick = new PostavshickType() { Name = NameSup.Text };
            var TypeSuppliers = new TypeSuppliers() { INN = INN.Text, postavshickType= typePostavhick, typeOrg= TypeOrgs , Rate=Rate.Text, startWork =DateTime.Now, };
            db.AddRange(TypeSuppliers);

            db.SaveChanges();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                add();
                MessageBox.Show("Успешно добавлено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
            
            
        }
    }
}
