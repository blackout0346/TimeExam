using Microsoft.EntityFrameworkCore;
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

namespace TimeExam.View
{
    /// <summary>
    /// Логика взаимодействия для EditSuppliers.xaml
    /// </summary>
    public partial class EditSuppliers : Window
    {
        appDbContext db;
        TypeSuppliers TypeSuppliers;
        public EditSuppliers(TypeSuppliers typeSuppliers)
        {
            InitializeComponent();
            TypeSuppliers = typeSuppliers;
            typeOrg.Text = typeSuppliers.typeOrg.Name;
            NameSup.Text = typeSuppliers.postavshickType.Name;
            INN.Text = typeSuppliers.INN;
            Rate.Text = typeSuppliers.Rate;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                edit();
                MessageBox.Show("Редактирование прошло успешно!");
            }
            catch (Exception ex)
            {
            }
        }
        void edit()
        {
            db = new appDbContext();
        
     
        
            var execute = db.TypeSuppliers.Include(p=> p.typeOrg).Include(p=>p.postavshickType).FirstOrDefault(f => f.Id == TypeSuppliers.Id);
            if (execute != null)
            {
                execute.INN = INN.Text;
                execute.Rate = Rate.Text;
                execute.startWork = DateTime.Now;

            }
            var typeorg = db.TypeOrg.FirstOrDefault(p => p.Id == TypeSuppliers.Id);
            if (typeorg != null)
            {
                execute.typeOrg = typeorg;
            }
            var TypePostav = db.PostavshickType.FirstOrDefault(f => f.Id == TypeSuppliers.Id);
            if (TypePostav != null)
            {
                execute.postavshickType = TypePostav;
            }
            db.SaveChanges();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     
    }
}
