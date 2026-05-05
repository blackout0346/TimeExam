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
    /// Логика взаимодействия для EditMaterial.xaml
    /// </summary>
    public partial class EditMaterial : Window
    {
        appDbContext db;
        Materials Materials;
        public EditMaterial(Materials materials)
        {
            InitializeComponent();
            Materials = materials;
     
            NameMaterial.Text = materials.NameMaterial;
            edChange.Text = materials.unitofmeasurement;
            priceOne.Text = materials.priceoneMaterial.ToString();
            countstorage.Text = materials.count.ToString();
            MinPrice.Text = materials.minCount.ToString();
            countmaterial.Text = materials.countInBox.ToString();
            typesProduct.Text = materials.materialType.TypeMaterial;
        }
        void edit()
        {
            db = new appDbContext();
            var execute = db.Materials.FirstOrDefault(f => f.Id == Materials.Id);
            if (execute != null)
            {
                execute.unitofmeasurement = edChange.Text;
                execute.NameMaterial = NameMaterial.Text;
                execute.priceoneMaterial = int.Parse(priceOne.Text);
                execute.count = int.Parse(countstorage.Text);
                execute.minCount = int.Parse(MinPrice.Text);
                execute.countInBox = int.Parse(countmaterial.Text);
            }
            var TypeMaterials = db.MaterialType.FirstOrDefault(f => f.Id == Materials.Id);
            if (TypeMaterials != null)
            {
                TypeMaterials.TypeMaterial = typesProduct.Text;
            }

            db.SaveChanges();
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                edit();
                MessageBox.Show("Редактирование прошло успешно!");
          
        }

     
    }
}
