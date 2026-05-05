using Microsoft.EntityFrameworkCore;
using secondExam.View;
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
using TimeExam.View;

namespace TimeExam
{
    /// <summary>
    /// Логика взаимодействия для Material.xaml
    /// </summary>
    public partial class Material : Window
    {
        appDbContext db;
        public Material()
        {
            db = new appDbContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            InitializeComponent();
            search.TextChanged += search_TextChanged;
            Uri iconUri = new Uri("Mozaika.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            loadingAll();
        }
        async void loadingAll()
        {

            if (!db.ProductType.Any() || !db.MaterialType.Any() || !db.Materials.Any() || !db.PostavshickType.Any())
            {
                await load();
            }
            await Selected();


        }
        async Task load()
        {
            Parse parse = new Parse(db);
            parse.AddMaterialType();


            parse.AddTypePostav();
            parse.AddProductType();

            parse.AddMaterial();


            parse.AddMaterialSuppliers();
        }
        async Task Selected()
        {
            var query = db.Materials.Include(p => p.materialType).AsQueryable() ;
  
    
            if (!string.IsNullOrWhiteSpace(search.Text.ToLower()))
            {
                query = query.Where(p => EF.Functions.Like(p.NameMaterial, $"%{search.Text}%"));
            }
            var result = await query.ToListAsync();
            tablematerial.ItemsSource = result;
            counts.Text = $" Количество записей{result.Count}";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItems = tablematerial.SelectedItems;
            if (selectedItems.Count == 0)
            {
                return;
            }
            foreach (var item in selectedItems)
            {

                //var material = item as Materials;


                dynamic dynamicType = item;
                int id = dynamicType.Id;


                var findId = await db.Materials.FindAsync(id);

                if (findId != null)
                {
                    db.Materials.Remove(findId);
                }





            }
            db.SaveChanges();
            await Selected();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddingProduct addingProduct = new AddingProduct();
            addingProduct.Show();
        }

     

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {


            
            var selectedItems = tablematerial.SelectedItem as Materials;
            
            
            if (selectedItems == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }


            var Materials = await db.Materials.Include(p => p.materialType).FirstOrDefaultAsync(p => p.Id == selectedItems.Id);
            if (Materials == null)
            {
                return;
            }
            EditMaterial editMaterial = new EditMaterial(Materials);
            editMaterial.Show();
            
        }

     
        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            await Selected();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dispatcher.Invoke(() => Selected());
        }
    }
}
