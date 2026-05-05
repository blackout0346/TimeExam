using Microsoft.EntityFrameworkCore;
using secondExam.View;
using System.Diagnostics;
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
using TimeExam.Module;
using TimeExam.View;
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
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            InitializeComponent();
            Uri iconUri = new Uri("Mozaika.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            search.TextChanged += search_TextChanged;

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
            displayPartner.Items.Clear();
            var query = db.TypeSuppliers.Include(P => P.typeOrg).Include(p=>p.postavshickType).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Text.ToLower()))
            {
                query = query.Where(p => EF.Functions.Like(p.postavshickType.Name, $"%{search.Text}%"));
            }

            var results = await query.ToListAsync();
         
            foreach (var item in results)
            {
                ItemSuppliers itemPartners = new ItemSuppliers(item.Id, item.typeOrg.Name, item.postavshickType.Name, item.INN, item.Rate ,item.startWork);
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

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItems = displayPartner.SelectedItems;
            if (selectedItems.Count == 0)
            {
                return;
            }
            foreach (var item in selectedItems)
            {
                var itemsupl = item as ItemSuppliers;

                if (itemsupl != null)
                {
                    var supl = await db.TypeSuppliers.FindAsync(itemsupl.SuppliersId);
                    if (supl != null)
                    {
                        db.TypeSuppliers.Remove(supl);
                    }

                }

            }
            db.SaveChanges();
            await Selected();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Material material = new Material();
            material.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddingTypeSuppliers addingTypeSuppliers = new AddingTypeSuppliers();
            addingTypeSuppliers.Show();
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var selectedItems = displayPartner.SelectedItem as ItemSuppliers;
            if (selectedItems == null)
            {
                return;
            }
            var suppliers= await db.TypeSuppliers.Include(p => p.postavshickType).FirstOrDefaultAsync(p=> p.Id == selectedItems.SuppliersId);
            EditSuppliers editSuppliers = new EditSuppliers(suppliers);
            editSuppliers.Show();

        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            await Selected();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dispatcher.Invoke(() => Selected());
        }
    }
}