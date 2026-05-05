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
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            InitializeComponent();
            //Uri iconUri = new Uri("Mozaika.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
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
            var query = db.Materials.Include(p=> p.materialType).Select(p=> new
            {
                p.NameMaterial,
                p.priceoneMaterial,
         
                p.count,
                p.materialType.TypeMaterial,
                p.countInBox,
                p.unitofmeasurement,
                p.minCount,
            });
            var result = await query.ToListAsync();
            tablematerial.ItemsSource = result;
            counts.Text = $" Количество записей{result.Count}";            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
