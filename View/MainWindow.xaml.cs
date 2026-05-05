using Microsoft.EntityFrameworkCore;
using secondExam.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeExam.Module;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace TimeExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        appDbContext db;
        public MainWindow()
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

            if (!db.PostavshickType.Any() || !db.ProductType.Any() || !db.MaterialType.Any() || !db.TypeSuppliers.Any() || !db.TypeOrg.Any() || !db.Materials.Any())
            {
                await load();
        }
            await Selected();

        }

        async Task Selected()
        {
            var query = db.TypeSuppliers.Include(P => P.typeOrg).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Text.ToLower()))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{search.Text}%"));
            }

            var results = await query.ToListAsync();
            foreach (var item in results)
            {
                ItemPartners itemPartners = new ItemPartners(item.Id, item.typeOrg.Name, item.Name, item.INN, item.Rate ,item.startWork.ToString());
                displayPartner.Items.Add(itemPartners);
            }
        }

        async Task load()
        {
            Parse parse = new Parse(db);
            parse.AddMaterialType();
            parse.AddTypeOrg();

   
            parse.AddProductType();
            parse.AddTypePostav();
            parse.AddMaterial();
            parse.AddTypeSuppliers();

            parse.AddMaterialSuppliers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddingTypeSuppliers typeSuppliers = new AddingTypeSuppliers();
            typeSuppliers.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Material material = new Material();
            material.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
    }
}